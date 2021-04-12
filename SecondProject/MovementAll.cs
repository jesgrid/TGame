using System;
using FramePainterAll;
using static SecondProject.Move;

namespace MovementAll
{
    public class Movement
    {
        public static (int, int) PlayerMove(int xPlayer, int yPlayer, SecondProject.Move move , string[,] field, string[,] fieldGhost, bool obstruction)
        {
            Console.Clear();
            field[xPlayer, yPlayer] = fieldGhost[xPlayer, yPlayer];


            switch (move)
            {
                case moveUp:
                    yPlayer -= 1;
                    break;
                case moveDown:
                    yPlayer += 1;
                    break;
                case moveLeft:
                    xPlayer -= 1;
                    break;
                case moveRight:
                    xPlayer += 1;
                    break;
            }


            if (field[xPlayer, yPlayer] == "█")
            {
                switch (move)
                {
                    case moveUp:
                        yPlayer += 1;
                        break;
                    case moveDown:
                        yPlayer -= 1;
                        break;
                    case moveLeft:
                        xPlayer += 1;
                        break;
                    case moveRight:
                        xPlayer -= 1;
                        break;
                }
            }


            field[xPlayer, yPlayer] = "Ṽ";
            FramePainter.FieldPainter(xPlayer, yPlayer, field);
            return (xPlayer, yPlayer);
        }
    }
}
