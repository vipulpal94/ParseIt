using System;
using System.Collections.Generic;
using System.Linq;

namespace ParseIt
{
    class Program
    {
        static void Main(string[] args)
        {
            string testString1 = "1,2,3,5,8,131,21,34";


            List<string> test1 = ParseIt(testString1,3);

            if (test1.Count != 7)
                Console.WriteLine("Sorry Try again");

            if(test1[4] != "131")
                Console.WriteLine("Sorry Try again");


            string testString2 = "";
            List<string> test2 = ParseIt(testString2, 5);

            Console.WriteLine("You Win!");
        }

        /// <summary>
        /// write you test code here. 
        /// 
        /// You are to parse the string into pieces that are no more than "pieceLength" characters long
        /// INCLUDING the commas. 
        /// 
        /// If pieceLength = 3 the result for the above test string would be
        /// 
        /// result[0] = "1,2"
        /// result[1] = ",3,"
        /// result[2] = "5,8"
        /// result[3] = ","
        /// result[4] = "131"
        /// result[5] = ",21"
        /// result[6] = ",34"
        /// 
        /// You can look at the test above. This is a sample string and result, however
        /// your code will be run with multiple input strings and piece length parameters.
        /// Note how result[3] is just ",". Including any more characters would break apart 
        /// the next number, 131, and that's not allowed.
        ///  
        /// </summary>
        /// <param name="theString"></param>
        internal static List<string> ParseIt(string theString, int pieceLength)
        {
            List<string> rtVal = new List<string>();

            //To check if length of individual parsed number is greater than pieceLength (which should not be allowed in any case) 
            //Feel free to comment the below line and remove the Linq library call and run the code.
            theString.Split(',').ToList()
                .ForEach(f => {
                    if (f.Length > pieceLength)
                        throw new Exception("Single comma seperated value length is greater than pieceLength.");
                });

            for (int i = 0, j = pieceLength - 1; ;)
            {
                if (j >= theString.Length - 1)
                {
                    rtVal.Add(theString.Substring(i, theString.Length - i));
                    break;
                }
                if (Char.IsDigit(theString[j]) && Char.IsDigit(theString[j + 1])) j--;
                else
                {
                    rtVal.Add(theString.Substring(i, j - i + 1));
                    i = j + 1;
                    j = i + pieceLength - 1;
                }
            }

            return rtVal;
        }
    }
}
