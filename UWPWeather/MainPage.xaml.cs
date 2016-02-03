using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPWeather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var position = await LocationManager.GetPosition();

        //    var lattitude= 58.3698;// position.Coordinate.Latitude;
        //    var longitude = 26.7612;// position.Coordinate.Longitude;

        //    //RootObject myWeather = await OpenWeatherMapProxy.GetWeather(20.0, 30.0);
        //    RootObject myWeather = 
        //        await OpenWeatherMapProxy.GetWeather(
        //            lattitude,
        //            longitude);

        //    //schedule update
            
        //    var uri = "http://uwplivetile.axtest.net/test01.xml";

        //    var tileContent = new Uri(uri);

        //    var requestedInterval = PeriodicUpdateRecurrence.HalfHour;

        //    var updater = TileUpdateManager.CreateTileUpdaterForApplication();
        //    updater.StartPeriodicUpdate(tileContent, requestedInterval);
            

        //    //string icon = String.Format("http://openweathermap.org/img/w/{0}.png", myWeather.weather[0].icon);
        //    string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);

        //    ResultTextBlock.Text = myWeather.name + ", " + ((int)myWeather.main.temp).ToString() + ", " + myWeather.weather[0].description;
        //    ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
        //}

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var position = await LocationManager.GetPosition();

                var lattitude = 58.3698;// position.Coordinate.Latitude;
                var longitude = 26.7612;// position.Coordinate.Longitude;

                //RootObject myWeather = await OpenWeatherMapProxy.GetWeather(20.0, 30.0);
                RootObject myWeather =
                    await OpenWeatherMapProxy.GetWeather(
                        lattitude,
                        longitude);

                //schedule update

                var uri = "http://uwplivetile.axtest.net/test01.xml";

                var tileContent = new Uri(uri);

                var requestedInterval = PeriodicUpdateRecurrence.HalfHour;

                var updater = TileUpdateManager.CreateTileUpdaterForApplication();
                updater.StartPeriodicUpdate(tileContent, requestedInterval);


                //string icon = String.Format("http://openweathermap.org/img/w/{0}.png", myWeather.weather[0].icon);
                string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);

                TempResultTextBlock.Text = ((int)myWeather.main.temp).ToString();
                DescriptionResultTextBlock.Text = myWeather.weather[0].description;
                LocationResultTextBlock.Text = myWeather.name;
                ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
            }

            catch
            {
                LocationResultTextBlock.Text = "No API connection!";
            }


            

        }
    }
}
