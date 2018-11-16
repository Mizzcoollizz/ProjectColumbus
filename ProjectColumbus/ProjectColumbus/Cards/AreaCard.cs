using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectColumbus.Cards
{
    [Table("AreaCards")]
    public class AreaCard: Card
    {
        [PrimaryKey]
        public string id { get; set; }
        public string area { get; set; }
        public string countryCode { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        //TODO how to link to country card?
        //TODO add attributes

        public AreaCard() { } //Constructor for database

        public AreaCard(string type, string area, string countryCode)
        {
            this.id = "a" + area + countryCode + type;
            this.type = type;
            this.area = area;
            this.countryCode = countryCode;
            this.name = area + ", " + countryCode;
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
