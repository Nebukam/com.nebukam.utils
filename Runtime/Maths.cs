using System;
using UnityEngine;

namespace Nebukam.Utils
{
    static public class Maths
    {

        #region Constants

        public const float EPSILON = 0.00001f;
        public const float TAU = (float)Math.PI * 2.0f;

        #endregion

        #region Random

        /// <summary>
        /// A random value ranging from 0 to a given range. 
        /// Mirrored, the value ranges from -range to +range
        /// </summary>
        /// <param name="range"></param>
        /// <param name="mirror"></param>
        /// <returns></returns>
        public static float Rand(float range, bool mirror = true)
        {
            return UnityEngine.Random.value * range - (mirror ? UnityEngine.Random.value * range : 0.0f);
        }

        /// <summary>
        /// Return a random value within a given min/max range.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float RandRange(float min, float max)
        {
            return min + Rand(max - min, false);
        }


        #endregion

        #region Maths

        /// <summary>
        /// Multiply a float by itself
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float Sqr(float f)
        {
            return f * f;
        }

        /// <summary>
        /// Multiply an int by itself
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static int Sqr(int f)
        {
            return f * f;
        }

        /// <summary>
        /// Convert a value in radian into degree
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static float Degrees(float radian)
        {
            return radian * (180 / Mathf.PI);
        }

        /// <summary>
        /// Return the angle of a 2D point, in degree from -180 to 180
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float FindDegree(float x, float y)
        {
            float value = (Mathf.Atan2(x, y) / Mathf.PI) * 180f;
            if (value < 0) value += 360f;

            return value;
        }

        /// <summary>
        /// Strips up a precision digit from a vector
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector3 RoundUpVector(Vector3 v)
        {
            v.x = Mathf.Round(v.x * 10f) / 10f;
            v.y = Mathf.Round(v.y * 10f) / 10f;
            v.z = Mathf.Round(v.z * 10f) / 10f;
            return v;
        }
        
        /// <summary>
        /// Return a scale ratio so a given content size fits in a given container size.
        /// </summary>
        /// <param name="containerSize"></param>
        /// <param name="contentSize"></param>
        /// <returns></returns>
        public static float PreserveRatio(Vector2 containerSize, Vector2 contentSize)
        {

            float contentRatio = contentSize.x / contentSize.y;
            float containerRatio = containerSize.x / containerSize.y;

            return containerRatio > contentRatio ? containerSize.y / contentSize.y : containerSize.x / contentSize.x;

        }

        #endregion

        #region Matrices

        /// <summary>
        /// Extract translation from transform matrix.
        /// </summary>
        /// <param name="matrix">Transform matrix. This parameter is passed by reference
        /// to improve performance; no changes will be made to it.</param>
        /// <returns>
        /// Translation offset.
        /// </returns>
        public static Vector3 ExtractTranslationFromMatrix(ref Matrix4x4 matrix)
        {
            Vector3 translate;
            translate.x = matrix.m03;
            translate.y = matrix.m13;
            translate.z = matrix.m23;
            return translate;
        }

        /// <summary>
        /// Extract rotation quaternion from transform matrix.
        /// </summary>
        /// <param name="matrix">Transform matrix. This parameter is passed by reference
        /// to improve performance; no changes will be made to it.</param>
        /// <returns>
        /// Quaternion representation of rotation transform.
        /// </returns>
        public static Quaternion ExtractRotationFromMatrix(ref Matrix4x4 matrix)
        {
            Vector3 forward;
            forward.x = matrix.m02;
            forward.y = matrix.m12;
            forward.z = matrix.m22;

            Vector3 upwards;
            upwards.x = matrix.m01;
            upwards.y = matrix.m11;
            upwards.z = matrix.m21;

            return Quaternion.LookRotation(forward, upwards);
        }

