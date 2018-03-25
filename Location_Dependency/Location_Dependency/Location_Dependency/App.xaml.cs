using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Location_Dependency
{
	public partial class App : Application
	{
        Label lblLat, lblLng;
        iMyLocation loc;
        public App ()
		{
            //InitializeComponent();
            //MainPage = new Location_Dependency.LocationPage();
            var btn = new Button()
            {
                Text = "Visit on internet"
            };

            lblLat = new Label
            {
                XAlign = TextAlignment.Center,
                Text = "Lat",
            };
            lblLng = new Label
            {
                XAlign = TextAlignment.Center,
                Text = "Lng",
            };
            btn.Clicked += NewUri;
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            XAlign = TextAlignment.Center,
                            Text = "Current Live Location"
                        },
                        lblLat,
                        lblLng,
                        btn
                    }
                }
            };
        }
        private void NewUri(object sender, EventArgs e)
        {
            Visit(lblLat.Text, lblLng.Text);
        }
        public void Visit(string lat, string lng)
        {
            //string cadena = "";
            //string latitud = lat.Substring(0, 9);
            //string longitud = lng.Substring(0, 9);

            //string uniqueUri = "https://www.latlong.net/c/?lat=22.319462&long=-97.876029";
            //string notuniqueUri = "https://www.latlong.net/c/?lat="+latitud+"&long="+longitud;
            string unlessnotuniqueUri = "https://www.latlong.net/c/?lat=" + lat+ "&long=" + lng;
           

            string no = unlessnotuniqueUri.Replace(',', '.');
            try
            {
                Device.OpenUri(new Uri(no));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected override void OnStart ()
		{
            // Handle when your app starts
            //loc = DependencyService.Get<iMyLocation>();
            //loc.locationObtained += (object sender,
            //    ILocationEventArgs e) => {
            //        var lat = e.lat;
            //        var lng = e.lng;
            //        lblLat.Text = lat.ToString();
            //        lblLng.Text = lng.ToString();
            //    };
            //loc.ObtainMyLocation();
        }

		protected override void OnSleep ()
		{
            // Handle when your app sleeps
            loc = null;
        }
        
        protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
