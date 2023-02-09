using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLDev.LOTOW.Models
{
    public class Stat
    {
        public int StatId { get; set; }
        public decimal Order { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public bool IsMight { get; set; }
        public bool IsFate { get; set; }
    }
}
