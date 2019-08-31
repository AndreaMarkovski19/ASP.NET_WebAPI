using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
        public int UserId { get; set; }        
    }

    public enum Genre
    {
        action = 1,
        comedy,
        horror
    }
}
