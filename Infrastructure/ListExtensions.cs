namespace Infrastructure;

public static class ListExtensions
{
    public static void EnsureIndex<T>(this List<T> list, int index) where T : new()
    {
        while (list.Count <= index)
        {
            list.Add(new T());
        }
    }
}