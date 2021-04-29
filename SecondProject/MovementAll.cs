using System;
using FramePainterAll;
using Doing;

namespace MovementAll
{
    public class Movement
    {
        public static (int, int, int, char) PlayerMove(int xPlayer, int yPlayer, int zPlayer, Move move , char pointUnderPlayer, char[,,] field)
        {
            field[xPlayer, yPlayer, zPlayer] = pointUnderPlayer;
            int zTest = zPlayer;

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
                case Move.moveLower:
                    zPlayer -= 1;
                    break;
                case Move.moveTop:
                    zPlayer += 1;
                    break;
            }

            if (zPlayer > 9)
            {
                zPlayer = 9;
            }
            else if (zPlayer < 0)
            {
                zPlayer = 0;
            }

            if (zTest != zPlayer)
            {
                char[] passablePoints = new[] { 'ᛝ' };
                for (int i = 0; i < passablePoints.Length; i++) // Отмена действия в случае отсутствия уровня
                {
                    if (field[xPlayer, yPlayer, zPlayer] != passablePoints[i])
                    {
                        switch (move)
                        {
                            case Move.moveLower:
                                zPlayer += 1;
                                break;
                            case Move.moveTop:
                                zPlayer -= 1;
                                break;
                        }
                    }
                }
            }
            else
            {
                char[] impassablePoints = new[] { '█', '▓' };
                for (int i = 0; i < impassablePoints.Length; i++) // Отмена действия в случае коллизии с непроходимыми объектами
                {
                    if (field[xPlayer, yPlayer, zPlayer] == impassablePoints[i])
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
            }
            

            pointUnderPlayer = field[xPlayer, yPlayer, zPlayer];
            field[xPlayer, yPlayer, zPlayer] = 'Ṽ';
            FramePainter.FieldPainter(xPlayer, yPlayer, zPlayer, field);
            return (xPlayer, yPlayer, zPlayer, pointUnderPlayer);
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
        moveRight,
        moveTop,
        moveLower
    }
}
