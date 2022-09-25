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
                
                int ranX, ranY = rand.Next(0, length);

                for (int i = 0; i < blackAmount;)
                {
                    ranX = rand.Next(0, length);
                    ranY = rand.Next(0, length);
                    if (puzzle[ranX, ranY].Color == TColor.WHITE)
                    {
                        i++;
                        puzzle[ranX, ranY].Color = TColor.BLACK;
                        testAmount++;
                    }

                }
            }
            //function to print puzzle
            public override string ToString()
            {

                string returnString = "";
                for (int i = 0; i < this.length; i++)
                {
                    for (int j = 0; j < this.length; j++)
                    {
                        //add each square to write line
                        returnString = returnString + this.puzzle[j, i].ToString();
                    }
                    //print that line
                    returnString = returnString + "\n";
                    
                    
                }
                return returnString;
            }
        }
        static void Main(string[] args)
        {
            //creating a new 6x6 puzzle
            Puzzle puz = new Puzzle(100);
            //initializing 8 black squares
            puz.Initialize(200);
            //print puzzle
            Console.WriteLine( puz.ToString());
            //program pause to read output
            Console.ReadKey();
        }
    }
}
