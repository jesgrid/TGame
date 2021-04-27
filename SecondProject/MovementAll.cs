using System;
using FramePainterAll;
using Doing;

namespace MovementAll
{
    public class Movement
    {
        public static (int, int, char) PlayerMove(int xPlayer, int yPlayer, Move move , char pointUnderPlayer, char[,] field)
        {
            field[xPlayer, yPlayer] = pointUnderPlayer;


            switch (move) // Действие
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


            char[] impassablePoints = new[] { '█', '▓' };

            for (int i = 0; i < impassablePoints.Length; i++) // Отмена действия в случае коллизии с непроходимыми объектами
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

            pointUnderPlayer = field[xPlayer, yPlayer];
            field[xPlayer, yPlayer] = 'Ṽ';
            FramePainter.FieldPainter(xPlayer, yPlayer, field);
            return (xPlayer, yPlayer, pointUnderPlayer);
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
