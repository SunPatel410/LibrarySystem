using LibraryServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BranchController : Controller
    {
        private ILibraryBranch _libraryBranch;
        public BranchController(ILibraryBranch libraryBranch)
        {
            _libraryBranch = libraryBranch;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
