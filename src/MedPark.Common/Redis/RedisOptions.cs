using System;
using System.Collections.Generic;
using System.Text;

namespace MedPark.Common.Redis
{
    public class RedisOptions
    {
        public bool Enabled { get; set; }
        public string ConnectionString { get; set; }
        public string Instance { get; set; }
    }
}
