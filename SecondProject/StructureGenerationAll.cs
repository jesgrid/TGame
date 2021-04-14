using System;
namespace StructureGenerationAll
{
    public class StructureGeneration
    {
        static void HouseGeneration()
        {
            int maxWall = 40;
            int minWall = maxWall / 2;
            Random rnd = new();
            int wall_x = rnd.Next(minWall, maxWall);
            int wall_y = rnd.Next(minWall, maxWall);
        }


        public static string[,] BoxGeneration(int wallX, int wallY, int xStartPoint, int yStartPoint, string[,] buildField)
        {
            int x = xStartPoint;
            int y = yStartPoint;

            while (yStartPoint < wallY)
            {
                while (xStartPoint < wallX)
                {
                    if (yStartPoint <= y | xStartPoint <= x || yStartPoint == wallY - 1 | xStartPoint == wallX - 1)
                    {
                        buildField[xStartPoint, yStartPoint] = "█";
                    }
                    else
                    {
                        buildField[xStartPoint, yStartPoint] = " ";
                    }
                    xStartPoint++;
                }
                xStartPoint = x;
                yStartPoint++;
            }
            return buildField;
        }



        //public static string[,] BoxGeneration(int wall_x, int wall_y)
        //{
        //    string[,] buildField = new string[wall_x, wall_y];

        //    for (int i = 0; i < wall_y; i++)
        //    {
        //        for (int j = 0; j < wall_x; j++)
        //        {
        //            if (i < 1 | j < 1 || i == wall_y - 1 | j == wall_x - 1)
        //            {
        //                buildField[j, i] = "█";
        //            }
        //            else
        //            {
        //                buildField[j, i] = " ";
        //            }
        //        }
        //    }
        //    return buildField;
        //}
    }  
}
