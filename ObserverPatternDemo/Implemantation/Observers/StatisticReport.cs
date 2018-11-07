using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    /// <summary>
    /// Class observer. Displays weather information to console in this case.
    /// Also can store or process this information.
    /// </summary>
    public class StatisticReport
    {
        /// <summary>
        /// Register new listener.
        /// </summary>
        /// <param name="weatherProvider">Provider of weather.</param>
        public void Register(WeatherData weatherProvider)
            => weatherProvider.NewWeather += Update;

        /// <summary>
        /// Unregister new listener.
        /// </summary>
        /// <param name="weatherProvider">Provider of weather.</param>
        public void Unregister(WeatherData weatherProvider)
            => weatherProvider.NewWeather -= Update;

        /// <summary>
        /// Update information from observable.
        /// </summary>
        /// <param name="sender">Sender (observable).</param>
        /// <param name="info">Weather information.</param>
        public void Update(object sender, WeatherInfo info)
        {
            if (ReferenceEquals(info, null))
                return;

            Console.WriteLine(info.Temperature > 0?"Temperature above zero":"Temperature below zero");
        }
    }
}
