using Dogs.Models;
using Microsoft.Extensions.Hosting;

namespace Dogs.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Dog> Dogs { get; set; }       
        public IEnumerable<Tag> Tags { get; set; }
    }
}
