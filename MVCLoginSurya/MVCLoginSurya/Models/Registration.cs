﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLoginSurya.Models
{
    public class Registration
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string password { get; set; }
    }
}