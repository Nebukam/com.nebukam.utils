using System;
using System.Collections.Generic;

namespace Nebukam.Utils
{
    static public class Collections
    {

        #region Array

        public static int[] DistributeAmountRandom(int amount, int parts)
        {
            int[] result = new int[parts];

            for (int i = 0; i < parts; i++)
            {
                int part = (i == parts - 1) ? amount : (int)Maths.Rand(amount, false);
                result[i] = part;
                amount = amount - part;
            }

            return result;
        }

        public static int[] DistributeAmountHalves(int amount, int parts)
        {
            int[] result = new int[parts];

            for (int i = 0; i < parts; i++)
            {
                int part = (i == parts - 1) ? amount : amount / 2;
                result[i] = part;
                amount = amount - part;
            }

            return result;
        }


        #endregion

        #region List

        public static List<T> Copy<T>(List<T> list)
        {
            List<T> listCopy = new List<T>();
            foreach (T item in list)
                listCopy.Add(item);
            return listCopy;
        }

        public static void CopyTo<T>(List<T> source, List<T> target)
        {
            for (int i = 0; i < source.Count; i++)
                target.Add(source[i]);
        }

        public static void Randomize<T>(IList<T> list)
        {

            List<T> listCopy = new List<T>();
            foreach (T item in list)
                listCopy.Add(item);

            int lCount = listCopy.Count;
            int i = 0;

            while (listCopy.Count != 0)
            {
                int rIndex = (int)Math.Floor(UnityEngine.Random.value * (float)listCopy.Count);
                list[i] = listCopy[rIndex];
                listCopy.RemoveAt(rIndex);
                i++;
            }

        }

        public static T RandomPick<T>(IList<T> list)
        {
            int range = list.Count - 1;

            if (range == 0)
                return default(T);

            return list[(int)Maths.Rand(range, false)];
        }

        public static T RandomExtract<T>(IList<T> list)
        {
            int range = list.Count - 1;

            if (range == 0)
                return default(T);

            int index = (int)Maths.Rand(range, false);

            T result = list[index];
            list.RemoveAt(index);

            return result;
        }

        #endregion


    }

}