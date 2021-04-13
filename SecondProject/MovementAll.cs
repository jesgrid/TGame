using System;
using FramePainterAll;
using Doing;

namespace MovementAll
{
    public class Movement
    {
        public static (int, int) PlayerMove(int xPlayer, int yPlayer, Move move , string[,] field, string[,] fieldGhost)
        {
            field[xPlayer, yPlayer] = fieldGhost[xPlayer, yPlayer];


            switch (move)
            {
                case Move.moveUp:
                    yPlayer -= 1;
                    break;
                case Move.moveDown:
                    yPlayer += 1;
                    break;
                case Move.moveLeft:
                    xPlayer -= 1;
                    break;
                case Move.moveRight:
                    xPlayer += 1;
                    break;
            }


            string[] impassablePoints = new[] { "█", "▓" };

            for (int i = 0; i < impassablePoints.Length; i++)
            {
                if (field[xPlayer, yPlayer] == impassablePoints[i])
                {
                    switch (move)
                    {
                        case Move.moveUp:
                            yPlayer += 1;
                            break;
                        case Move.moveDown:
                            yPlayer -= 1;
                            break;
                        case Move.moveLeft:
                            xPlayer += 1;
                            break;
                        case Move.moveRight:
                            xPlayer -= 1;
                            break;
                    }
                }
            }


            field[xPlayer, yPlayer] = "Ṽ";
            FramePainter.FieldPainter(xPlayer, yPlayer, field);
            return (xPlayer, yPlayer);
        }
    }
}

namespace Doing
{
    public enum Move
    {
        moveOnPoint,
        moveUp,
        moveDown,
        moveLeft,
        moveRight
    }
}