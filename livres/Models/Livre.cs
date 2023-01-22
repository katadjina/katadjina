using System;
using System.ComponentModel.DataAnnotations;

namespace livres.Models
{
    public class Livre
    {
        public int Id {get; set;}

        [Required(ErrorMessage = "Le champs 'Nom' est obligatoire")]
        public string Title { get; set; }

        public int ISBN { get; set; }

        public int idAuthor{ get; set; }
    }
}

