using System;
using SQLite;

namespace Tarea.Models
{
    public class Paciente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Edad { get; set; }

        public string Telefono { get; set; }
        // public DateTime Date { get; set; }
    }
}
