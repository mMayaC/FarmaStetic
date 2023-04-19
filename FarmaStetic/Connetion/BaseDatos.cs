using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using FarmaStetic.Model;
using System.Threading.Tasks;

namespace FarmaStetic.Connetion
{
    public class BaseDatos
    {
        SQLiteAsyncConnection db;
            public BaseDatos(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<RegisterModel>().Wait();
        }

        public Task<int>GuardarUsuarioAsync(RegisterModel registro)
        {
            if (registro.Id==0)
            {
                return db.InsertAsync(registro);
            }
            else
            {
                return null;
            }
        }

        public Task <int> ModificarUsuarioAsync(RegisterModel registro)
        {
            if (registro.Id!=0)
            {
                return db.UpdateAsync(registro);
            }
            else
            {
                return null;
            }
        }
        public Task<int> EliminarUsuarioAsync (RegisterModel registro)
        {
            return db.DeleteAsync(registro);
        }

        //Mostrar todos los usuarios de la bd
        public Task <List<RegisterModel>> GetUsuarioAsync()
        {
            return db.Table<RegisterModel>().ToListAsync();
        }

        //Mostrar los usuarios por el ID
        public Task<RegisterModel> GetUsuarioByIdAsync(int idusuario)
        {
            return db.Table<RegisterModel>().Where(s => s.Id == idusuario).FirstOrDefaultAsync();
        }
    }
}
