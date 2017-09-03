using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Domain
{
    public class CheckoutHistory
    {
        public int Id { get; set; }

        [Required]
        public LibraryAsset LibraryAsset { get; set; }

        [Required]
        public LibraryCard LibraryCard { get; set; }

        public DateTime CheckedOut { get; set; }

        public DateTime? CheckIn { get; set; }

    }
}
