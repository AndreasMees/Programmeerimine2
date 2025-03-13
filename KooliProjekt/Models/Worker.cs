using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Models
{
    public class Worker
    {
        
        
            [Required]
        int Id { get; set; }
            
        public int WorkerId { get; set; }

        public string WorkerName { get; set; }

        public string WorkerAge { get; set; }
    }
}
