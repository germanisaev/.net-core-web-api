using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphApi.Controllers
{
    [Route("api/chart")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private IChartService _chartService;

        public ChartController(IChartService chartService)
        {
            _chartService = chartService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var chart = await _chartService.GetChart();
            return Ok(chart);
        }
    }
}