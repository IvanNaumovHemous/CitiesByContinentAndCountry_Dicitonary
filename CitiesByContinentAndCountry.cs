using System;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCities = int.Parse(Console.ReadLine());
            var cities = GetContinentCountryAndCity(numberOfCities);
            PrintCities(cities);

        }

        static void PrintCities(Dictionary<string, Dictionary<string, List<string>>> cities)
        {
            foreach (var continent in cities)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.Write($"  {country.Key} -> ");
                    Console.WriteLine($"{string.Join(", ", country.Value)}");
                }
            }
        }

        static Dictionary<string, Dictionary<string, List<string>>> GetContinentCountryAndCity(int number)
        {
            string data = Console.ReadLine();
            var CitiesInCountryAndContinent = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < number; i++)
            {
                string[] input = data.Split(' ');
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!CitiesInCountryAndContinent.ContainsKey(continent))
                {
                    CitiesInCountryAndContinent.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!CitiesInCountryAndContinent[continent].ContainsKey(country))
                {
                    CitiesInCountryAndContinent[continent][country] = new List<string>();
                }

                CitiesInCountryAndContinent[continent][country].Add(city);
                data = Console.ReadLine();
            }

            return CitiesInCountryAndContinent;
        }
    }
}
