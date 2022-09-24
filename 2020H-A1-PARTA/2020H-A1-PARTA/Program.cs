using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020H_A1_PARTA
{
    internal class Program
    {
        //holds two constants WHITE and BLACK
        public enum TColor {WHITE, BLACK};
        public class Square
        {
            //string to hold Tostring return
            private string stringReturn = "";
            
            //get and sets for Color and Number
            public TColor Color { get; set; }
            public int Number { set; get; }
            
            //default Constructor
            public Square() 
            {
                //sets color to white and number to -1 by default
                Color = TColor.WHITE;
                Number = -1;
            }
            //returns a string of square details
            public override string ToString()
            {
                //reset return string
                stringReturn = "";
                

                if(Number == -1)
                {
                    //if square is set to white and has value of -1
                    if(Color == TColor.WHITE)
                    {
                        stringReturn = stringReturn + "W";
                    }
                    else
                    {
                        //if it has value of -1 and is not white
                        stringReturn = stringReturn + "B";
                    }

                }
                else
                {
                    //if square has number
                    stringReturn = stringReturn + Number;
                }
                return stringReturn;
            }


        }
            public class Puzzle
        {
            //actual 2d array that holds the squares
            private Square[,] puzzle;
            //length demesions
            private int length;
            //creating rand varible for the random black square generation
            private Random rand = new Random();
            //amount of black squares requested for this puzzle
            public int blackAmount;

            //testing varible to see how many black squares where requested vs init
            private int testAmount = 0;
            
            
            //method to randomly determine whether square should be black
            private int WhiteOrBlack()
            {            
                //***THIS METHOD NEEDS WORK STILL GETTING REQUESTED / INIT BLACK SQUARE MISMATCHES***
                //getting random number between 0 and 100000
                int random = rand.Next(0, 100000);

                //calculating what chance each square has to be black
                double blackPercent = (double)blackAmount / (double)puzzle.Length * 100000 ;
                
                //if random number generated is less than the chance to be black
                if (random < blackPercent)
                {
                    //add 1 to test amount and return 1 signifing that that square is black
                    testAmount++;
                    return 1;
                }
                else
                {
                    //return 0 which stands for white
                    return 0;
                }
            }

            //constructor for puzzle
            public Puzzle(int length)
            {
                //creating new array with demensions specified
                puzzle = new Square[length,length];

                //setting class lenght = to length
                this.length = length;
                //adding a default white square to each array slot
                for (int i = 0; i < this.length; i++)
                {
                    for (int j = 0; j < this.length; j++)
                    {
                        puzzle[j, i] = new Square();
                    }
                   
                }
            }
            //adds black squares to puzzle
            public void Initialize(int blackCount)
            {
                //get amount to blacks requested
                this.blackAmount = blackCount;
                //loop through puzzle
                for (int i = 0; i < this.length; i++)
                {
                    for (int j = 0; j < this.length; j++)
                    {
                        //if the blackCount = 0 dont add anymore black squares and break
                        if(blackCount == 0)
                        {
                            break;
                        }
                        else
                        {
                            //if WhiteorBlack method returens 1 set current square to black
                            if (WhiteOrBlack() == 1)
                            {
                                puzzle[i, j].Color = TColor.BLACK;
                                //-1 from black count
                                blackCount--;
                            }
                        }   
                    }

                }
            }
            //function to print puzzle
            //***HEIN SIGHT THIS SHOULD BE A TOSTRING() OVERIDE NOT A VOID
            public void printPuzzle()
            {
                //creat string line write var
                string line = "";
                //loop through puzzle
                for(int i = 0; i< this.length; i++)
                {
                    for(int j = 0; j < this.length; j++)
                    {
                        //add each square to write line
                        line = line+this.puzzle[j,i].ToString();
                    }
                    //print that line
                    Console.WriteLine(line);
                    //reset line varible
                    line = "";
                }
                //testing print to see if black req == init
                Console.WriteLine("Black Squares Requested = " + this.blackAmount + " Black Squres Initilized = " +this.testAmount);

            }
        }
        static void Main(string[] args)
        {
            //creating a new 6x6 puzzle
            Puzzle puz = new Puzzle(6);
            //initializing 8 black squares
            puz.Initialize(8);
            //print puzzle
            puz.printPuzzle();
            //program pause to read output
            Console.ReadKey();
        }
    }
}
