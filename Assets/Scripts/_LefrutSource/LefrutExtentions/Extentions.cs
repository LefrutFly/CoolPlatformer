using System;
using UnityEngine;

namespace Lefrut.Extensions
{
    public static class Extentions
    {
        public static void Look2D(this GameObject gm, Vector3 obj)
        {
            Vector3 difference = obj - gm.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            gm.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        }

        public static void Look2D(this GameObject gm, Vector3 obj, float offset)
        {
            Vector3 difference = obj - gm.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            gm.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + offset);
        }

        public static float DirectionToAngel2D(this Vector2 direction)
        {
            direction.Normalize();
            float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            return rotationZ;
        }

        public static float DegreeToRadians(this float degree)
        {
            return degree * (Mathf.PI / 180);
        }

        public static Vector3 DegreeInVector3D(this float degree)
        {
            Vector3 direction = new Vector3();

            float radians = degree.DegreeToRadians();

            direction = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0).normalized;

            return direction;
        }

        public static Vector2 DegreeInVector2D(this float degree)
        {
            Vector2 direction = new Vector2();

            float radians = degree.DegreeToRadians();

            direction = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)).normalized;

            return direction;
        }

        public static Vector2 FindDirectionPointToPoint2D(this Vector2 point1, Vector2 point2)
        {
            Vector2 direction = new Vector2();

            Vector2 vector = new Vector2(point2.x - point1.x, point2.y - point1.y);

            direction = vector.normalized;

            return direction;
        }

        public static void InitArray(this Array arr)
        {
            int length = arr.Length;

            for (int i = 0; i < length; i++)
            {
                arr.SetValue(arr.GetType().GetElementType().GetConstructors()[0].Invoke(null), i);
            }
        }
    }
}