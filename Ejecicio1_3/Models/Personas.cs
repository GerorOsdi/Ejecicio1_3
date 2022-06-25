using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ejecicio1_3.Models
{
    public class Personas{
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }

    }
}
