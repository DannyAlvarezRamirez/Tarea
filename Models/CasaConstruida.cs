using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea.Models
{
    public class CasaConstruida
    {
        [Key]
        public int Id_Casa { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "El valor debe ser mayor que 0")]
        public int Metros_Construccion_Totales { get; set; }
        [ForeignKey("Id_Modelo")]
        public int Id_Modelo { get; set; }
    }
}
