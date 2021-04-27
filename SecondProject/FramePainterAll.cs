using System;
using System.Text;
namespace FramePainterAll
{
    public class FramePainter
    {
        public static void FieldPainter(int xPlayer, int yPlayer, int z, char[,,] field)
        {
            int scale = 6; // Размер окна
            int distanceX = 16 * scale;
            int distanceY = 9 * scale;
            int rightMenuSize = scale * 3;
            int leftMenuSize = scale * 2;
            int x;
            int y;
            StringBuilder strB = new StringBuilder();

            // Линия над полем
            for (int i = 0; i < ((distanceX * 2) - 1); i++)
            {
                strB.Append('=');
            }
            strB.Append('\n');

            // Вывод отображаемой части поля
            x = xPlayer - distanceX;
            y = yPlayer - distanceY / 2;

            while (y < yPlayer + (distanceY / 2))
            {
                while (x < xPlayer + distanceX)
                {
                    if (y > yPlayer + (distanceY / 2) - leftMenuSize) // Нижний HUD
                    {
                        if (y == yPlayer + (distanceY / 2) - leftMenuSize + 1)
                        {
                            strB.Append('-');
                        }
                        else
                        {
                            strB.Append('Y');
                        }
                    }
                    else if (x > xPlayer + distanceX - rightMenuSize) // Правый HUD
                    {
                        if (x > xPlayer + distanceX - rightMenuSize + 1)
                        {
                            strB.Append('X');
                        }
                        else
                        {
                            strB.Append('|');
                        }
                    }
                    else
                    {
                        strB.Append(field[x, y, z]);
                    }
                    x++;
                }
                strB.Append('\n');
                x = xPlayer - distanceX;
                y++;
            }
            Console.WriteLine(strB);
        }
    }
}
