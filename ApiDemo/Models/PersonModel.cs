﻿using FluentValidation;
using System;

namespace ApiDemo.Models
{
    public class PersonModel
    {
        public int PersonID { get; set; }

        public string Name { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }
    }
}