        /// <summary>
        /// Extract scale from transform matrix.
        /// </summary>
        /// <param name="matrix">Transform matrix. This parameter is passed by reference
        /// to improve performance; no changes will be made to it.</param>
        /// <returns>
        /// Scale vector.
        /// </returns>
        public static Vector3 ExtractScaleFromMatrix(ref Matrix4x4 matrix)
        {
            Vector3 scale;
            scale.x = new Vector4(matrix.m00, matrix.m10, matrix.m20, matrix.m30).magnitude;
            scale.y = new Vector4(matrix.m01, matrix.m11, matrix.m21, matrix.m31).magnitude;
            scale.z = new Vector4(matrix.m02, matrix.m12, matrix.m22, matrix.m32).magnitude;
            return scale;
        }

        /// <summary>
        /// Extract position, rotation and scale from TRS matrix.
        /// </summary>
        /// <param name="matrix">Transform matrix. This parameter is passed by reference
        /// to improve performance; no changes will be made to it.</param>
        /// <param name="localPosition">Output position.</param>
        /// <param name="localRotation">Output rotation.</param>
        /// <param name="localScale">Output scale.</param>
        public static void DecomposeMatrix(ref Matrix4x4 matrix, out Vector3 localPosition, out Quaternion localRotation, out Vector3 localScale)
        {
            localPosition = ExtractTranslationFromMatrix(ref matrix);
            localRotation = ExtractRotationFromMatrix(ref matrix);
            localScale = ExtractScaleFromMatrix(ref matrix);
        }

        /// <summary>
        /// Set transform component from TRS matrix.
        /// </summary>
        /// <param name="transform">Transform component.</param>
        /// <param name="matrix">Transform matrix. This parameter is passed by reference
        /// to improve performance; no changes will be made to it.</param>
        public static void SetTransformFromMatrix(Transform transform, ref Matrix4x4 matrix)
        {
            transform.localPosition = ExtractTranslationFromMatrix(ref matrix);
            transform.localRotation = ExtractRotationFromMatrix(ref matrix);
            transform.localScale = ExtractScaleFromMatrix(ref matrix);
        }


        // EXTRAS!

        /// <summary>
        /// Identity quaternion.
        /// </summary>
        /// <remarks>
        /// <para>It is faster to access this variation than <c>Quaternion.identity</c>.</para>
        /// </remarks>
        public static readonly Quaternion IdentityQuaternion = Quaternion.identity;
        /// <summary>
        /// Identity matrix.
        /// </summary>
        /// <remarks>
        /// <para>It is faster to access this variation than <c>Matrix4x4.identity</c>.</para>
        /// </remarks>
        public static readonly Matrix4x4 IdentityMatrix = Matrix4x4.identity;

        /// <summary>
        /// Get translation matrix.
        /// </summary>
        /// <param name="offset">Translation offset.</param>
        /// <returns>
        /// The translation transform matrix.
        /// </returns>
        public static Matrix4x4 TranslationMatrix(Vector3 offset)
        {
            Matrix4x4 matrix = IdentityMatrix;
            matrix.m03 = offset.x;
            matrix.m13 = offset.y;
            matrix.m23 = offset.z;
            return matrix;
        }

        #endregion

        #region Vector maths

        /// <summary>
        /// Return the Normal vector of an A, B, C triad
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <returns></returns>
        public static Vector3 Normal(Vector3 A, Vector3 B, Vector3 C)
        {
            return Vector3.Cross((B - A), (A - C)).normalized;
        }

        /// <summary>
        /// Normal | C = B + Vector3.up
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Vector3 Perp(Vector3 A, Vector3 B)
        {
            return Normal(A, B, B + Vector3.up);
        }

        /// <summary>
        /// Normal | C = B+dir
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static Vector3 NormalDir(Vector3 A, Vector3 B, Vector3 dir)
        {
            return Normal(A, B, B + dir);
        }

        /// <summary>
        /// Multiply each vector's component individually, returning the resulting vector.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 Mult(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        /// <summary>
        /// Normalized value remapping
        /// Example : remap 0.5 to (0.5, 1.0) = 0;
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static float NrmRemap(float val, float min, float max = 1.0f)
        {
            float diff = val - min;

            if (diff <= 0.0f)
            {
                return 0.0f;
            }

            float scale = max - min;

            return diff / scale;
        }

