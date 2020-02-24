using System;

namespace MentorMate_Logo
{
    public class Program
    {
        public static void Main()
        {
            var width = ReadWidth();
            CanvasGrid canvasGrid = new CanvasGrid();

            string logo = canvasGrid.GetLogo(width);
            Console.Write(logo);

        }

        public static int ReadWidth()
        {
            Console.WriteLine("Enter width as an odd number beteween 2 and 10000:");
            var widthString = Console.ReadLine();
            int width = 0;
            if (!int.TryParse(widthString, out width) || width < 2 || width > 10000 || width % 2 != 1)
            {
                Console.WriteLine("The value entered is not correct, please enter correct width.");
                ReadWidth();
            }
            return width;
        }
    }
}