using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace ProjectColumbus
{
    public partial class MainPage : ContentPage
    {
        CardGenerator cardGenerator = new CardGenerator();
        public MainPage()
        {
            InitializeComponent();
            CheckLocationCard();

        }

        private async void CheckLocationCard()
        {
            var location = await GetLocationAsync();
            var placemarks = await Geocoding.GetPlacemarksAsync(location.Item1, location.Item2);
            var first = placemarks.First();
            cardGenerator.CreateCardByPlaceMark(first);
            var b = true;
        }

        private async Task<Tuple<double, double>> GetLocationAsync()
        {

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            if (!locator.IsGeolocationEnabled)
            {
                return null;
            }

            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(100));
            var lat = position.Latitude;
            var lon = position.Longitude;
            var adresses = (await locator.GetAddressesForPositionAsync(position)).FirstOrDefault();

            return new Tuple<double, double>(lat, lon);
        }

    }
}
