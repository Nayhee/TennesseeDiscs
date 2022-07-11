﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TennesseeDiscs.Models
{
    public class DiscType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}