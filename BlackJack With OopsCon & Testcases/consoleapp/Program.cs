using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace consoleapp
{
    public class Program
    {

        public class globalvariables
        {
            public string[] deck = Enumerable.Range(1, 10).Select(x => x.ToString()).ToArray();
            public Random r = new Random();

            public int youWon { get; set; }
            public int ComputerWon { get; set; }
            public string[] playersHand { get; set; }
            public string[] computershand { get; set; }

            public int playercard1 { get; set; }
            public int playercard2 { get; set; }
            public int playercardtotal { get; set; }

            public int computercard1 { get; set; }
            public int computercard2 { get; set; }
            public int computercardtotal { get; set; }

            public int dynamicplayerhandcard { get; set; }
            public int dynamicplayerhandcardtotal { get; set; }

            public int dynamicplayercomputercard { get; set; }
            public int dynamicplayercomputercardtotal { get; set; }
            public int dynamiccount = 2;
        }

        public class cardfn
        {
            public globalvariables globalvar = new globalvariables();

            public void shuffle()
            {
                globalvar.deck = globalvar.deck.OrderBy(x => globalvar.r.NextDouble()).ToArray();
            }

            public string[] deal(int count)
            {
                string[] a = globalvar.deck.Take(count).ToArray();
                globalvar.deck = globalvar.deck.Except(a).ToArray();
                return a;
            }

            public void continuecardpickup()
            {
                Console.WriteLine("Do you want another card (y/n)?");
                globalvar.dynamiccount++;
                if (globalvar.dynamiccount >= 10)
                {
                    globalvar.dynamiccount = 0;
                }
                if (Console.ReadLine().ToLower() == "y")
                {
                    globalvar.dynamicplayerhandcard = Convert.ToInt32(globalvar.playersHand[globalvar.dynamiccount]);
                    globalvar.dynamicplayerhandcardtotal += globalvar.dynamicplayerhandcard;
                    Console.WriteLine("Card: " + globalvar.dynamicplayerhandcard + " Your total is " + globalvar.dynamicplayerhandcardtotal);
                    continuecardpickup();
                }
                else
                {
                    computerdynamicpickupcardfn();
                }

            }

            public void computerdynamicpickupcardfn()
            {
                globalvar.dynamicplayercomputercard = Convert.ToInt32(globalvar.computershand[globalvar.dynamiccount]);
                globalvar.dynamicplayercomputercardtotal += globalvar.dynamicplayercomputercard;
                Console.WriteLine("The computer takes a card: " + globalvar.dynamicplayercomputercard);
                if (globalvar.dynamicplayercomputercardtotal < 17)
                {
                    computerdynamicpickupcardfn();
                }
                else
                {
                    Console.WriteLine("Your score: " + globalvar.dynamicplayerhandcardtotal);
                    Console.WriteLine("Computer score: " + globalvar.dynamicplayercomputercardtotal);
                    if ((globalvar.dynamicplayerhandcard < 21 && globalvar.dynamicplayerhandcard > globalvar.dynamicplayercomputercardtotal) || (globalvar.dynamicplayercomputercardtotal > 21 && globalvar.dynamicplayercomputercardtotal > globalvar.dynamicplayerhandcard))
                    {
                        Console.WriteLine("You Won!");
                    }
                    else
                    {
                        Console.WriteLine("Computer Won!");
                    }
                    Console.ReadLine();
                }

            }
        }
        public class cardfninherit : cardfn
        {
            static void Main(string[] args)
            {

                cardfninherit cardfnobj = new cardfninherit();
                cardfnobj.shuffle();
                globalvariables globalvar = cardfnobj.globalvar;
                globalvar.playersHand = cardfnobj.deal(2);
                globalvar.playersHand = cardfnobj.deal(2);
                globalvar.computershand = cardfnobj.deal(2);
                globalvar.playercard1 = Convert.ToInt32(globalvar.playersHand[0]);
                globalvar.playercard2 = Convert.ToInt32(globalvar.playersHand[1]);
                globalvar.playercardtotal = globalvar.playercard1 + globalvar.playercard2;
                Console.WriteLine("Your Cards: " + globalvar.playercard1 + " " + globalvar.playercard2 + "=" + globalvar.playercardtotal);

                globalvar.computercard1 = Convert.ToInt32(globalvar.computershand[0]);
                globalvar.computercard2 = Convert.ToInt32(globalvar.computershand[1]);
                globalvar.computercardtotal = globalvar.computercard1 + globalvar.computercard2;
                Console.WriteLine("Computers Cards : " + globalvar.computercard1 + " " + globalvar.computercard2 + "=" + globalvar.computercardtotal);
                globalvar.dynamicplayerhandcardtotal = globalvar.playercardtotal;
                globalvar.dynamicplayercomputercardtotal = globalvar.computercardtotal;

                globalvar.deck = Enumerable.Range(1, 10).Select(x => x.ToString()).ToArray();
                cardfnobj.shuffle();
                globalvar.playersHand = cardfnobj.deal(10);

                globalvar.deck = Enumerable.Range(1, 10).Select(x => x.ToString()).ToArray();
                cardfnobj.shuffle();
                globalvar.computershand = cardfnobj.deal(10);

                cardfnobj.continuecardpickup();
            }
        }



    }
}
