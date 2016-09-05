using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Models
{
    // Model for database objects of type Rating
    public class Rating
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

    }
}
