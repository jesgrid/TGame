﻿using System;
using Doing;
namespace StructureGenerationAll
{
    public class StructureGeneration
    {

        public static void SmallVillageGeneration(int z, int xSideLength, int ySideLength, int xStartPoint, int yStartPoint, char[,,] buildField)
        {
            int houseNumber = xSideLength + ySideLength; 
            Random rnd = new();
            newStart: // Заметка для себя: Реализовать по другому, когда появится идея!
            int[] xStartPoints = new int[houseNumber];
            int[] yStartPoints = new int[houseNumber];
            int[] xWalls = new int[houseNumber];
            int[] yWalls = new int[houseNumber];
            for (int i = 0; i < houseNumber; i++) // Рандомная генерация параметров для всех зданий
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


            int[,] collisionSearch = new int[xSideLength, ySideLength]; // Массив для поиска коллизий

            for (int j = 0; j < ySideLength; j++)
            {
                for (int k = 0; k < xSideLength; k++)
                {
                    collisionSearch[k, j] = 0;
                }
            }


            int numberOfLoops = 0;
            bool loop = false;

            for (int i = 0; i < houseNumber; i++) // Тест на коллизии
            {
                if (loop == true)
                {
                    i--;
                    loop = false;
                }
                for (int j = yStartPoints[i] - yStartPoint; j <= yStartPoints[i] - yStartPoint + yWalls[i]; j++)
                {
                    for (int k = xStartPoints[i] - xStartPoint; k <= xStartPoints[i] - xStartPoint + xWalls[i]; k++)
                    {
                        int collisionTest = collisionSearch[k, j] + 1;
                        if (collisionTest >= 2) // Изменение точек расположения конкретного дома
                        {
                            xStartPoints[i] = rnd.Next(xStartPoint, xStartPoint + xSideLength - xWalls[i]);
                            yStartPoints[i] = rnd.Next(yStartPoint, yStartPoint + ySideLength - yWalls[i]);
                            loop = true;
                            j = yWalls[i];
                        }
                    }
                }
                if (loop == true) // Уменьшение колличества домов в случае множественных повторов поиска позиции дома. Сброс вычислений
                {
                    numberOfLoops++;
                    if (numberOfLoops == 10)
                    {
                        houseNumber -= 5;
                        goto newStart;
                    }
                }
                else // запись занятых позиций в массив collisionSearch
                {
                    numberOfLoops = 0; // Сброс счётцика
                    for (int j = yStartPoints[i] - yStartPoint; j <= yStartPoints[i] - yStartPoint + yWalls[i]; j++)
                    {
                        for (int k = xStartPoints[i] - xStartPoint; k <= xStartPoints[i] - xStartPoint + xWalls[i]; k++)
                        {
                            collisionSearch[k, j] = 1;
                        }
                    }
                }
            }
            
            for (int i = 0; i < houseNumber; i++)
            {
                HouseGeneration(z, xWalls[i], yWalls[i], xStartPoints[i], yStartPoints[i], buildField);
            }
        }



