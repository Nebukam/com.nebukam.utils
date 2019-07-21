using System.Collections.Generic;


namespace Nebukam.Utils
{
    public static class ListsExtensions
    {

        /// <summary>
        /// Return an item at random index.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static T RandomPick<T>(this IList<T> @this)
        {
            return Lists.RandomPick(@this);
        }

        /// <summary>
        /// Return and remove and item at a random index.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static T RandomExtract<T>(this IList<T> @this)
        {
            return Lists.RandomExtract(@this);
        }

        /// <summary>
        /// Randomize this list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        public static void Randomize<T>(this IList<T> @this)
        {
            Lists.Randomize(@this);
        }

    }
}
