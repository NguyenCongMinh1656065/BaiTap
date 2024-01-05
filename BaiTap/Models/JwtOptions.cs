﻿using System.ComponentModel.DataAnnotations;

namespace BaiTap.Models
{
    public class JwtOptions
    {
        [Key]
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpireHours { get; set; }
    }
}
