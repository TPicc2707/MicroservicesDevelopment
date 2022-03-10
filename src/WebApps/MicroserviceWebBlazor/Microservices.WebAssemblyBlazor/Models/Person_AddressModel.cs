﻿using System.ComponentModel.DataAnnotations;

namespace Microservices.WebAssemblyBlazor.Models
{
    public class Person_AddressModel
    {
        public int Id { get; set; }
        public int Person_Id { get; set; }
        public string Type { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [MaxLength(5, ErrorMessage = "Zip Code must be less than 5 digits")]
        public int ZipCode { get; set; }
        public PersonModel Person { get; set; }

    }
}
