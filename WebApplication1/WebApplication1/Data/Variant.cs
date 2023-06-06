using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication1.Data
{
    public class Variant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double d { get;set; }
        public double S1 { get; set; }
        public double S2 { get; set; }
        public double w { get; set; }
        public double t { get; set; }
    }
}
