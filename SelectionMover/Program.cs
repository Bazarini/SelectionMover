using SelectionMover.Models;
using System;

namespace SelectionMover
{
    class Program
    {
        static void Main(string[] args)
        {
            uint frame_width, frame_height, pic_width, pic_height, pic_x, pic_y;

            frame_width = GetVariable("frame_width");
            frame_height = GetVariable("frame_height");

            int[,] array = ArrayWorker.NewArray(frame_width, frame_height);
            pic_x = GetVariable("pic_x");
            pic_width = GetVariable("pic_width");
            while (pic_x + pic_width > frame_width)
            {
                Console.WriteLine("selection width is out of frame borders. Please re-enter the variables");
                pic_x = GetVariable("pic_x");
                pic_width = GetVariable("pic_width");
            }
            pic_y = GetVariable("pic_y");
            pic_height = GetVariable("pic_height");
            while (pic_y + pic_height > frame_height)
            {
                Console.WriteLine("selection height is out of frame borders. Please re-enter the variables");
                pic_y = GetVariable("pic_y");
                pic_height = GetVariable("pic_height");
            }

            for (int i = 0; i < frame_height; i++)
            {
                for (int j = 0; j < frame_width; j++)
                {
                    if (i >= pic_y && i < pic_height + pic_y && j >= pic_x && j < pic_x + pic_width)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            array = ArrayWorker.MoveSelection(array, pic_x, pic_y, pic_width, pic_height);
            for (int i = 0; i < frame_height; i++)
            {
                for (int j = 0; j < frame_width; j++)
                {
                    if (i < pic_height && j < pic_width)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }
        static uint GetVariable(string varName)
        {
            uint variable;
            string temp = "";
            Console.Write($"{varName} = ");
            do
            {
                if (temp != "")
                {
                    Console.WriteLine($"{varName} is not a valid number or value is out of MAX ({uint.MaxValue}) and MIN ({uint.MinValue}) borders");
                    Console.Write($"{varName} = ");
                }
                temp = Console.ReadLine();

            } while (!uint.TryParse(temp, out variable));
            return variable;
        }
    }
}
