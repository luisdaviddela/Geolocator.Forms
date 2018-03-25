using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Location_Dependency
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LocationPage : ContentPage
	{
        iMyLocation loc;
        public LocationPage ()
		{
			InitializeComponent ();
            
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            loc = DependencyService.Get<iMyLocation>();
            loc.locationObtained += (object sender,
                ILocationEventArgs e) => {
                    var lat = e.lat;
                    var lng = e.lng;
                    lblLat.Text = lat.ToString();
                    lblLng.Text = lng.ToString();
                };
            loc.ObtainMyLocation();
        }
    }
}