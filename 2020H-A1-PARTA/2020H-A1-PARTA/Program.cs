using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020H_A1_PARTA
{
    internal class Program
    {
        public class Puzzle
        {
            private int[,] puzzle;
            private int length;
            private int height;
            private Random rand = new Random();
            private int WhiteOrBlack()
            {               
                int random = rand.Next(1, 8);
                if(random == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            public Puzzle(int length, int height)
            {
                puzzle = new int[length, height];

                this.length = length;
                this.height = height;
                for (int i = 0; i < this.height; i++)
                {
                    for (int j = 0; j < this.length; j++)
                    {
                        puzzle[j, i] = WhiteOrBlack();
                    }
                   
                }
            }

            public void printPuzzle()
            {
                string line = "";
                for(int i = 0; i< this.height; i++)
                {
                    for(int j = 0; j < this.length; j++)
                    {
                        line = line+this.puzzle[j,i];
                    }
                    Console.WriteLine(line);
                    line = "";
                }
                
            }
        }
        static void Main(string[] args)
        {
            Puzzle puz = new Puzzle(100, 6);
            puz.printPuzzle();

            Console.ReadKey();
        }
    }
}
