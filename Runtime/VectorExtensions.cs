using UnityEngine;

namespace Nebukam.Utils
{
    public static class VectorExtensions
    {
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



    }
}
