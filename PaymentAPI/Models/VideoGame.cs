using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Models
{
    public class VideoGame
    {
        [Key]
        public int VideogameId { get; set; }
        public string VideogameName { get; set; }
        public string ReleaseDate { get; set; }
        public string Platform { get; set; }
    }
}
