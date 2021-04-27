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
        internal static char[,] mainField = new char[mapSize, mapSize]; // Основное поле
        internal static char[,] fieldGhost = new char[mapSize, mapSize]; // Вспомогательное поле для восстановления основного после изменений
        internal static char[,] downField = new char[mapSize, mapSize]; // "Массив для карты подземелий"
        internal static char[,] secondFloursField = new char[mapSize, mapSize]; // "Массив для вторых этажей зданий"
        /*
        internal static char[,,] worldField = new char[mapSize, mapSize, 80]; // "ПОДУМОЙ!!!!!"
        Переделай StructureGenerationAll по классам!
        Вынеси рандом, СДЕЛАЙ ЕГО ЕДИНЫМ!
        */
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            Maps.FieldGenerator(mainField, mapSize); //Генерация карты
            Array.Copy(mainField, fieldGhost, mainField.Length);
            Maps.DownFieldGenerator(downField, mapSize);
            Maps.SecondFloursGenerator(secondFloursField, mapSize);

            char pointUnderPlayer = mainField[xPlayer, yPlayer];
            mainField[xPlayer, yPlayer] = 'Ṽ';
            FramePainter.FieldPainter(xPlayer, yPlayer, mainField); // Прорисовка первого кадра
            

            char[,] field = mainField;
            StructureGeneration.SmallVillageGeneration(200, 200, 1900, 1900, field);
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
                        switch (pointUnderPlayer)
                        {
                            case 'ᛝ':
                                if (field == mainField)
                                {
                                    field[xPlayer, yPlayer] = pointUnderPlayer;
                                    pointUnderPlayer = downField[xPlayer, yPlayer];
                                    field = downField;
                                }
                                else if (field == downField)
                                {
                                    field[xPlayer, yPlayer] = pointUnderPlayer;
                                    pointUnderPlayer = mainField[xPlayer, yPlayer];
                                    field = mainField;
                                }
                                break;
                        }
                        break;
                    default:
                        break;
                }

                Console.Clear();
                //Console.WriteLine(key.Key.ToString());
                (xPlayer, yPlayer, pointUnderPlayer) = Movement.PlayerMove(xPlayer, yPlayer, move, pointUnderPlayer, field);

            } while (key.Key != ConsoleKey.Escape);
            return;
        }

        
    }
}
