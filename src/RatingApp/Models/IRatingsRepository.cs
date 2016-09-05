using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Models
{
    // Interface for RatingsRepository, constructing how methods accessing database should look like
    public interface IRatingsRepository
    {
        IEnumerable<Rating> GetAll();
        Rating GetById(int id);
        void Add(Rating item);
        void Update(Rating item);
        void Remove(int id);
    }
}
