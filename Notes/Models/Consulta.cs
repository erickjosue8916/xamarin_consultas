using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea.Models
{
    public class Consulta
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Fecha { get; set; }
        public string Observaciones { get; set; }
        public string IdPaciente { get; set; }
        public string IdTipoConsulta { get; set; }
    }
}
