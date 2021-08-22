using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistema_de_ventas.Models
{
    public class Productos
    { 
            public string producto { get; set; }
            public string categoria { get; set; }
            public string marca { get; set; }
            public int id { get; set; }
            public int idCat { get; set; }
            public int precios { get; set; }
            public int idMarca { get; set; }
            public int stock { get; set; }
        
    }
}