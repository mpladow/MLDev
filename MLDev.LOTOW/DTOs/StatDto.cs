using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLDev.LOTOW.DTOs
{
    public class StatDto
    {
        public int StatId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public bool IsFinite { get; set; }// if this stat has a set amount
    }
}
