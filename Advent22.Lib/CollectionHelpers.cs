namespace Advent22.Lib;

public static class CollectionHelpers
{
    public static T[,] Get2DArray<T>(IEnumerable<IEnumerable<T>> collection)
    {
        var enumerable = collection as IEnumerable<T>[] ?? collection.ToArray();
        var max = enumerable.Max(c => c.Count());
        var array = new T[enumerable.Length, max];
        for (int i = 0; i < enumerable.Length; i++)
        {
            var innerCollection = enumerable[i].ToArray();
            for (int j = 0; j < max; j++)
            {
                array[i, j] = innerCollection[j];
            }
        }

        return array;
    }
}