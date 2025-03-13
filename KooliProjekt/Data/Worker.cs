using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Data
{
    public class Worker
    {
        public int Id { get; set; }

        public string WorkerName { get; set; }

        public string WorkerAge { get; set; }
    }
}
