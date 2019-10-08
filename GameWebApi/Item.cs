using System;
using System.ComponentModel.DataAnnotations;
using static GameWebApi.NewItem;

namespace GameWebApi
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


       
        public int Level { get; set; }

        public ItemType _type { get; set; }

     
        public DateTime CreationTime { get; set; }


    

        public Item() { }

       

    }

    public class DateRangeAttribute : RangeAttribute
    {

        public DateRangeAttribute(string minimum) : base(typeof(DateTime), minimum, DateTime.Now.ToShortDateString())
        {

        }


    }
}