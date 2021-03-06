using Project.Models;
using Project.Services;
namespace Project.Builders
{

    public class HomeBuilder
    {
        public Home Build()
        {
            var weatherService = new WeatherService();
            var weather = weatherService.GetInitialWeather("22201");
            var newservice = new NewsService();
            var news = newservice.GetNews();

            var homeModel = new Home { Weather = weather.Result, News = news.Result };
            //this.AddImageIconPath(homeModel.Weather);

        
            return homeModel;
        }

        //public void AddImageIconPath(WeatherObject weather)
        //{
        //    "Resources/WeatherComponent/WeatherIcons/Sun.png"
        //    foreach (var item in weather.Hours)
        //    {
        //        if (item.WeatherIcon < 6)
        //        {
        //            item.IconImage = "Resources/WeatherComponent/WeatherIcons/Sun.png";
        //        }
        //        else if (item.WeatherIcon < 12)
        //        {
        //            item.IconImage = "Resources/WeatherComponent/WeatherIcons/Cloudy.png";
        //        }
        //        else if (item.WeatherIcon < 19)
        //        {
        //            item.IconImage = "Resources/WeatherComponent/WeatherIcons/Rain.png";
        //        }
        //        else if (item.WeatherIcon < 29)
        //        {
        //            item.IconImage = "Resources/WeatherComponent/WeatherIcons/Snow.png";
        //        }
        //        else
        //        {
        //            item.IconImage = "Resources/WeatherComponent/WeatherIcons/Night.png";
        //        }
        //        item.Hour = item.DateTime.ToString("h tt");
        //    }
        //}
    }
}