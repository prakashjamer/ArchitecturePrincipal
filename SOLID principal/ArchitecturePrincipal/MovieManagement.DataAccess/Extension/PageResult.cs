using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Extension
{
    public class PagedResult<T> : IEnumerable<T>, IEnumerable
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalNumberOfItems { get; set; }
        public Paging Pageing { get; set; }

        public PagedResult()
        {

        }
        public PagedResult(IEnumerable<T> items, int totalNumberOfItems, Paging pageing)
        {
            this.Items = items;
            this.TotalNumberOfItems = totalNumberOfItems;
            this.Pageing = pageing;

        }
        public int TotalNumberOfPages
        {
            get
            {
                if (Pageing == null || Pageing.PageSize <= 0)
                {
                    return 0;
                }
                return (int)Math.Ceiling((double)TotalNumberOfItems / (double)Pageing.PageSize);

            }

        }
        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}

