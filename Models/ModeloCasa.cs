using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea.Models
{
    public class ModeloCasa
    {
        [Key]
        public int Id_Modelo { get; set; }
        public string Nombre_Modelo { get; set; }
        [Range(0, 1)]
        public int Tiene_Cochera_Techada { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "El valor debe ser mayor que 0")]
        public int Cantidad_Dormitorios { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "El valor debe ser mayor que 0")]
        public int Cantidad_Banos { get; set; }
        [Range(0, 1)]
        public int Es_De_Dos_Plantas { get; set; }
    }
}
