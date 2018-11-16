using ProjectColumbus.Cards;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace ProjectColumbus
{
    class CardGenerator
    {
        // Card generation by location, meaning all cards will be platinum      
        public void CreateCardByPlaceMark(Placemark placemark)
        {
            var type = "platinum"; //TODO check spelling
            var area = placemark.AdminArea;
            var country = placemark.CountryName;
            var countryCode = placemark.CountryCode;
            var city = placemark.Locality; //TODO something with this?

            var countryCard = new CountryCard(type, country, countryCode);
            App.Database.InsertCardIfNeeded(countryCard);
            var areaCard = new AreaCard(type, area, countryCode);
            App.Database.InsertCardIfNeeded(areaCard);
            //Try to add to DB
            //TODO create "you just received this card!"-message
        }
    }
}
