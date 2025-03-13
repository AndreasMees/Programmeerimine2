using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Data
{
    public class Operation
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }

        public Worker Worker { get; set; }
        public int WorkerId { get; set; }
    }
}
