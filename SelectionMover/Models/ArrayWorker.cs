using System;

namespace SelectionMover.Models
{
    public static class ArrayWorker
    {
        public static int[,] NewArray(uint frame_width, uint frame_height)
        {
            Random random = new Random();
            int[,] array = new int[frame_height, frame_width];
            for (uint i = 0; i < frame_height; i++)
            {
                for (uint j = 0; j < frame_width; j++)
                {
                    array[i,j] = random.Next(int.MinValue, int.MaxValue);
                }

            }

            return array;
        }

        public static int[,] MoveSelection(int[,] array, uint x, uint y, uint width, uint height)
        {
            for (uint i = 0; i < height; i++)
            {
                for (uint j = 0; j < width; j++)
                {
                    array[i, j] = array[i + y, j + x];
                }
            }
            return array;
        }


    }
}
