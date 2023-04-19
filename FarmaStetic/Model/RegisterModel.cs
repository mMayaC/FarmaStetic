using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FarmaStetic.Model
{
    public class RegisterModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string nombre { get; set; }
        [MaxLength(50)]
        public string apellido { get; set; }
        [MaxLength(50)]
        public string correo { get; set; }
        [MaxLength(50)]
        public string usuario { get; set; }
        [MaxLength(50)]
        public string contraseña { get; set; }
        [MaxLength(50)]
        public int telefono { get; set; }
    }
}