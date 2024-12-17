using System.ComponentModel.DataAnnotations;

namespace EjemploEnClase.Model
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
