using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13Demos.Models
{
    class Book
    {
        public int BookId { get; set; }
        
        public string Title { get; set; }

        // Foreign Key
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
