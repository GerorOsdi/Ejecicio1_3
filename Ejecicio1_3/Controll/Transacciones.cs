using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using SQLite;
using Ejecicio1_3.Models;

namespace Ejecicio1_3.Controll
{
    public class Transacciones
    {
        readonly SQLiteAsyncConnection BaseDatos;

        public Transacciones(string dbPaht)
        {
            BaseDatos = new SQLiteAsyncConnection(dbPaht);
            BaseDatos.CreateTableAsync<Personas>();
        }

        public Task<int> savePersonas(Personas Persona)
        {
            if (Persona.Id != 0)
            {
                return BaseDatos.UpdateAsync(Persona);
            }
            else
            {
                return BaseDatos.InsertAsync(Persona);
            }
        }

        public Task<List<Personas>> getPersonas()
        {
            return BaseDatos.Table<Personas>().ToListAsync();
        }

        public Task<Personas> getPersona(int id)
        {
            return BaseDatos.Table<Personas>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> PersonaDelete(Personas persona)
        {
            return BaseDatos.DeleteAsync(persona);
        }
    }
}
