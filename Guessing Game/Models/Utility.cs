using Microsoft.AspNetCore.Http;

namespace Guessing_Game.Models
{
    public static class Utility
    {
        public static string temp_info { get; set; }
        
        public static string CheckTemp(int temp)
        {

            if (temp < 37 && temp > 35)  return temp_info = "You are healthy";
            else if (temp < 35 && temp > 32)  return temp_info = "You have hipotermia stadium 1 - mild";
            else if (temp < 32 && temp > 28)  return temp_info = "You have hipotermia stadium 2 - moderate";
            else if (temp < 28 && temp > 20)  return temp_info = "You have hipotermia stadium 3 - severe ";
            else if (temp < 20)  return temp_info = "You have hipotermia stadium 4 - profound ";
            else  return temp_info =  "You have fever";
            
        }

        public static string ConvertNumberToString(int number)
        {

            return number.ToString();
        }

        public static string CheckNumber(int number,string sessionNUmber)
        {
            int converted = int.Parse(sessionNUmber);

            if (number < converted) return "Too low";
            if (number > converted) return "Too high";
            
            else return "Correct";

        }
    }
}
