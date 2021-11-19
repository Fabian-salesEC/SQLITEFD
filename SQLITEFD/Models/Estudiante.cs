﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace SQLITEFD.Models
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength (50)]
        public string Nombre { get; set; }
        [MaxLength(25)]
        public string Usuario { get; set; }
        [MaxLength(25)]

        public string Clave { get; set; }
        
    }
}
