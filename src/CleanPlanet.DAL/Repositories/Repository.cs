﻿using System.Linq.Expressions;
using CleanPlanet.DAL.DbContexts;
using CleanPlanet.DAL.IRepositories;
using CleanPlanet.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace CleanPlanet.DAL.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly AppDbContext dbContext;
    private readonly DbSet<TEntity> dbSet;
    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        await dbSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        this.dbContext.Update(entity).State = EntityState.Modified;
    }

    public void Delete(TEntity entity)
    {
        entity.IsDelete = true;
    }

    public void Destroy(TEntity entity)
    {
        this.dbSet.Remove(entity);
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
    {
        IQueryable<TEntity> query = dbSet.Where(expression).AsQueryable();

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        var entity = await query.Where(e => !e.IsDelete).FirstOrDefaultAsync(expression);
        return entity;
    }

    public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null, bool isNoTracked = true, string[] includes = null)
    {
        IQueryable<TEntity> query = expression is null ? dbSet.AsQueryable() : dbSet.Where(expression).AsQueryable();

        query = isNoTracked ? query.AsNoTracking() : query;

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        return query.Where(e => !e.IsDelete);
    }
}