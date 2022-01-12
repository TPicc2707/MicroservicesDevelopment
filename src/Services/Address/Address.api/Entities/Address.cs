﻿namespace Address.api.Entities
{
    public class Address
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

    }
}
