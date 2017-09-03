using LibraryServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Library.Controllers
{
    public class PatronController : Controller
    {
        private IPatron _patron;

        public PatronController(IPatron patron)
        {
            _patron = patron;
        }

    }
}