using System;
namespace StructureGenerationAll
{
    public class StructureGeneration
    {

        public static void SmallVillageGeneration(int houseNumber, int xSideLength, int ySideLength, int xStartPoint, int yStartPoint, string[,] buildField)
        {
            Random rnd = new();
            int minStreetWidth = 2;
            int[] xStartPoints = new int[houseNumber];
            int[] yStartPoints = new int[houseNumber];
            int[] xWalls = new int[houseNumber];
            int[] yWalls = new int[houseNumber];
            for (int i = 0; i < houseNumber; i++)
            {
                if (i >= houseNumber / 2)
                {
                    xWalls[i] = rnd.Next(5, 12);
                    yWalls[i] = rnd.Next(3, 8);
                }
                else
                {
                    xWalls[i] = rnd.Next(8, 18);
                    yWalls[i] = rnd.Next(4, 12);
                }
                xStartPoints[i] = rnd.Next(xStartPoint, xStartPoint + xSideLength - xWalls[i]);
                yStartPoints[i] = rnd.Next(yStartPoint, yStartPoint + ySideLength - yWalls[i]);
            }

            /*
            Удаление коллизий (пока неудачно)

            int homeLength = 0;
            int Lines = 0;
            
            for (int i = 0; homeLength < xSideLength - xWalls[^1] | i < houseNumber; i++)
            {
                homeLength += xStartPoints[i] + xWalls[i] + minStreetWidth;
                if(i < houseNumber & homeLength >= xSideLength - xWalls[^1])
                {
                    Lines++;
                    homeLength = 0;
                }
            }
            */
            for (int i = 0; i < houseNumber; i++)
            {
                HouseGeneration(xWalls[i], yWalls[i], xStartPoints[i], yStartPoints[i], buildField);
            }
        }



        public static void HouseGeneration(int xWall, int yWall, int xStartPoint, int yStartPoint, string[,] buildField)
        {
            BoxGeneration(xWall, yWall, xStartPoint, yStartPoint, buildField);

            xWall += xStartPoint;
            yWall += yStartPoint;
            Random rnd = new();
            int exitExist = rnd.Next(0, 3);
            int x;
            int y;


            switch (exitExist)
            {
                case 0:
                    x = xStartPoint;
                    y = rnd.Next(yStartPoint + 1, yWall - 1);
                    buildField[x, y] = "⎕";
                    break;
                case 1:
                    x = xWall - 1;
                    y = rnd.Next(yStartPoint + 1, yWall - 1);
                    buildField[x, y] = "⎕";
                    break;
                case 2:
                    y = yStartPoint;
                    x = rnd.Next(xStartPoint + 1, xWall - 1);
                    buildField[x, y] = "⎕";
                    break;
                case 3:
                    y = yWall - 1;
                    x = rnd.Next(xStartPoint + 1, xWall - 1);
                    buildField[x, y] = "⎕";
                    break;
                default:
                    break;
            }
        }



        private static void BoxGeneration(int xWall, int yWall, int xStartPoint, int yStartPoint, string[,] buildField)
        {

            xWall += xStartPoint;
            yWall += yStartPoint;
            int x = xStartPoint;
            int y = yStartPoint;


            while (yStartPoint < yWall)
            {
                while (xStartPoint < xWall)
                {
                    if (yStartPoint <= y | xStartPoint <= x || yStartPoint == yWall - 1 | xStartPoint == xWall - 1)
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

        }
    }  
}
