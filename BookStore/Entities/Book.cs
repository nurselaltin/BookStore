    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Entities
{
    public class Book
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Title { get; set; }

        public int GenreId { get; set; } //Tür
        public Genre Genre { get; set; } //Tür

        public Author Author { get; set; }

        public int  PageCount { get; set; }

    



    }
}
