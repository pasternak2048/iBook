﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using MyBooks.Models.Interfaces;


namespace MyBooks.Models
{
    [Serializable]
    [XmlInclude(typeof(Book))]
    public class Genre :IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        [XmlIgnore]
        public virtual List<Book> Books { get; set; }
        public Genre()
        {
            Books = new List<Book>();
        }
    }
}