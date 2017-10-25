using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.IO;

namespace Fractal_mandelbrot
{
    class Program
    {
        static double currentmaxr = 0;
        static double currentminr = 0;
        static double currentmaxi = 0;
        static double currentmini = 0;

        
        static Bitmap MandelbrotSet(int width, int height, double maxr, double minr, double maxi, double mini)
        {
            currentmaxr = maxr;
            currentmaxi = maxi;
            currentminr = minr;
            currentmini = mini;
            Bitmap img = new System.Drawing.Bitmap(width,height);
            double zx = 0;
            double zy = 0;
            double cx = 0;
            double cy = 0;
            double xjump = ((maxr - minr) / (double)width);
            double yjump = ((maxi - mini) / (double)height);
            double tempzx = 0;
            int loopmax = 1000;
            int loopgo = 0;
            for (int x = 0; x < width; x++)
            {
                cx = (xjump * x) - Math.Abs(minr);
                for (int y = 0; y < height; y++)
                {
                    zx = 0;
                    zy = 0;
                    cy = (yjump * y) - Math.Abs(mini);
                    loopgo = 0;
                    while (zx * zx + zy * zy <= 4 && loopgo < loopmax)
                    {
                        loopgo++;
                        tempzx = zx;
                        zx = (zx * zx) - (zy * zy) + cx;
                        zy = (2 * tempzx * zy) + cy;
                    }
                    if (loopgo != loopmax)
                        img.SetPixel(x, y, Color.FromArgb(loopgo % 128 * 2, loopgo % 32 * 7, loopgo % 16 * 14));
                    else
                        img.SetPixel(x, y, Color.Black);

                }
            }
            return img;

        }

        static void Main(string[] args)
        {
        }
    }
}