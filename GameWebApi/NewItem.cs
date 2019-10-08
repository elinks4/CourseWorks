using System;
using System.ComponentModel.DataAnnotations;

namespace GameWebApi
{
    public class NewItem
    {
        public string Name { get; set; }

        public Guid Id { get; set; }

        [Range(1, 99)]
        public int Level { get; set; }


        [Range(1, 3)]
        public ItemType _type { get; set; }


        [DateRange("01/01/2000")]
        public DateTime CreationTime { get; set; }

         public enum ItemType
        {

            SWORD = 1,
            POTION = 2,

            SHIELD = 3




        }


    }
}