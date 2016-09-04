using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Models
{

    public class DataManager
    {
        public static List<Rating> _ratings = new List<Rating> {
            new Rating { Id = 1, Name = "C#", Value = 3 },
            new Rating { Id = 2, Name = "JavaScript", Value = 2 },
            new Rating { Id = 3, Name = "CSS", Value = 4 }
        };

        internal IEnumerable<Rating> GetAll()
        {
            return _ratings;
        }

        internal Rating GetById(int id)
        {
            foreach (var item in _ratings)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        internal void Add(Rating item)
        {
            _ratings.Add(item);
        }

        internal void Update(Rating item)
        {
            foreach (var rating in _ratings)
            {
                if (rating.Id == item.Id)
                {
                    rating.Name = item.Name;
                    rating.Value = item.Value;
                }
            }
        }

        internal void Remove(int id)
        {
            foreach (var item in _ratings)
            {
                if (item.Id == id)
                {
                    _ratings.Remove(item);
                }
            }
        }
    }
}
