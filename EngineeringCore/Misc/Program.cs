
namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //DuplicateChars(args[0].ToLower());
            if( IsPermutation("GOD", "dOG") )
                System.Console.WriteLine("It is a permutation");
            else
                System.Console.WriteLine("It is not a permutation");

        }

        public static bool DuplicateChars(string str)
        {
            bool[] charfound = new bool[26];
            int index = 0;
            
            if(str.Length > charfound.Length) 
                return true;

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

        public static bool IsPermutation(string first, string second)
        {
            if(first.Length != second.Length)
                return false;
            
            int firstcount = 0, secondcount = 0;
            //add the byte values of the two strings and compare. If the byte sum is equal they are permutations
            for(int i = 0; i < first.Length; i++)
            {
                firstcount += (byte)first[i];
                secondcount += (byte)second[i];
            }

            return firstcount == secondcount;
        }
    }
}
