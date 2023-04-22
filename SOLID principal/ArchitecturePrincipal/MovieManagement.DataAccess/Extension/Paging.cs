using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Extension

{
    public enum SortDirection
    {
        [EnumMember]
        Ascending,
        [EnumMember]
        Descending
    }
    [DataContract]
    public class Paging
    {
        [DataMember]
        public SortDirection SortDirection { get; set; }
        [DataMember]
        public string SortColumn { get; set; }
        [DataMember]
        public int PageIndex { get; set; }
        [DataMember]
        public int PageSize { get; set; }

        public Paging() : this(0, 10)
        {

        }
        public Paging(int pageIndex, int pageSize)
        {
            SortDirection = SortDirection.Ascending;
            PageIndex = pageIndex;

        }
        public Paging(int pageSize, int pageIndex, string sortColumn) : this(pageIndex, pageSize)
        {
            SortColumn = sortColumn;
        }
        public Paging(int pageSize,int pageIndex, string sortColumn,SortDirection sortDirection):this(pageIndex,pageSize,sortColumn)
        {
            SortDirection = sortDirection;
        }
        public override string ToString()
        {
            return "SortColumn:" + SortColumn + " , PageIndex:" + PageIndex + ", PageSize:" + PageSize;
        }



    }


}
