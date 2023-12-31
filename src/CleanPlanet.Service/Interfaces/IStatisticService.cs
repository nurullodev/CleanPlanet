﻿using CleanPlanet.Domain.Configurations;
using CleanPlanet.Service.DTOs.Statistic;

namespace CleanPlanet.Service.Interfaces;

public interface IStatisticService
{
    ValueTask<StatisticResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<StatisticResultDto>> RetrieveAsync(PaginationParams pagination);
}