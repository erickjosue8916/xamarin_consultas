using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Tarea.Models;

namespace Tarea.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Paciente>().Wait();
            _database.CreateTableAsync<TipoConsulta>().Wait();
            _database.CreateTableAsync<Consulta>().Wait();
        }

        // lists
        public Task<List<Paciente>> GetPasientesAsync()
        {
            return _database.Table<Paciente>().ToListAsync();
        }

        public Task<List<TipoConsulta>> GetTipoConsultasAsync()
        {
            return _database.Table<TipoConsulta>().ToListAsync();
        }

        public Task<List<Consulta>> GetConsultasAsync()
        {
            return _database.Table<Consulta>().ToListAsync();
        }

        // DETAILS
        public Task<Paciente> GetPacienteAsync(int id)
        {
            return _database.Table<Paciente>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<TipoConsulta> GetTipoConsultaAsync(int id)
        {
            return _database.Table<TipoConsulta>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<Consulta> GetConsultaAsync(int id)
        {
            return _database.Table<Consulta>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        // SAVE
        public Task<int> SavePacienteAsync(Paciente paciente)
        {
            if (paciente.Id != 0)
            {
                return _database.UpdateAsync(paciente);
            }
            else
            {
                return _database.InsertAsync(paciente);
            }
        }

        public Task<int> SaveTipoConsultaAsync(TipoConsulta tipoConsulta)
        {
            if (tipoConsulta.Id != 0)
            {
                return _database.UpdateAsync(tipoConsulta);
            }
            else
            {
                return _database.InsertAsync(tipoConsulta);
            }
        }

        public Task<int> SaveConsultaAsync(Consulta consulta)
        {
            if (consulta.Id != 0)
            {
                return _database.UpdateAsync(consulta);
            }
            else
            {
                return _database.InsertAsync(consulta);
            }
        }

        // DELETE
        public Task<int> DeletePacienteAsync(Paciente note)
        {
            return _database.DeleteAsync(note);
        }

        public Task<int> DeleteTipoConsultaAsync(TipoConsulta tipoConsulta)
        {
            return _database.DeleteAsync(tipoConsulta);
        }

        public Task<int> DeleteConsultaAsync(Consulta consulta)
        {
            return _database.DeleteAsync(consulta);
        }
    }
}
