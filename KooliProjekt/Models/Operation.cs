using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Models
{
    public class Operation
    {
        
        
            [Required]
            int Id { get; set; }
            public int CarId { get; set; }
            public int WorkerId { get; set; }
        }
}
