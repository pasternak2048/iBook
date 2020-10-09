using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyBooks.Models.Interfaces;

namespace MyBooks.Models
{
    [Serializable]
    public class Book : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public int YearOfPublish { get; set; }
        [ForeignKey("Genre")]
        public Guid GenreId { get; set; }
        public virtual Genre Genre { get; set; }

    }
}