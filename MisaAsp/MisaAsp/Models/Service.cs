using System.ComponentModel.DataAnnotations;

namespace MisaAsp.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Price { get; set; }
        public string Logo { get; set; }
    }
}
