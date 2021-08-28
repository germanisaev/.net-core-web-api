using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraphApi.Models
{
    public class Col: BaseEntity
    {
        public string type { get; set; }
        public string label { get; set; } 
    }
}
