using System;
namespace StructureGenerationAll
{
    public class StructureGeneration
    {
        public static void HouseGeneration(int wallX, int wallY, int xStartPoint, int yStartPoint, string[,] buildField)
        {
            BoxGeneration(wallX, wallY, xStartPoint, yStartPoint, buildField);

            wallX += xStartPoint;
            wallY += yStartPoint;
            Random rnd = new();
            int exitExist = rnd.Next(0, 3);
            int x;
            int y;


            switch (exitExist)
            {
                case 0:
                    x = xStartPoint;
                    y = rnd.Next(yStartPoint + 1, wallY - 1);
                    buildField[x, y] = "⎕";
                    break;
                case 1:
                    x = wallX - 1;
                    y = rnd.Next(yStartPoint + 1, wallY - 1);
                    buildField[x, y] = "⎕";
                    break;
                case 2:
                    y = yStartPoint;
                    x = rnd.Next(xStartPoint + 1, wallX - 1);
                    buildField[x, y] = "⎕";
                    break;
                case 3:
                    y = wallY - 1;
                    x = rnd.Next(xStartPoint + 1, wallX - 1);
                    buildField[x, y] = "⎕";
                    break;
                default:
                    break;
            }
        }



        private static void BoxGeneration(int wallX, int wallY, int xStartPoint, int yStartPoint, string[,] buildField)
        {
            
            wallX += xStartPoint;
            wallY += yStartPoint;
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

        }
    }  
}
