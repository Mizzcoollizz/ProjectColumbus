using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectColumbus
{
    [Table("CountryCards")]
    public class CountryCard: Card
    {
        [PrimaryKey]
        public string id { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string name { get; set; }
        public string type { get; set; }

        public CountryCard() { } //Database constructor

        public CountryCard(string type, string country, string countryCode)
        {
            this.id = "c" + countryCode + type;
            this.type = type;
            this.country = country;
            this.countryCode = countryCode;
            this.name = country;
        }

        public string GetName()
        {
            return name;
        }

        public string GetId()
        {
            return id;
        }
    }
}
