using System.Collections.Generic;
using LibraryData.Domain;

namespace LibraryServices.Interfaces
{
    public interface ILibraryBranch
    {
        IEnumerable<LibraryBranch> GetAll();
        IEnumerable<Patron> GetPatrons(int branchId);
        IEnumerable<LibraryAsset> GetAssets(int branchId);
        IEnumerable<string> GetBranchHours(int branchId);

        LibraryBranch Get(int branchId);
        void Add(LibraryBranch libraryBranch);
        bool IsBranchOpen(int branchId);
    }
}
