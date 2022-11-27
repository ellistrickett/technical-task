using API.Context;
using API.Data;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

namespace API.Controllers
{
    public class AlertsService : IAlertsService
    {
        private readonly AlertDbContext _dbContext;

        public AlertsService(AlertDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Alert>> GetAllAsync()
        {
            return await _dbContext.Alerts.ToListAsync();
        }
    }
}
