using GraphApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphApi.Services
{
    public interface IChartService
    {
        Task<ActionResult> GetChart();
    }
    public class ChartService : IChartService
    {
        public async Task<ActionResult> GetChart()
        {
            var chart = new Chart()
            {
                cols = new Col[]
                {
                    new Col{ id = 1, type = "string", label = "Month" },
                    new Col{ id = 2, type = "number", label = "Point1" },
                    new Col{ id = 3, type = "number", label = "Point2" },
                    new Col{ id = 4, type = "number", label = "Point3" }
                },
                rows = new Row[]
                {
                    new Row { id = 1, month = "Jan", point1 = getRandom(), point2 = getRandom(), point3 = getRandom() },
                    new Row { id = 2, month = "Feb", point1 = getRandom(), point2 = getRandom(), point3 = getRandom() },
                    new Row { id = 3, month = "Mar", point1 = getRandom(), point2 = getRandom(), point3 = getRandom() },
                    new Row { id = 4, month = "Apr", point1 = getRandom(), point2 = getRandom(), point3 = getRandom() },
                    new Row { id = 5, month = "May", point1 = getRandom(), point2 = getRandom(), point3 = getRandom() },
                    new Row { id = 6, month = "Jun", point1 = getRandom(), point2 = getRandom(), point3 = getRandom() },
                    new Row { id = 7, month = "Jul", point1 = getRandom(), point2 = getRandom(), point3 = getRandom() },
                    new Row { id = 8, month = "Aug", point1 = getRandom(), point2 = getRandom(), point3 = getRandom() },
                    new Row { id = 9, month = "Sep", point1 = getRandom(), point2 = getRandom(), point3 = getRandom() },
                    new Row { id = 10, month = "Oct", point1 = getRandom(), point2 = getRandom(), point3 = getRandom() },
                    new Row { id = 11, month = "Nov", point1 = getRandom(), point2 = getRandom(), point3 = getRandom() },
                    new Row { id = 12, month = "Dec", point1 = getRandom(), point2 = getRandom(), point3 = getRandom() }
                }
            };
            return await Task.Run(() => new JsonResult(chart));
        }

        private int getRandom()
        {
            Random rnd = new Random();
            int point = rnd.Next(1, 10000);
            return point;
        }

    }
}
