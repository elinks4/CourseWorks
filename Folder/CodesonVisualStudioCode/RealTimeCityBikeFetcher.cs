using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CodesonVisualStudioCode

{
    public class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
    {

        public async Task<int> GetBikeCountInStation(string stationName)
        {

            var stationNameCheck = stationName.Any(char.IsDigit);

            if (stationNameCheck)
            {

                throw new System.ArgumentException("Invalid argument:", stationName);
            }



            //  if(stationName ){



            //  }

            HttpClient client1 = new HttpClient();

            string test = await client1.GetStringAsync("http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental");


            bool wastherestation = false;


            BikeRentalStationList list = JsonConvert.DeserializeObject<BikeRentalStationList>(test);

            if (list != null)
            {

           //    Console.WriteLine("list is not null");
           //     Console.WriteLine(list.stations.Length);

                for (int i = 0; i < list.stations.Length; i++)
                {


                    if (list.stations[i].name == stationName)
                    {
                        wastherestation = true;
            //    Console.WriteLine(list.stations[i].bikesAvailable);

                        return list.stations[i].bikesAvailable;
                    }




                }

            }







            if (wastherestation == false)
            {

                throw new NotFoundException(stationName);

            }



            return 0;

        }

    }

    public class OfflineCityBikeDataFetcher : ICityBikeDataFetcher
    {

        static readonly string textFile = @"C:\Users\Admin\Desktop\CodesonVisualStudioCode\bikedata.txt";
        string[] lines = File.ReadAllLines(textFile);

        string s;

        string last;

        public Task<int> GetBikeCountInStation(string stationName)
        {

           

            foreach (string line in lines)
            {

                if (line.StartsWith(stationName))
                {

                    s = line;

                    last = line.Split(' ').Last();

                    // return <int>last;

                }


            }


            if (Int32.TryParse(last, out int j))
            {

                Console.WriteLine(stationName, " has ", j);

           //     Console.WriteLine(j);
                return Task.FromResult(j);

            }
            else
            { Console.WriteLine("String could not be parsed."); }
            throw new System.ArgumentException(" ");




        }


    }


    //   public [System.Serializable]
    class NotFoundException : System.Exception
    {
        public NotFoundException(string message) : base(message)
        {










        }
    }


    public interface ICityBikeDataFetcher
    {


        Task<int> GetBikeCountInStation(string stationName);








    }








}