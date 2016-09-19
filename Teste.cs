using System;
using System.Collections.Generic;

namespace TestApiNancy
{
    internal class Teste
    {
        public String Id { get; set; }

        public String AppId { get; set; }

        public String Name { get; set; }

        public String CustomDNS { get; set; }

        public Boolean ForceRedirect { get; set; }

        public Boolean GaEnabled { get; set; }

        public List<Feature> Features { get; set; }

        public List<String> PurchaseUrl { get; set; }
    }
}