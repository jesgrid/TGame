using System;
namespace FramePainterAll
{
    public class FramePainter
    {
        public static void FieldPainter(int xPlayer, int yPlayer, string[,] field)
        {
            int scale = 6;
            int distanceX = 16 * scale;
            int distanceY = 9 * scale;
            int x = 0;
            int y = 0;
            string str = "";
            for (int i = 0; i < ((distanceX * 2) - 1); i++)
            {
                str += "=";
            }
            Console.WriteLine(str);
            str = "";
            x = xPlayer - distanceX;
            y = yPlayer - distanceY / 2;
            while (y < yPlayer + (distanceY / 2))
            {
                while (x < xPlayer + distanceX)
                {
                    str += field[x, y];
                    x++;
                }
                Console.WriteLine(str);
                str = "";
                x = xPlayer - distanceX;
                y++;
            }
        }
    }
}
