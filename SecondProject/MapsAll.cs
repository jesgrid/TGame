using System;

namespace MapsAll
{
    public class Maps
    {
        public static void FieldGenerator(string[,] field, int mapSize)
        {
            
            Random rnd = new();
            // Символы для заполнения "земли"
            string[] fieldPoints = new[] { "˯", "˯", "˯", "˯", "˳", "˳", "˳", ".", "`", ",", ".", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
            // Крайние символы для 
            string[] edgePoints = new[] { "▓" };
            int rndOut;
            int edge = 16 * 6 + 5;
            int x = 0;
            int y = 0;


            while (y < mapSize)
            {
                while (x < mapSize)
                {
                    if((x <= edge) | (y <= edge))
                    {
                        rndOut = rnd.Next(0, edgePoints.Length);
                        field[x, y] = edgePoints[rndOut];
                    }
                    else if ((x >= mapSize - edge) | (y >= mapSize - edge))
                    {
                        rndOut = rnd.Next(0, edgePoints.Length);
                        field[x, y] = edgePoints[rndOut];
                    }
                    else
                    {
                        rndOut = rnd.Next(0, fieldPoints.Length);
                        field[x, y] = fieldPoints[rndOut];
                    }
                    x++;
                }
                x = 0;
                y++;
            }
        }
    }
}