        private static void HouseGeneration(int z, int xWall, int yWall, int xStartPoint, int yStartPoint, char[,,] buildField)
        {
            BoxGeneration(z, xWall, yWall, xStartPoint, yStartPoint, buildField);
            Random rnd = new();
            int x;
            int y;
            int rndChance;
            // Генерация погреба
            bool caveExist = false;
            rndChance = rnd.Next(100);
            if (rndChance < 50)
            {
                CaveGeneration(z - 1, 1, xStartPoint, yStartPoint, buildField);
                caveExist = true;
            }


            // Генерация этажей
            int levelCheck = 0;
            bool prevFlourExist = true;
            for (int i = z + 1; i <= 9; i++)
            {
                if (prevFlourExist)
                {
                    rndChance = rnd.Next(100);
                    if (rndChance < 40)
                    {
                        BoxGeneration(i, xWall, yWall, xStartPoint, yStartPoint, buildField);
                        levelCheck++;
                    }
                    else
                    {
                        prevFlourExist = false;
                    }
                }
            }

            // Генерация двери с исключением угловых блоков коробки
            int exitExist = rnd.Next(0, 3);
            xWall += xStartPoint;
            yWall += yStartPoint;
            switch (exitExist) 
            {
                case 0:
                    x = xStartPoint;
                    y = rnd.Next(yStartPoint + 1, yWall - 1);
                    buildField[x, y, z] = '⎕';
                    break;
                case 1:
                    x = xWall - 1;
                    y = rnd.Next(yStartPoint + 1, yWall - 1);
                    buildField[x, y, z] = '⎕';
                    break;
                case 2:
                    y = yStartPoint;
                    x = rnd.Next(xStartPoint + 1, xWall - 1);
                    buildField[x, y, z] = '⎕';
                    break;
                case 3:
                    y = yWall - 1;
                    x = rnd.Next(xStartPoint + 1, xWall - 1);
                    buildField[x, y, z] = '⎕';
                    break;
                default:
                    break;
            }
            
            // Генерация лестниц
            switch (exitExist)
            {
                case 0:
                    x = xWall - 2;
                    y = rnd.Next(yStartPoint + 1, yWall - 1);
                    if (levelCheck != 0)
                    {
                        for (int i = 0; i <= levelCheck; i++)
                        {
                            buildField[x, y, z + i] = 'ᛝ';
                        }
                    }
                    if (buildField[x, y, z - 1] == ' ' & caveExist)
                    {
                        buildField[x, y, z] = 'ᛝ';
                        buildField[x, y, z - 1] = 'ᛝ';
                    }
                    break;
                case 1:
                    x = xStartPoint + 1;
                    y = rnd.Next(yStartPoint + 1, yWall - 1);
                    if (levelCheck != 0)
                    {
                        for (int i = 0; i <= levelCheck; i++)
                        {
                            buildField[x, y, z + i] = 'ᛝ';
                        }
                    }
                    if (buildField[x, y, z - 1] == ' ' & caveExist)
                    {
                        buildField[x, y, z] = 'ᛝ';
                        buildField[x, y, z - 1] = 'ᛝ';
                    }
                    break;
                case 2:
                    y = yWall - 2;
                    x = rnd.Next(xStartPoint + 1, xWall - 1);
                    if (levelCheck != 0)
                    {
                        for (int i = 0; i <= levelCheck; i++)
                        {
                            buildField[x, y, z + i] = 'ᛝ';
                        }
                    }
                    if (buildField[x, y, z - 1] == ' ' & caveExist)
                    {
                        buildField[x, y, z] = 'ᛝ';
                        buildField[x, y, z - 1] = 'ᛝ';
                    }
                    break;
                case 3:
                    y = yStartPoint + 1;
                    x = rnd.Next(xStartPoint + 1, xWall - 1);
                    if (levelCheck != 0)
                    {
                        for (int i = 0; i <= levelCheck; i++)
                        {
                            buildField[x, y, z + i] = 'ᛝ';
                        }
                    }
                    if (buildField[x, y, z - 1] == ' ' & caveExist)
                    {
                        buildField[x, y, z] = 'ᛝ';
                        buildField[x, y, z - 1] = 'ᛝ';
                    }
                    break;
                default:
                    break;
            }
        }



        private static void BoxGeneration(int z, int xWall, int yWall, int xStartPoint, int yStartPoint, char[,,] buildField)
        {
            Random rnd = new();
            xWall += xStartPoint;
            yWall += yStartPoint;
            int x = xStartPoint;
            int y = yStartPoint;

            // Генерация коробки стен и её внутреннего пространства
            while (yStartPoint < yWall)
            {
                while (xStartPoint < xWall)
                {
                    if (yStartPoint <= y | xStartPoint <= x || yStartPoint == yWall - 1 | xStartPoint == xWall - 1)
                    {
                        buildField[xStartPoint, yStartPoint, z] = '█';
                    }
                    else
                    {
                        buildField[xStartPoint, yStartPoint, z] = ' ';
                    }
                    xStartPoint++;
                }
                xStartPoint = x;
                yStartPoint++;
            }
        }



        public static void BigCaveGeneration(int z, int sizeOfCave, int xStartPoint, int yStartPoint, char[,,] buildField)
        {
            sizeOfCave *= 2;
            for(int i = 0; i <= sizeOfCave; i++)
            {
                CaveGeneration(z, sizeOfCave, xStartPoint, yStartPoint, buildField);
            }
        }



        public static void CaveGeneration(int z, int sizeOfCave, int xStartPoint, int yStartPoint, char[,,] buildField)
        {
            sizeOfCave *= 50;
            int x = xStartPoint;
            int y = yStartPoint;
            Random rnd = new();
            Array values = Enum.GetValues(typeof(Move));

            for (int i = y - 3; i <= y + 3; i++)
            {
                for (int j = x - 3; j <= x + 3; j++)
                {
                    buildField[j, i, z] = ' ';
                }
            }

            for (int k = 0; k < sizeOfCave; k++)
            {
                Move mv = (Move)values.GetValue(rnd.Next(values.Length));
                int room = rnd.Next(100);
                switch (mv)
                {
                    case Move.moveUp:
                        y -= 3;
                        break;
                    case Move.moveDown:
                        y += 3;
                        break;
                    case Move.moveLeft:
                        x -= 3;
                        break;
                    case Move.moveRight:
                        x += 3;
                        break;
                }
                if (room < 20)
                {
                    for (int i = y - 4; i <= y + 4; i++)
                    {
                        for (int j = x - 6; j <= x + 6; j++)
                        {
                            buildField[j, i, z] = ' ';
                        }
                    }
                }
                else
                {
                    for (int i = y - 1; i <= y + 1; i++)
                    {
                        for (int j = x - 1; j <= x + 1; j++)
                        {
                            buildField[j, i, z] = ' ';
                        }
                    }
                }
            }
        }
    }  
}
