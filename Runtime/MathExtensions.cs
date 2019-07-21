using UnityEngine;

namespace Nebukam.Utils
{
    public static class MathExtensions
    {

        public static float Sqr(this float @this)
        {
            return @this * @this;
        }

        public static int Sqr(this int @this)
        {
            return @this * @this;
        }

    }
}
