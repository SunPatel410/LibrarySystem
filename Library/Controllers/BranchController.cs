using System.Linq;
using Library.ViewModels.Branch;
using LibraryServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BranchController : Controller
    {
        private readonly ILibraryBranch _libraryBranch;
        public BranchController(ILibraryBranch libraryBranch)
        {
            _libraryBranch = libraryBranch;
        }

        public IActionResult Index()
        {
            var branches = _libraryBranch.GetAll().Select(b => new BranchDetailModel
            {
                Id = b.Id,
                Name = b.Name,
                IsOpen = _libraryBranch.IsBranchOpen(b.Id),
                NumberOfAssets = _libraryBranch.GetAssets(b.Id).Count(),
                NumberOfPatrons = _libraryBranch.GetPatrons(b.Id).Count()
            });

            var vm = new BranchIndexModel()
            {
                Branches = branches
            };

            return View(vm);
        }

        public IActionResult Detail(int id)
        {
            var branch = _libraryBranch.Get(id);

            var model = new BranchDetailModel
            {
                Id = branch.Id,
                Name = branch.Name,
                Address = branch.Address,
                Telephone = branch.Telephone,
                OpenDate = branch.OpenDate.ToString("yyyy-MM-dd"),
                NumberOfAssets = _libraryBranch.GetAssets(id).Count(),
                NumberOfPatrons = _libraryBranch.GetPatrons(id).Count(),
                TotalAssetValue = _libraryBranch.GetAssets(id).Sum(a => a.Cost),
                ImageUrl = branch.ImageUrl,
                HoursOpen = _libraryBranch.GetBranchHours(id)
            };

            return View(model);
        }
    }
}
