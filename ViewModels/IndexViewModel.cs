using Dogs.Models;
using Microsoft.Extensions.Hosting;

namespace Dogs.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Dog> Dogs { get; set; }   
        public IEnumerable<FCICategory> FCICategories { get; set; }
        public IEnumerable<Tag> Tags { get; set; }

        public IEnumerable<Dog> RecentDogs { get; set; }
        public int CurrentPages { get; set; }
        public int? SelectedFCICategoryId { get; set; }
        public int? SelectedTagId { get; set; }
        public int TotalPages { get; set; }
        public string? SearchBreed { get; set; }
        public int LimitPage { get; set; } = 6;

    }
}
