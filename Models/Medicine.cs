using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen3U.Models
{
    public class Medicine
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public string? Description {get; set;}
        public string? RecommendedDose {get; set;}
        public string? AdministrationForm {get; set;}
        public string? Indications {get; set;}
    }
}