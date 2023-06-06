using ClassLib;
using WebApplication1.Data;


namespace WebApplication1.Models
{
    public class HomeViewModel
    {
        public Variant? Variant { get; set; }

        public List<Variant> Variants { get; set; }
        
    }
}
