using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{
    class Program
    {
        public static string[] Turn(string[] input, string line, string dir, int length)
        {
            int br = 0;
            if (line == "X")
                br = 1;
            else if (line == "Y")
                br = 2;
            else if (line == "Z")
                br = 3;
            int axis1 = Math.Min(br % 3, (br + 1) % 3);
            int axis2 = Math.Max(br % 3, (br + 1) % 3);

            if (dir == "-1")
            {
                string a = input[axis1];
                input[axis1] = Convert.ToString(length + 1 - Convert.ToInt32(input[axis2]));
                input[axis2] = a;
            }
            else
            {
                string a = input[axis2];
                input[axis2] = Convert.ToString(length + 1 - Convert.ToInt32(input[axis1]));
                input[axis1] = a;
            }
            return input;
            
        }
        static void Main()
        {
            StreamReader sr = File.OpenText(@"C:\Users\Матвей\OneDrive\Рабочий стол\input_s1_15.txt");
            string[] input1 = sr.ReadLine().Split(' ');
            string[] input2 = sr.ReadLine().Split(' ');
            for (int i = 0; i < Convert.ToInt32(input1[1]); i++)
            {
                string[] input3 = sr.ReadLine().Split(' ');
                if (((input3[0] == "X") && (input2[0] == input3[1])) || ((input3[0] == "Y") && (input2[1] == input3[1])) || ((input3[0] == "Z") && (input2[2] == input3[1])))
                {
                    input2 = Turn(input2, input3[0], input3[2], Convert.ToInt32(input1[0]));
                }
            }
            foreach (string i in input2)
            {
                Console.Write(i+" ");
            }

        }
    }
}

