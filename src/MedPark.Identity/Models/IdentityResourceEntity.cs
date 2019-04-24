﻿using IdentityServer4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Identity.Models
{
    public class IdentityResourceEntity
    {
        public string IdentityResourceData { get; set; }

        [Key]
        public string IdentityResourceName { get; set; }

        [NotMapped]
        public IdentityResource IdentityResource { get; set; }

        public void AddDataToEntity()
        {
            IdentityResourceData = JsonConvert.SerializeObject(IdentityResource);
            IdentityResourceName = IdentityResource.Name;
        }

        public void MapDataFromEntity()
        {
            IdentityResource = JsonConvert.DeserializeObject<IdentityResource>(IdentityResourceData);
            IdentityResourceName = IdentityResource.Name;
        }
    }
}
