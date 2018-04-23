using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoolgleZonas.ModelosQuerys
{
    [NotMapped]
    public class Lista
    {
        public int CodZona { get; set; }
        public string NombreZona { get; set; }
        public string Descripcion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Radio { get; set; }
        public System.DateTime FechaHoraCreado { get; set; }
        public Nullable<int> CodUsuario { get; set; }

    }
}