using UnityEngine;

namespace Nebukam.Utils
{
    static public class Colors
    {

        static public float ConcatRGBA(Color col)
        {
            float m = 1000f;
            float A = col.a * 255, R = col.r * 255, G = col.g * 255, B = col.b * 255;
            return (R * m * m * m) + (G * m * m) + (B * m) + A;

        }


        static public float ConcatRGB(Color col)
        {
            float m = 1000f;
            return (col.r * m * m * m) + (col.g * m * m) + (col.b * m);

        }


    }

}
