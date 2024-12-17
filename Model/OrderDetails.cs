using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EjemploEnClase.Model
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
            [Key]
            public int OrderID { get; set; }
            public int ProductID { get; set; }
        }
    }

    


