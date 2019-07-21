using System;
using UnityEngine;

namespace Nebukam.Utils
{
    static public class Draw
    {
        
        static public void Line(Vector3 from, Vector3 to)
        {
            Line(from, to, Color.red);
        }

        static public void Line(Vector3 from, Vector3 to, Color col)
        {
            Debug.DrawLine(from, to, col);
        }

        static public void Circle(Vector3 center, float radius)
        {
            Circle(center, radius, Color.red);
        }
        
        static public void Circle(Vector3 center, float radius, Color col)
        {

            int samples = 30;
            Vector3 from, to;

            float angleIncrease = (float)(Math.PI * 2) / (float)samples;
            from = to = new Vector3(center.x + radius * (float)Math.Cos(0.0f), center.y, center.z + radius * (float)Math.Sin(0.0f));

            for (int i = 0; i < samples; i++)
            {

                float rad = angleIncrease * (i + 1);

                to = new Vector3(center.x + radius * Mathf.Cos(rad), center.y, center.z + radius * Mathf.Sin(rad));

                Line(from, to, col);

                from = to;


            }
        }

        static public void Circle2D(Vector3 center, float radius)
        {
            Circle2D(center, radius, Color.red);
        }

        static public void Circle2D(Vector3 center, float radius, Color col)
        {

            int samples = 30;
            Vector3 from, to;

            float angleIncrease = (float)(Math.PI * 2) / (float)samples;
            from = to = new Vector3(center.x + radius * Mathf.Cos(0.0f), center.y + radius * Mathf.Sin(0.0f), center.z);

            for (int i = 0; i < samples; i++)
            {

                float rad = angleIncrease * (i + 1);

                to = new Vector3(center.x + radius * Mathf.Cos(rad), center.y + radius * Mathf.Sin(rad), center.z);

                Line(from, to, col);

                from = to;


            }
        }

        static public void Square(Vector3 center, float size, Color col)
        {
            float s = size * 0.5f;

            Vector3 A = center + new Vector3(-s, 0f, -s);
            Vector3 B = center + new Vector3(-s, 0f, s);
            Vector3 C = center + new Vector3(s, 0f, s);
            Vector3 D = center + new Vector3(s, 0f, -s);

            Line(A, B, col);
            Line(B, C, col);
            Line(C, D, col);
            Line(D, A, col);

        }

    }
}
