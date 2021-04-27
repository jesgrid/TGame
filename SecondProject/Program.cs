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
        internal static char[,,] worldField = new char[mapSize, mapSize, 10]; // "ПОДУМОЙ!!!!!"
        /*
        Переделай StructureGenerationAll по классам!
        Вынеси рандом, СДЕЛАЙ ЕГО ЕДИНЫМ!
        */
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            Maps.FieldGenerator(5, worldField, mapSize); //Генерация карты
            Maps.DownFieldGenerator(4, worldField, mapSize);
            Maps.SecondFloursGenerator(6, worldField, mapSize);


            Maps.SecondFloursGenerator(0, worldField, mapSize);
            Maps.SecondFloursGenerator(1, worldField, mapSize);
            Maps.SecondFloursGenerator(2, worldField, mapSize);
            Maps.SecondFloursGenerator(3, worldField, mapSize);
            Maps.SecondFloursGenerator(7, worldField, mapSize);
            Maps.SecondFloursGenerator(8, worldField, mapSize);
            Maps.SecondFloursGenerator(9, worldField, mapSize);

            char pointUnderPlayer = worldField[xPlayer, yPlayer, zPlayer];
            worldField[xPlayer, yPlayer, zPlayer] = 'Ṽ';
            FramePainter.FieldPainter(xPlayer, yPlayer, zPlayer, worldField); // Прорисовка первого кадра
            

            //char[,] field = mainField;
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
