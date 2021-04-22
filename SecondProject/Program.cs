﻿using System;
using MapsAll;
using FramePainterAll;
using MovementAll;
using Doing;

namespace SecondProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            int mapSize = 4000; // Сторона квадрата карты
            int xPlayer = mapSize / 2; // Позиция игрока
            int yPlayer = mapSize / 2;
            char[,] field = new char[mapSize, mapSize]; // Основное поле
            char[,] fieldGhost = new char[mapSize, mapSize]; // Вспомогательное поле для восстановления основного после изменений

            Maps.FieldGenerator(field, mapSize); //Генерация карты
            Array.Copy(field, fieldGhost, field.Length);
            field[xPlayer, yPlayer] = 'Ṽ';
            FramePainter.FieldPainter(xPlayer, yPlayer, field); // Прорисовка первого кадра

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
                        break;
                    default:
                        break;
                }

                Console.Clear();
                Console.WriteLine(key.Key.ToString());
                (xPlayer, yPlayer) = Movement.PlayerMove(xPlayer, yPlayer, move, field, fieldGhost);

            } while (key.Key != ConsoleKey.Escape);
            return;
        }

        
    }
}
