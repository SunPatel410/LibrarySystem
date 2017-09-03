using System.Linq;
using Library.ViewModels.Catalog;
using Library.ViewModels.Checkout;
using LibraryServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ILibraryAsset _assets;
        private readonly ICheckOut _checkout;

        public CatalogController(ILibraryAsset asset, ICheckOut checkout)
        {
            _assets = asset;
            _checkout = checkout;
        }

        public IActionResult Index()
        {
            var assetModels = _assets.GetAll();

            //use AutoMapper later to refactor code
            var listingResult = assetModels
                .Select(r => new AssetIndexListingModel
                {
                    Id = r.Id,
                    ImageUrl = r.ImageUrl,
                    AuthorOrDirector = _assets.GetAuthorOrDirector(r.Id),
                    DeweyCallNumber = _assets.GetDewayIndex(r.Id),
                    Title = r.Title,
                    Type = _assets.GetType(r.Id)
                });

            var vm = new AssetIndexModel()
            {
                Assets = listingResult
            };

            return View(vm);
        }

        public IActionResult Detail(int id)
        {
            var asset = _assets.GetById(id);

            var currentHolds = _checkout.GetCurrentHolds(id)
                .Select(a => new AssetHoldModel
                {
                    HoldPlaced = _checkout.GetCurrentHoldPlaced(a.Id),
                    PatronName = _checkout.GetCurrentHoldPatronName(a.Id)
                });

            var model = new AssetDetailModel
            {
                AssetId = id,
                Title = asset.Title,
                Year = asset.Year,
                Cost = asset.Cost,
                Status = asset.Status.Name,
                ImageUrl = asset.ImageUrl,
                AuthorOrDirector = _assets.GetAuthorOrDirector(id),
                CurrentLocation = _assets.GetCurrentLocation(id).Name,
                DeweyCallNumber = _assets.GetDewayIndex(id),
                CheckoutHistories = _checkout.GetCheckOutHistory(id),
                ISBN = _assets.GetIsbn(id),
                LatestCheckout = _checkout.GetLatestCheckout(id),
                PatronName = _checkout.GetCurrentCheckoutPatron(id),
                CurrentHolds = currentHolds
            };

            return View(model);
        }

        public IActionResult Checkout(int id)
        {
            var asset = _assets.GetById(id);

            var vm = new CheckoutModel
            {
                AssetId = id,
                Title = asset.Title,
                ImageUrl = asset.ImageUrl,
                LibraryCardId = "",
                IsCheckedOut = _checkout.IsCheckedOut(id)
            };

            return View(vm);
        }

        public IActionResult CheckIn(int id)
        {
            _checkout.CheckInItem(id);
            return RedirectToAction("Detail", new {id = id});
        }

        public IActionResult MarkLost(int assetId)
        {
            _checkout.MarkLost(assetId);

            return RedirectToAction("Detail", new { id = assetId });
        }

        public IActionResult Hold(int id)
        {
            var asset = _assets.GetById(id);

            var vm = new CheckoutModel
            {
                AssetId = id,
                Title = asset.Title,
                ImageUrl = asset.ImageUrl,
                LibraryCardId = "",
                IsCheckedOut = _checkout.IsCheckedOut(id),
                HoldCount = _checkout.GetCurrentHolds(id).Count()
            };

            return View(vm);
        }

        public IActionResult MarkFound(int assetId)
        {
            _checkout.MarkFound(assetId);

            return RedirectToAction("Detail", new { id = assetId });
        }

        [HttpPost]
        public IActionResult PlaceCheckout(int assetId, int libraryCardId)
        {
            _checkout.CheckOutItem(assetId, libraryCardId);
            return RedirectToAction("Detail", new {id = assetId});
        }

        [HttpPost]
        public IActionResult PlaceHold(int assetId, int libraryCardId)
        {
            _checkout.PlaceHold(assetId, libraryCardId);
            return RedirectToAction("Detail", new { id = assetId });
        }
    }
}
