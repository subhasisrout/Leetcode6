using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class FloodFillLC733
    {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            int startingColor = image[sr][sc];
            if (startingColor == newColor)
                return image;
            FloodFillDFSUtil(image, startingColor, newColor, sr, sc);
            return image;
        }

        private void FloodFillDFSUtil(int[][] image,int startingColor, int newColor, int cr, int cc)
        {
            if (cr < 0 || cr >= image.Length || cc < 0 || cc >= image[0].Length || image[cr][cc] != startingColor)
                return;

            image[cr][cc] = newColor;

            FloodFillDFSUtil(image, startingColor, newColor, cr + 1, cc);
            FloodFillDFSUtil(image, startingColor, newColor, cr, cc + 1);
            FloodFillDFSUtil(image, startingColor, newColor, cr - 1, cc);
            FloodFillDFSUtil(image, startingColor, newColor, cr, cc - 1);

        }
    }
}
