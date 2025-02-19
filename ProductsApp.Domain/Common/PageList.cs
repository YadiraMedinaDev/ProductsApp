using ProductsApp.Domain.Exceptions;

namespace ProductsApp.Domain.Common;
public sealed class PageList<T>:List<T>
{
    public PageList(IEnumerable<T> items,int count, int pageNumber, int pageSize) {
        Validate(pageNumber, pageSize);

        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;

        AddRange(items);
    }

    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public int TotalCount { get; set; }

    public static PageList<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
    {
        Validate(pageNumber, pageSize);

        var count = source.Count();
        var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        return new PageList<T>(items, count, pageNumber, pageSize);
    }

    private static void Validate(int pageNumber, int pageSize)
    {
        if (pageNumber <= 0)
        {
            throw new RequiredFieldException("The pageNumber should be greater than zero.");
        }
        if (pageSize <= 0)
        {
            throw new RequiredFieldException("The pageSize should be greater than zero.");
        }
    }
}
