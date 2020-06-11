using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maria5._5
{
    public class Airbus
    {
        public string Brand { get; set; }
        public int Id { get; set; }
        public int[] Numberoftrip { get; set; } 

        public Airbus(string brand, int id, int [] number)
        {
            Brand = brand;
            Id = id;
            Numberoftrip = number;
        }
    }

    public class Airport
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Airport(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
    static public class Request
    {
        static public int Counter(this Airbus airbuscurlist)
        {
            int sum = 0;
            foreach (int i in airbuscurlist.Numberoftrip)
           {
               sum += i;
            }
            return sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Airbus> airbuslist = new List<Airbus>() { new Airbus("airbus1", 1, new int[5] { 1,2,4,5,6}), new Airbus("airbus2", 2, new int[5] { 1, 2, 0, 5, 0 }), new Airbus("airbus3", 3, new int[5] { 0, 2, 0, 5, 6 }), new Airbus("airbus4", 4, new int[5] { 1, 0, 4, 5, 6 }), new Airbus("airbus5", 1, new int[5] { 11, 2, 4, 5, 6 }) };
            List<Airport> airportslist = new List<Airport>() { new Airport("Airport2", 1), new Airport("Airport1", 2), new Airport("Airport3", 3), new Airport("Airport4", 4), new Airport("Airport5", 5) };

            var orderForAirportbyname = from al in airbuslist
                                  join airl in airportslist
                                  on al.Id equals airl.Id
                                  orderby airl.Name
                                  select new
                                  {
                                      airl.Name,
                                      al.Brand
                                  };

           // foreach (var item in orderForAirportbyname)
            //    Console.WriteLine(item);

            var groupForAirport = from airl in airportslist
                                  group airl by airl.Name into a
                                  join al in airbuslist on a.FirstOrDefault().Id equals al.Id
                                  orderby al.Counter()
                                  select new {
                                      a.FirstOrDefault().Name,
                                      a.FirstOrDefault().Id,
                                      al.Brand,
                                      Coun = al.Counter()
                                  };

            //.GroupBy(airl => new {airl.Name })
            //.Select(g => g.OrderBy(al => al.Numberoftrip.Counter()))

            foreach (var item in groupForAirport)
                Console.WriteLine(item);


            Console.ReadKey();
        }
    }
}
