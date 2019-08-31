using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels
{
    public class UserDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public FavoriteGenre FavoriteGenre { get; set; }
        public virtual ICollection<MovieDto> MoviesList { get; set; }
    }

    public enum FavoriteGenre
    {
        action = 1,
        comedy,
        horror
    }
}
