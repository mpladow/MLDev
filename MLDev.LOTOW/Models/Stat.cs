using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLDev.LOTOW.Models
{
    public class Stat
    {
        public int StatId { get; set; }
        public decimal Order { get; set; }
        public string Name { get; set; }
        public bool IsFinite { get; set; }// if this stat has a set ammount
    }
}
