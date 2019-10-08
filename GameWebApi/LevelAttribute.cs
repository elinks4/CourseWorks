using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GameWebApi
{
    public class LevelAttribute : ValidationAttribute
    {


        public override bool IsValid(object value)
        {

            int playerlevel = Convert.ToInt32(value);

            if (playerlevel >= 3)
            {

                return true;
            }
            else
            {
                return false;
            }


        }
    }



    class LevelException : System.Exception
    {
        public LevelException(string message) : base(message)
        {










        }
    }
}