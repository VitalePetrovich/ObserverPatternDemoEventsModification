using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData waetherStation = new WeatherData();
            CurrentConditionsReport conditionsReport = new CurrentConditionsReport();
            StatisticReport statisticReport = new StatisticReport();

            conditionsReport.Register(waetherStation);
            statisticReport.Register(waetherStation);
            statisticReport.Unregister(waetherStation);
           
            waetherStation.StartNotify();
        }
    }
}
