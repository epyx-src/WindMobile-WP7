using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Devices.Geolocation;

namespace Ch.Epyx.WindMobile.WP8.Service
{
    public class WPLocationService : Core.Service.ILocationService
    {
        public async Task<Core.Model.Location> GetCurrentLocation()
        {
            if ((bool)IsolatedStorageSettings.ApplicationSettings["LocationConsent"] != true)
            {
                // The user has opted out of Location.
                return null;
            }

            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10)
                    );

                return new Core.Model.Location()
                {
                    Latitude = geoposition.Coordinate.Latitude,
                    Longitude = geoposition.Coordinate.Longitude
                };
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show("Unable to get location. " + ex.GetType().FullName + ": " + ex.Message);
#endif

                return null;
            }

        }
    }
}
