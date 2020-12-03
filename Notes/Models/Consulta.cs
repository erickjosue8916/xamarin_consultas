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
        [Indexed]
        public int IdPaciente { get; set; }

        [Indexed]
        public int IdTipoConsulta { get; set; }
    }
}
