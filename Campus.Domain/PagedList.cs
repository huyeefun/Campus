using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.Domain
{
    public class PagedList<T>
    {
        public PagedList(IEnumerable<T> list, int count)
        {
            Source = list;
            Count = count;
        }

        public IEnumerable<T> Source { get; set; }
        public int Count { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; } = 10;

        public double PageCount
        {
            get => Math.Ceiling((double)Count / PageSize);
        }
    }
}
