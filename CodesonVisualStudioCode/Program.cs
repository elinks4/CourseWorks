using System;
using System.Threading.Tasks;
using CodesonVisualStudioCode;

namespace Codes_on_Visual_Studio_Code
{




    class Program
    {














        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(args[0]);

            string teststring;
            string townstring;


            Console.WriteLine("do you want offline or online = off/on");
            teststring = Console.ReadLine();

            if (teststring == "off")
            {


                Console.WriteLine("What street are you looking for: ");
                townstring = Console.ReadLine();

                OfflineCityBikeDataFetcher offline = new OfflineCityBikeDataFetcher();

                try
                {
                    Console.WriteLine(await offline.GetBikeCountInStation(townstring));

                }

                catch (NotFoundException e)
                {

                    Console.WriteLine("Not Found " + e.Message);



                }

            }

            if (teststring == "on")
            {
                Console.WriteLine("What street are you looking for: ");
                townstring = Console.ReadLine();
                RealTimeCityBikeDataFetcher realTime = new RealTimeCityBikeDataFetcher();
                try
                {
                    Console.WriteLine(await realTime.GetBikeCountInStation(townstring));
                }
                catch (NotFoundException e)
                {

                    Console.WriteLine("Not Found " + e.Message);



                }


            }
            if (teststring != "off" && teststring != "on")
            {

                Console.WriteLine("wrote something else");



            }



        }



    }




}

