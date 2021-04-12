using System;
namespace MapsAll
{
    public class Maps
    {
        

        public static void FieldGenerator(string[,] field)
        {
            Random rnd = new Random();
            string[] fieldPoints = new[] { "˯", "˯", "˯", "˯", "˳", "˳", "˳", ".", "`", ",", ".", " ", " ", " ", " ", " ", " " };
            int rndOut;
            int x = 0;
            int y = 0;

            while (y < 8000)
            {
                while (x < 8000)
                {
                    rndOut = rnd.Next(0, fieldPoints.Length);
                    field[x, y] = fieldPoints[rndOut];
                    x++;
                }
                x = 0;
                y++;
            }

            int test = 3990;
            while (test >= 3990 ^ test >= 4010)
            {
                field[3990, test] = "█";
                test++;
            }
            test = 3990;
            while (test >= 3990 ^ test >= 4010)
            {
                field[4010, test] = "█";
                test++;
            }
            test = 3990;
            while (test >= 3990 ^ test >= 4010)
            {
                field[test, 3990] = "█";
                test++;
            }
        }
    }
}
