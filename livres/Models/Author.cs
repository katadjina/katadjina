using System;
using System.ComponentModel.DataAnnotations;

namespace livres.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le champs 'Nom' est obligatoire")]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

