using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryData.Domain;
using LibraryServices.Interfaces;

namespace LibraryServices
{
    public class PatronService : IPatron
    {
        public Patron Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patron> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(Patron newPatron)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistory(int patronId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hold> GetHolds(int patronId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Checkout> GetCheckouts(int patronId)
        {
            throw new NotImplementedException();
        }
    }
}
