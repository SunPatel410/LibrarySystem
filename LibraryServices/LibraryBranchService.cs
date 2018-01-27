using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryData;
using LibraryData.Domain;
using LibraryServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryServices
{
    public class LibraryBranchService : ILibraryBranch
    {
        private LibraryContext _context;

        public LibraryBranchService(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<LibraryBranch> GetAll()
        {
            return _context.LibraryBranches
                .Include(b => b.Patrons)
                .Include(b => b.LibraryAssets);
        }

        public IEnumerable<Patron> GetPatrons(int branchId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LibraryAsset> GetAssets(int branchId)
        {
            return _context.LibraryBranches
                .Include(b => b.LibraryAssets)
                .FirstOrDefault(b => b.Id == branchId)?.LibraryAssets;
        }

        public IEnumerable<string> GetBranchHours(int branchId)
        {
            var hours = _context.BranchHours.Where(h => h.Branch.Id == branchId);

        }

        public LibraryBranch Get(int branchId)
        {
            return GetAll().FirstOrDefault(b => b.Id == branchId);
        }

        public void Add(LibraryBranch libraryBranch)
        {
            _context.Add(libraryBranch);
            _context.SaveChanges();
        }

        public bool IsBranchOpen(int branchId)
        {
            throw new NotImplementedException();
        }
    }
}
