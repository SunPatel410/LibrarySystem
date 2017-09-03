using System.Collections.Generic;
using LibraryData.Domain;

namespace LibraryServices.Interfaces
{
    public interface ILibraryAsset
    {
        IEnumerable<LibraryAsset> GetAll();
        LibraryAsset GetById(int id);

        void Add(LibraryAsset newAsset);
        string GetAuthorOrDirector(int id);
        string GetDewayIndex(int id);
        string GetTitle(int id);
        string GetIsbn(int id);
        string GetType(int id);

        LibraryBranch GetCurrentLocation(int id);
    }
}
