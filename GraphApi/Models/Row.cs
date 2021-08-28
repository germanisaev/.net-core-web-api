using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraphApi.Models
{
    public class Row: BaseEntity
    {
        public string month { get; set; }
        public int point1 { get; set; }
        public int point2 { get; set; }
        public int point3 { get; set; }
    }
}
