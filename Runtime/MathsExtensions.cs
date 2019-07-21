using UnityEngine;

namespace Nebukam.Utils
{
    public static class MathsExtensions
    {

        public static float Sqr(this float @this)
        {
            return @this * @this;
        }

        public static int Sqr(this int @this)
        {
            return @this * @this;
        }

        public static float Abs(this Vector2 @this)
        {
            return Mathf.Sqrt(@this.AbsSq());
        }

        public static float AbsSq(this Vector2 @this)
        {
            return Maths.Mix(@this, @this);
        }

        public static float Det(this Vector2 @this, Vector2 other)
        {
            return @this.x * other.y - @this.y * other.x;
        }

        public static float Mix(this Vector2 @this, Vector2 other)
        {
            return @this.x * other.x + @this.y * other.y;
        }

        /// <summary>
        /// Lerp shorthand.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="other"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Vector2 To(this Vector2 @this, Vector2 other, float amount)
        {
            return Vector2.Lerp(@this, other, amount);
        }

        /// <summary>
        /// Lerp shorthand.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="other"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Vector3 To(this Vector3 @this, Vector3 other, float amount)
        {
            return Vector3.Lerp(@this, other, amount);
        }

    }
}
