using System;
using StructureGenerationAll;
namespace MapsAll
{
    public class Maps
    {
        public static void FieldGenerator(char[,] field, int mapSize)
        {
            Random rnd = new();
            // Символы для заполнения "земли"
            char[] fieldPoints = new[] { '˯', '˯', '˯', '˯', '˳', '˳', '˳', '.', '`', ',', '.', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            // Крайние, непроходимые символы для карты
            char[] edgePoints = new[] { '▓' };
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
        public static void DownFieldGenerator(char[,] field, int mapSize)
        {
            Random rnd = new();
            char[] fieldPoints = new[] { '▓' };
            int rndOut;
            int x = 0;
            int y = 0;


            while (y < mapSize)
            {
                while (x < mapSize)
                {
                    rndOut = rnd.Next(0, fieldPoints.Length);
                    field[x, y] = fieldPoints[rndOut];
                    x++;
                }
                x = 0;
                y++;
            }
            // Для теста
            StructureGeneration.BigCaveGeneration(8, 2000, 2000, field);
        }
        public static void SecondFloursGenerator(char[,] field, int mapSize)
        {
            Random rnd = new();
            char[] fieldPoints = new[] { ' ' };
            int rndOut;
            int x = 0;
            int y = 0;


            while (y < mapSize)
            {
                while (x < mapSize)
                {
                    rndOut = rnd.Next(0, fieldPoints.Length);
                    field[x, y] = fieldPoints[rndOut];
                    x++;
                }
                x = 0;
                y++;
            }
        }
    }
}
