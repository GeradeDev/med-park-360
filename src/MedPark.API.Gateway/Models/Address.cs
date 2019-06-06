﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public DateTime Modified { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public Int32 AddressType { get; set; }
        public string PostalCode { get; set; }
    }
}
