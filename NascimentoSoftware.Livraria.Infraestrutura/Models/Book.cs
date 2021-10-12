using System;

namespace NascimentoSoftware.Livraria.Infraestrutura.Models
{
    public class Book
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Pages { get; set; }
        public string Language { get; set; }
            
    }
}
