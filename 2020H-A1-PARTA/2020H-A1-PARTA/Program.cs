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
                        stringReturn = stringReturn + "WW";
                    }
                    else
                    {
                        //if it has value of -1 and is not white
                        stringReturn = stringReturn + "BB";
                    }
                }
                else

                {
                    //if square has number
                    stringReturn = stringReturn + Number.ToString("D2");
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
            private string acrossClues = "";
            private string downClues = "";
            //constructor for puzzle
            public Puzzle(int length)
            {
                //creating new array with demensions specified
                puzzle = new Square[length, length];

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

                //declares two ints for holding rand values
                int ranX, ranY;
                //if the black count requested is less than total squares in puzzle
                if (blackCount <= puzzle.Length)
                {
                    for (int i = 0; i < blackAmount;)
                    {
                        //for each black square requested 
                        ranX = rand.Next(0, length);
                        ranY = rand.Next(0, length);
                        //if the square at the randome location is white
                        if (puzzle[ranX, ranY].Color == TColor.WHITE)
                        {
                            //add 1 to i to increase for loop
                            i++;
                            //make that square black
                            puzzle[ranX, ranY].Color = TColor.BLACK;
                        }
                    }
                }
                else
                {
                    //if there are more black squares requested than possible
                    //*** SHOULD BE EXCEPTION
                    Console.WriteLine("To many black squares requested");
                }
            }
            public void Number()
            {
                //init clue counter int
                int clueNumber = 1;
                //loop through puzzle
                for (int i = 0; i < this.length; i++)
                {
                    for (int j = 0; j < this.length; j++)
                    {
                        //if current square in loop is white
                        if (puzzle[j, i].Color == TColor.WHITE)
                        {
                            //across logic
                            //checks if square is starting at an across boudary 
                            if (j - 1 >= 0)
                            {
                                //if its not at a boundary
                                //checks if previous across square is black
                                if (puzzle[j - 1, i].Color == TColor.BLACK)
                                {
                                    //if previous square is black
                                    //check to make sure next square is not boundary
                                    if (j + 1 < length)
                                    {
                                        //if next square is not a boundary
                                        //check to make sure next across square is white and not black
                                        if (puzzle[j + 1, i].Color == TColor.WHITE)
                                        {
                                            //if next square is white
                                            //add clue number to current square
                                            puzzle[j, i].Number = clueNumber;
                                            //add clue to string of across clues
                                            acrossClues = acrossClues + clueNumber + " Across\n";
                                            //add 1 to clue counter
                                            clueNumber++;

                                        }
                                    }
                                }
                            }
                            //square is white and starting at across boundary
                            else
                            {
                                //check to see if next square is also a boundary
                                if (j + 1 <= length)
                                {
                                    //if next square isnt a boundary
                                    //check to make sure next square is white
                                    if (puzzle[j + 1, i].Color == TColor.WHITE)
                                    {
                                        //if it is white add clue number to currenet puzzle
                                        puzzle[j, i].Number = clueNumber;
                                        //add across clue to across clue string
                                        acrossClues = acrossClues + clueNumber + " Across\n";
                                        //add to clue count
                                        clueNumber++;
                                    }
                                }
                            }
                            //down logic
                            //check to see if square above is boundary
                            if (i - 1 >= 0)
                            {
                                //if not a boundary check to see if the square above is black
                                if (puzzle[j, i - 1].Color == TColor.BLACK)
                                {
                                    //if it is black
                                    //check to see if square below is a boundary
                                    if (i + 1 < length)
                                    {
                                        //if square below was not a boundary
                                        //check to make sure next square is white
                                        if (puzzle[j, i + 1].Color == TColor.WHITE)
                                        {
                                            //if next down square is white
                                            //check to see if current square allready has clue number assigned from across clues
                                            if (puzzle[j, i].Number == -1)
                                            {
                                                //if the square has not allready been assigned clue
                                                //add clue number to square
                                                puzzle[j, i].Number = clueNumber;
                                                //add it to downclues string and add one to clue count
                                                downClues = downClues + clueNumber + " Down\n";
                                                clueNumber++;
                                            }
                                            else
                                            {
                                                //if square was allready assigned across clue
                                                //add it to down clues without assigning new clue number
                                                downClues = downClues + puzzle[j, i].Number + " Down\n";
                                            }
                                        }
                                    }
                                }
                            }
                            //if square above is a boundary
                            else
                            {
                                //check to make sure next square down is not boundary
                                if (i + 1 < length)
                                {
                                    //check to make sure next square down is white
                                    if (puzzle[j, i + 1].Color == TColor.WHITE)
                                    {
                                        //if next sqaure down is not boundary and is white
                                        //check to see if current square has allready been assigned across clue
                                        if (puzzle[j, i].Number == -1)
                                        {
                                            //if it has not been assigned a clue
                                            //add clue number to square
                                            puzzle[j, i].Number = clueNumber;
                                            //add it to down clues string
                                            downClues = downClues + clueNumber + " Down\n";
                                            //add 1 to clue count
                                            clueNumber++;
                                        }
                                        else
                                        {
                                            //if was allready assigned across clue then add it to clue string but not a new clue number
                                            downClues = downClues + puzzle[j, i].Number + " Down\n";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            public bool Symmetrical()
            {
                int lengthCountX = length-1;
                int lengthCountY = length - 1;
                for(int i = 0; i < length; i++)
                {
                    for(int j = 0; j < length/2; j++)
                    {
                        if (puzzle[j, i].Color != puzzle[lengthCountX, lengthCountY].Color)
                        {
                            return false;
                        }
                        lengthCountX--;
                    }
                    lengthCountY--;
                    lengthCountX = length-1;
                }
                return true;
            }
            public void PrintClues()
            {
                Console.WriteLine(acrossClues + downClues);
            }
            public void PrintGrid()
            {
                string line = "";
                for (int i = 0; i < this.length; i++)
                 {
                    line = "";
                    for (int j = 0; j < this.length; j++)
                    {
                        //add each square to write line
                        line = line + this.puzzle[j, i].ToString() + " ";
                    }
                    //print that line
                    Console.WriteLine(line);                                     
                }
            }
            //function to print puzzle
            public override string ToString()
            {
                string returnString = "";
                for (int i = 0; i < this.length; i++)
                {
                    for (int j = 0; j < this.length/2; j++)
                    {
                        //add each square to write line
                        returnString = returnString + this.puzzle[j, i].ToString() + " ";
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
            Puzzle puz = new Puzzle(6);
            //initializing 8 black squares
            puz.Initialize(8);
            //print puzzle
            //Console.WriteLine( puz.ToString());
            puz.Number();
            puz.PrintGrid();
            //Console.WriteLine(puz.ToString());
            puz.PrintClues();
            Console.WriteLine(puz.Symmetrical());
            //program pause to read output
            Console.ReadKey();
        }
    }
}
