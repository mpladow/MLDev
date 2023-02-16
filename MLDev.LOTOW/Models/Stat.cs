﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLDev.LOTOW.Models
{
    [Table("Stat", Schema = "LOTOW")]

    public class Stat
    {
        public int StatId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public bool IsFinite { get; set; }// if this stat has a set amount
    }
}
