﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignYourHome.Models
{
    public class Style
    {
        [Key]
        public int StyleId { get; set; }

        [Required]
        public string Name { get; set; }

        public bool isSelected { get; set; }
    }
}