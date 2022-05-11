namespace Guessing_Game.Models
{
    public static class Utility
    {
        public static string temp_info { get; set; }
        
        public static string CheckTemp(int temp)
        {

            if (temp < 37)  return temp_info = "You are healthy";
            else  return temp_info =  "You have fever";
            
        }

        public static string CheckNumber(int number)
        {

            return number.ToString();
        }
    }
}
