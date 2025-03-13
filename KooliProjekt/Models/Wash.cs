using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Models
{
    public class Wash
    {
        
        
            [Required]
            int Id { get; set; }
            public int CarId { get; set; }
            public int WorkerId { get; set; }
        }
}