        /// <summary>
        /// Rotate a point around a pivot, by an amount formatted as a Quaternion
        /// </summary>
        /// <param name="point"></param>
        /// <param name="pivot"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static Vector3 RotateAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle)
        {
            return angle * (point - pivot) + pivot;
        }

        /// <summary>
        /// Rotate a point around a pivot, by a given amount on each axis.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="pivot"></param>
        /// <param name="angles"></param>
        /// <returns></returns>
        public static Vector3 RotateAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
        {
            Vector3 dir = point - pivot; // get point direction relative to pivot
            dir = Quaternion.Euler(angles) * dir; // rotate it
            point = dir + pivot; // calculate rotated point
            return point; // return it
        }

        /// <summary>
        /// Rotate point around an axis and a given direction.
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="axis"></param>
        /// <param name="dir"></param>
        /// <param name="radius"></param>
        /// <param name="radAngle"></param>
        /// <returns></returns>
        public static Vector3 RotatePointAroundAxisDir(Vector3 origin, Vector3 axis, Vector3 dir, float radius, float radAngle)
        {

            Vector3 a, b, c, n;

            a = Vector3.zero;
            b = axis;
            c = dir;

            n = Vector3.Cross(b - a, c - a).normalized;

            Quaternion rot = Quaternion.AngleAxis(radAngle / 0.0174532924f, axis); // get the desired rotation

            n = (rot * n);

            return origin + (n * radius);

        }

        /// <summary>
        /// Computes the determinant of a two-dimensional square matrix 
        /// with rows consisting of the specified two-dimensional vectors.
        /// </summary>
        /// <param name="a">The top row of the two-dimensional square matrix</param>
        /// <param name="b">The bottom row of the two-dimensional square matrix</param>
        /// <returns>The determinant of the two-dimensional square matrix.</returns>
        public static float Det(Vector2 a, Vector2 b)
        {
            return a.x * b.y - a.y * b.x;
        }

        public static float Mix(Vector2 a, Vector2 b)
        {
            return a.x * b.x + a.y * b.y;
        }

        /// <summary>
        /// Computes the squared length of a specified two-dimensional vector.
        /// </summary>
        /// <param name="v"></param>
        /// <returns>The squared length of the two-dimensional vector.</returns>
        public static float AbsSq(Vector2 v)
        {
            return Mix(v, v);
        }

        /// <summary>
        /// >Computes the length of a specified two-dimensional vector.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static float Abs(Vector2 v)
        {
            return Mathf.Sqrt(AbsSq(v));
        }

        /// <summary>
        /// Computes the squared distance from a line segment with the specified endpoints to a specified point.
        /// </summary>
        /// <param name="a">The first endpoint of the line segment.</param>
        /// <param name="b">The second endpoint of the line segment.</param>
        /// <param name="c">The point to which the squared distance is to be calculated.</param>
        /// <returns>The squared distance from the line segment to the point.</returns>
        public static float DistSqPointLineSegment(Vector2 a, Vector2 b, Vector2 c)
        {
            float r = (Mix((c - a), (b - a))) / (b - a).AbsSq();

            if (r < 0.0f)
            {
                return (c - a).AbsSq();
            }

            if (r > 1.0f)
            {
                return (c - b).AbsSq();
            }

            return (c - (a + r * (b - a))).AbsSq();
        }

        /// <summary>
        /// Computes the signed distance from a line connecting the specified points to a specified point.
        /// </summary>
        /// <param name="a">The first point on the line.</param>
        /// <param name="b">The second point on the line.</param>
        /// <param name="c">The point to which the signed distance is to be calculated.</param>
        /// <returns>Positive when the point c lies to the left of the line ab.</returns>
        public static float LeftOf(Vector2 a, Vector2 b, Vector2 c)
        {
            return Det(a - c, b - a);
        }

        #endregion

    }
}
