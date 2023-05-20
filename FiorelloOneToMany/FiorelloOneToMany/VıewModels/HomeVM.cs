using FiorelloOneToMany.Models;

namespace FiorelloOneToMany.VıewModels
{
    public class HomeVM
    {
        public IEnumerable<Expert> Experts { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
