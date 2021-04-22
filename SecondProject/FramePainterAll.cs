using System;
namespace FramePainterAll
{
    public class FramePainter
    {
        public static void FieldPainter(int xPlayer, int yPlayer, string[,] field)
        {
            int scale = 6; // Размер окна
            int distanceX = 16 * scale;
            int distanceY = 9 * scale;
            int rightMenuSize = scale * 3;
            int leftMenuSize = scale * 2;
            int x;
            int y;
            string str = "";


            // Линия над полем
            for (int i = 0; i < ((distanceX * 2) - 1); i++)
            {
                str += "=";
            }
            Console.WriteLine(str);


            // Вывод отображаемой части поля
            x = xPlayer - distanceX;
            y = yPlayer - distanceY / 2;

            while (y < yPlayer + (distanceY / 2))
            {
                str = "";
                while (x < xPlayer + distanceX)
                {
                    if (y > yPlayer + (distanceY / 2) - leftMenuSize) // Нижний HUD
                    {
                        if (y == yPlayer + (distanceY / 2) - leftMenuSize + 1)
                        {
                            str += "-";
                        }
                        else
                        {
                            str += "Y";
                        }
                    }
                    else if (x > xPlayer + distanceX - rightMenuSize) // Правый HUD
                    {
                        if (x > xPlayer + distanceX - rightMenuSize + 1)
                        {
                            str += "X";
                        }
                        else
                        {
                            str += "|";
                        }
                    }
                    else
                    {
                        str += field[x, y];
                    }
                    x++;
                }
                Console.WriteLine(str);
                x = xPlayer - distanceX;
                y++;
            }
        }
    }
}
