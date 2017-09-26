using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame
{
    class Program
    {
        public static int User;
        public static int Computer;
        private int randomnumber(int min, int max)
        {
            Random rnum = new Random();
            return rnum.Next(min, max);
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Game starts. Now Your turn");
            for (int i = 1; i <= 2; i++)
            {
                User = User + p.randomnumber(1, 7);
            }

            Console.WriteLine("Your intial two  cards total is " + User);

            for (int i = 1; i <= 21; i++)
            {
                Console.WriteLine("Do you want to continue? Y/N");
                char c = Char.Parse(Console.ReadLine().ToLower());
                if (c == 'y')
                {
                    int a = p.randomnumber(1, 13);
                    Console.WriteLine("Your card is " + a);
                    User = User + a;
                    Console.WriteLine("Your total now is" + User);
                    if (User > 21)
                    {
                        break;
                    }
                }
                else
                    break;
            }

            Console.WriteLine("Now its chance for Computer");
            for (int j = 1; j <= 21; j++)
            {
                int a = p.randomnumber(1, 13);
                Computer = Computer + a;
                if (Computer >= 21)
                {
                    break;
                }
            }
            Console.WriteLine("Result: ");
            if (User == Computer)
            {
                Console.WriteLine("\t"+ "\t" + "\t" + "\t" + "\t" + "Game was draw");
            }
            else if (User > 21 && Computer > 21)
            {
                Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "No one Won the game");
            }
            else if (User <= 21 && Computer <= 21)
            {
                if (User > Computer)
                {
                    Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "You won the game");
                }
                else
                {
                    Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "You lose the game");
                }
            }
            else
            {
                if (User < Computer)
                {
                    Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "You won the game");
                }
                else
                {
                    Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "You lose the game");
                }
            }
            Console.WriteLine("Your score is " + User);
            Console.WriteLine("Computer Score is " + Computer);
            Console.ReadLine();
        }
    }
}

