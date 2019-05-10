using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightTour
{
    public class Choices
    {
        int randomer = 0;
        int randomers = 0;
        public void intelligent(int a, int b)
        {
            int numOfMoves = 1;

           

            int[,] intelliBoard = {
                { -2,-3,-4,-4,-4,-4,-3,-2 },{ -3,-4,-6,-6,-6,-6,-4,-3 },{ -4,-6,-8,-8,-8,-8,-6,-4 },
                   { -4,-6,-8,-8,-8,-8,-6,-4 },{ -4,-6,-8,-8,-8,-8,-6,-4 },{ -4,-6,-8,-8,-8,-8,-6,-4 },{ -3,-4,-6,-6,-6,-6,-4,-3 },
                { -2,-3,-4,-4,-4,-4,-3,-2 }
            };//Making a game board of  8x8 of int with - ve values in it


            Knight intelliKnight = new Knight(a, b); //change the parameters of the intelli gent method and non intelli so that theyit will go as the user said
            intelliBoard[intelliKnight.a, intelliKnight.b] = numOfMoves;


            int move = 0;

            do
            {

                string[] knightMoves = goodMovesIntelli(convertListToString(intelliKnight.a, intelliKnight.b), intelliBoard);
                move = knightMoves.Length;


                if (knightMoves[0] == "")
                {

                    move = 0;
                    break;
                }


                if (move == 1)
                {

                    int first = (int)Char.GetNumericValue(knightMoves[0][0]);
                    int second = (int)Char.GetNumericValue(knightMoves[0][1]);

                    intelliKnight.a = first;
                    intelliKnight.b = second;

                    numOfMoves++;

                    intelliBoard[intelliKnight.a, intelliKnight.b] = numOfMoves;


                }
                else
                {

                    Random rnd = new Random();

                    int random = rnd.Next(0, knightMoves.Length); //random number is generated

                   

                    while (randomer == random)
                    {
                        random = rnd.Next(0, knightMoves.Length);
                    }

                    randomer = random;

                    int first = (int)Char.GetNumericValue(knightMoves[random][0]);
                    int second = (int)Char.GetNumericValue(knightMoves[random][1]);

                    intelliKnight.a = first;
                    intelliKnight.b = second;

                    numOfMoves++;

                    intelliBoard[intelliKnight.a, intelliKnight.b] = numOfMoves;
                }
            } while (move > 0);

            Console.WriteLine(numOfMoves + "these are the moves");
            //used to print the multi dimensional array
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(intelliBoard[i, j] + "   ");
                }
                Console.WriteLine();
            }
        }

        public void nonIntelligent(int a, int b)
        {
            int numOfMoves = 1;
            int[,] nonIntelliBoard = new int[8, 8]; //Making a game board of  8x8 of int


            Knight nonIntelliKnight = new Knight(a, b); //change the parameters of the intelligent method and non intelli so that theyit will go as the user said
            nonIntelliBoard[nonIntelliKnight.a, nonIntelliKnight.b] = numOfMoves;



            int move = 0;

            do
            {

                string[] knightMoves = goodMovesNonIntelli(convertListToString(nonIntelliKnight.a, nonIntelliKnight.b), nonIntelliBoard);

                move = knightMoves.Length;


                if (knightMoves[0] == "")
                {

                    move = 0;
                    break;
                }


                if (move == 1)
                {

                    int first = (int)Char.GetNumericValue(knightMoves[0][0]);
                    int second = (int)Char.GetNumericValue(knightMoves[0][1]);

                    nonIntelliKnight.a = first;
                    nonIntelliKnight.b = second;

                    numOfMoves++;

                    nonIntelliBoard[nonIntelliKnight.a, nonIntelliKnight.b] = numOfMoves;


                }
                else
                {

                    Random rnd = new Random();

                    int random = rnd.Next(0, knightMoves.Length); //random number is generated

                    while (randomers == random)
                    {
                        random = rnd.Next(0, knightMoves.Length);
                    }

                    randomers = random;



                    int first = (int)Char.GetNumericValue(knightMoves[random][0]);
                    int second = (int)Char.GetNumericValue(knightMoves[random][1]);

                    nonIntelliKnight.a = first;
                    nonIntelliKnight.b = second;

                    numOfMoves++;

                    nonIntelliBoard[nonIntelliKnight.a, nonIntelliKnight.b] = numOfMoves;
                }


                
            } while (move > 0);

            Console.WriteLine(numOfMoves + "these are the moves");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(nonIntelliBoard[i, j] + "   ");
                }
                Console.WriteLine();
            }



        }



        public List<string> stepsOfKnight(int pos1, int pos2) // it will be the common logic for both of the methods
                                                              //method returns the moves of knight in list
        {
            int number1 = 0;
            int number2 = 0;
            string s;

            List<string> moves = new List<string>();



            if (pos1 - 2 >= 0)
            {
                number1 = (pos1 - 2);
                if ((pos2 - 1) >= 0)
                {
                    number2 = (pos2 - 1);
                    s = Convert.ToString(number1) + Convert.ToString(number2);

                    moves.Add(s);

                }
                if ((pos2 + 1) <= 7)
                {
                    number2 = (pos2 + 1);
                    s = Convert.ToString(number1) + Convert.ToString(number2);
                    moves.Add(s);

                }
            }
            if (pos1 + 2 <= 7)
            {
                number1 = (pos1 + 2);
                if ((pos2 - 1) >= 0)
                {
                    number2 = (pos2 - 1);
                    s = Convert.ToString(number1) + Convert.ToString(number2);
                    moves.Add(s);

                }
                if ((pos2 + 1) <= 7)
                {
                    number2 = (pos2 + 1);
                    s = Convert.ToString(number1) + Convert.ToString(number2);
                    moves.Add(s);

                }
            }
            if (pos2 - 2 >= 0)
            {
                number1 = (pos2 - 2);
                if ((pos1 - 1) >= 0)
                {
                    number2 = (pos1 - 1);
                    s = Convert.ToString(number2) + Convert.ToString(number1);
                    moves.Add(s);

                }
                if ((pos1 + 1) <= 7)
                {
                    number2 = (pos1 + 1);
                    s = Convert.ToString(number2) + Convert.ToString(number1);
                    moves.Add(s);

                }
            }
            if (pos2 + 2 <= 7)
            {
                number1 = (pos2 + 2);
                if ((pos1 - 1) >= 0)
                {
                    number2 = (pos1 - 1);
                    s = Convert.ToString(number2) + Convert.ToString(number1);
                    moves.Add(s);

                }
                if ((pos1 + 1) <= 7)
                {
                    number2 = (pos1 + 1);
                    s = Convert.ToString(number2) + Convert.ToString(number1);
                    moves.Add(s);

                }
            }



            return moves;
        }

        public string[] convertListToString(int pos1, int pos2)
        {
            List<string> moves = stepsOfKnight(pos1, pos2); //need to be changed



            string transfer = string.Join(",", moves.ToArray());

            string[] knightMoves = transfer.Split(',');

            return knightMoves; //return all the moves than knight can make
        }


        public string[] goodMovesNonIntelli(string[] gMove, int[,] board)
        {
            List<string> moves = new List<string>();
            int first = 0;
            int second = 0;

            for (int i = 0; i < gMove.Length; i++)
            {
                first = (int)Char.GetNumericValue(gMove[i][0]);
                second = (int)Char.GetNumericValue(gMove[i][1]);

                if (board[first, second] == 0)
                {
                    moves.Add(Convert.ToString(gMove[i][0]) + Convert.ToString(gMove[i][1]));
                }



            }
            string transfer = string.Join(",", moves.ToArray());




            string[] knightGoodMoves = transfer.Split(',');///////////////

            return knightGoodMoves;
        }


        public string[] goodMovesIntelli(string[] gMove, int[,] board)
        {

            List<string> moves = new List<string>();
            int first = 0;
            int second = 0;
            int max = -9;
            int firstGMove = -1;
            int secondGMove = -1;

            for (int i = 0; i < gMove.Length; i++)
            {
                first = (int)Char.GetNumericValue(gMove[i][0]);
                second = (int)Char.GetNumericValue(gMove[i][1]);

                if (board[first, second] < 0)
                {
                    //  moves.Add(Convert.ToString(gMove[i][0])+ Convert.ToString(gMove[i][1]));
                    if (max < board[first, second])
                    {
                        max = board[first, second];
                        firstGMove = first;
                        secondGMove = second;
                        //    moves.Add(Convert.ToString(firstGMove)+ Convert.ToString(secondGMove));
                    }


                }

            }
            for (int i = 0; i < gMove.Length; i++)
            {
                first = (int)Char.GetNumericValue(gMove[i][0]);
                second = (int)Char.GetNumericValue(gMove[i][1]);
                if (max == board[first, second])
                {
                    moves.Add(Convert.ToString(first) + Convert.ToString(second));

                }

            }





            string transfer = string.Join(",", moves.ToArray());

            string[] knightGoodMoves = transfer.Split(',');///////////////

            return knightGoodMoves;

        }



    }
}
