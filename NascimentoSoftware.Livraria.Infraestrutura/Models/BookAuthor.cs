using System;

namespace NascimentoSoftware.Livraria.Infraestrutura.Models
{
    public class BookAuthor
    {
        public int Id { get; set; }
        public Guid BookAuthorGuid { get; set; }
        public Guid AuthorGuid { get; set; }
        public Guid BookGuid { get; set; }
        public DateTime RegisterDate { get; set; }


    }
}
