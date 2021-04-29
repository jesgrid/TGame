using System;
using MapsAll;
using FramePainterAll;
using MovementAll;
using Doing;
using StructureGenerationAll;

namespace SecondProject
{
    class Program
    {
        static int mapSize = 4000; // Сторона квадрата карты
        static int xPlayer = mapSize / 2; // Позиция игрока
        static int yPlayer = mapSize / 2;
        static int zPlayer = 5;
        internal static char[,,] worldField = new char[mapSize, mapSize, 10];

        static void Main(string[] args)
        {
            ConsoleKeyInfo key;


            //Генерация карты
            Maps.FieldGenerator(5, worldField, mapSize); 
            for (int i = 0; i < 5; i++)
            {
                Maps.DownFieldGenerator(i, worldField, mapSize);
            }
            for (int i = 9; i > 5; i--)
            {
                Maps.SecondFloursGenerator(i, worldField, mapSize);
            }


            // Прорисовка первого кадра
            char pointUnderPlayer = worldField[xPlayer, yPlayer, zPlayer];
            worldField[xPlayer, yPlayer, zPlayer] = 'Ṽ';
            FramePainter.FieldPainter(xPlayer, yPlayer, zPlayer, worldField);


            // Для теста
            //StructureGeneration.BigCaveGeneration(4, 8, 2000, 2000, worldField);
            StructureGeneration.SmallVillageGeneration(5, 200, 200, 1900, 1900, worldField);
            do
            {
                Move move = Move.moveOnPoint;
                key = Console.ReadKey();
                switch (key.Key.ToString())
                {
                    case "W" or "UpArrow":
                        move = Move.moveUp;
                        break;
                    case "S" or "DownArrow":
                        move = Move.moveDown;
                        break;
                    case "A" or "LeftArrow":
                        move = Move.moveLeft;
                        break;
                    case "D" or "RightArrow":
                        move = Move.moveRight;
                        break;
                    case "Spacebar":
                        move = Move.moveTop;
                        break;
                    case "C":
                        move = Move.moveLower;
                        break;
                    default:
                        break;
                }

                Console.Clear();
                Console.WriteLine(key.Key.ToString());
                (xPlayer, yPlayer, zPlayer, pointUnderPlayer) = Movement.PlayerMove(xPlayer, yPlayer, zPlayer, move, pointUnderPlayer, worldField);

            } while (key.Key != ConsoleKey.Escape);
            return;
        }

        
    }
}
