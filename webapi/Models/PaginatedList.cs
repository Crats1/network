using Microsoft.EntityFrameworkCore;

namespace webapi.Models;

public class PaginatedList<T>
{
    private const int DEFAULT_LIMIT = 10;

    public int Offset { get; set; }
    public int Limit { get; set; }
    public int TotalItems { get; set; }
    public List<T> Items { get; set; }

    private PaginatedList(List<T> items, int totalItems, int limit, int offset)
    {
        TotalItems = totalItems;
        Limit = limit;
        Offset = offset;
        Items = items;
    }

    public static PaginatedList<T> CreateAsync(IEnumerable<T> source, int limit = DEFAULT_LIMIT, int offset = 0)
    {
        int count = source.Count();
        var items = source.Skip(offset).Take(limit).ToList();
        return new PaginatedList<T>(items, count, limit, offset);
    }

}
