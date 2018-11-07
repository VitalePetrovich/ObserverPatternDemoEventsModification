using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData
    {
        public event EventHandler<WeatherInfo> NewWeather = delegate { }; 

        /// <summary>
        /// Start broadcasting.
        /// </summary>
        public void StartNotify()
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

            Random rnd = new Random();

            while (keyInfo.Key != ConsoleKey.Escape)
            {
                WeatherInfo weather = new WeatherInfo()
                {
                    Temperature = rnd.Next(-30, 35),
                    Humidity = rnd.Next(0, 99),
                    Pressure = rnd.Next(0, 999),
                };

                Console.Clear();
                OnNewWeather(this, weather);

                Thread.Sleep(500);
                if (Console.KeyAvailable)
                    keyInfo = Console.ReadKey();
            }
        }
        
        /// <summary>
        /// Notify observer about change of info.
        /// </summary>
        /// <param name="sender">Reference to sender.</param>
        /// <param name="info">Information.</param>
        protected virtual void OnNewWeather(object sender, WeatherInfo info)
        {
            if (ReferenceEquals(info, null))
                return;

            NewWeather(this, info);
        }
    }
}