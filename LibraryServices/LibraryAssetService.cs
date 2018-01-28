using System;
using System.Collections.Generic;
using System.Linq;
using LibraryData;
using LibraryData.Domain;
using LibraryData.Interfaces;
using LibraryServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryServices
{
    /// <summary>
    /// TODO ADD REPOSITORY PATTERN INSETAD OF USING CONTEXT
    /// </summary>
    public class LibraryAssetService : ILibraryAsset
    {
        private readonly LibraryContext _context;

        public LibraryAssetService(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
            return _context.LibraryAssets
                .Include(x => x.Status)
                .Include(x => x.Location);
        }

        public LibraryAsset GetById(int id)
        {
            return GetAll().FirstOrDefault(asset => asset.Id == id);
        }

        public void Add(LibraryAsset newAsset)
        {
            _context.Add(newAsset);
            _context.SaveChanges();
        }

        public string GetDewayIndex(int id)
        {
            return _context.Books.Any(book => book.Id == id) ? 
                _context.Books.FirstOrDefault(book => book.Id == id).DeweyIndex : "";
        }

        public string GetTitle(int id)
        {
            return GetById(id).Title;
        }

        public string GetIsbn(int id)
        {
            return _context.Books.Any(book => book.Id == id) ?
                _context.Books.FirstOrDefault(book => book.Id == id).ISBN : "";
        }

        public string GetType(int id)
        {
            var book = _context.LibraryAssets.OfType<Book>()
                .Where(b => b.Id == id);

            return book.Any() ? "Book" : "Video";
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            return GetById(id).Location;
        }

        public string GetAuthorOrDirector(int id)
        {
            var isBook = _context.LibraryAssets
                .OfType<Book>().Any(asset => asset.Id == id);

            var isVideo = _context.LibraryAssets
                .OfType<Video>().Any(asset => asset.Id == id);

            return isBook ? _context.Books.FirstOrDefault(b => b.Id == id).Author
                : _context.Videos.FirstOrDefault(b => b.Id == id).Director
                  ?? "Unknown";
        }
    }
}
