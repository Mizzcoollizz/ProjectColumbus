using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectColumbus
{
    [Table("Cards")]
    class Card
    {
        [PrimaryKey]
        public string id { get; } //How to generate?
        public string imgName { get; }
        public string name { get; } //Country, area, city?
        public string type { get; } // platinum, gold, silver, bronze?

        //TODO add types? ways received?


    }
}
