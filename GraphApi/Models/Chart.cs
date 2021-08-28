using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraphApi.Models
{
    public class Chart: BaseEntity
    {
        [Required]
        public Col[] cols { get; set; }
        [Required]
        public Row[] rows { get; set; }
    }
}
