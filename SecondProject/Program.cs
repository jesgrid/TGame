using System;
using MapsAll;
using FramePainterAll;
using MovementAll;
using static SecondProject.Move;

namespace SecondProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            int xPlayer = 4000;
            int yPlayer = 4000;
            bool obstruction = false;
            Move move;
            string[,] field = new string[8000, 8000];
            string[,] fieldGhost = new string[8000, 8000];

            Maps.FieldGenerator(field);
            Array.Copy(field, fieldGhost, field.Length);
            Console.WriteLine(fieldGhost[xPlayer, yPlayer]);

            field[xPlayer, yPlayer] = "Ṽ";

            FramePainter.FieldPainter(xPlayer, yPlayer, field);
            
            do
            {
                
                cki = Console.ReadKey();
                switch (cki.Key.ToString())
                {
                    case "W" or "UpArrow":
                        move = moveUp;
                        (xPlayer, yPlayer) = Movement.PlayerMove(xPlayer, yPlayer, move, field, fieldGhost, obstruction);
                        break;
                    case "S" or "DownArrow":
                        move = moveDown;
                        (xPlayer, yPlayer) = Movement.PlayerMove(xPlayer, yPlayer, move, field, fieldGhost, obstruction);
                        break;
                    case "A" or "LeftArrow":
                        move = moveLeft;
                        (xPlayer, yPlayer) = Movement.PlayerMove(xPlayer, yPlayer, move, field, fieldGhost, obstruction);
                        break;
                    case "D" or "RightArrow":
                        move = moveRight;
                        (xPlayer, yPlayer) = Movement.PlayerMove(xPlayer, yPlayer, move, field, fieldGhost, obstruction);
                        break;
                    default:
                        Console.WriteLine("FKU!");
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape);
            return;
        }
    }
}
