using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea.Models
{
    public class TipoConsulta
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
