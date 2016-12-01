
namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DuplicateChars(args[0].ToLower());
        }

        public static bool DuplicateChars(string str)
        {
            bool[] charfound = new bool[26];
            int index = 0;
            
            
            for(int i = 0; i < str.Length ; ++i)
            {
                index = (byte)(str[i]);
                index -= 97;
                if(charfound[index])
                    return true;
                else
                    charfound[index] = true;
            }  

            return false;
        }
    }
}
