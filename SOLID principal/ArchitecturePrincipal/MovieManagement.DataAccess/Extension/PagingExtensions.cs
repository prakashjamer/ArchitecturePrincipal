using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Extension
{
    public static class PagingExtensions
    {
        private static List<Type> collections = new List<Type>
        {
            typeof(IEnumerable<>),
            typeof(IEnumerable)
        };
        public static PagedResult<T> GetPagedResult<T>(this IQueryable<T> query, Paging paging)
        {
            int num = query.Count();
            Paging paging2 = ResetPagingObjectIfInvalid(paging, num);
            return new PagedResult<T>(query.SortAndPage(paging2).ToArray(), num, paging2);
        }
        static Paging ResetPagingObjectIfInvalid(Paging paging, int recordCount)
        {
            if (paging == null)
                paging = new Paging(0, 10);
            if (paging.PageSize == 0)
                paging.PageSize = 100;
            double num = Math.Ceiling((double)recordCount / (double)paging.PageSize);
            if (paging.PageIndex < 0)
                paging.PageIndex = 0;
            if ((double)paging.PageIndex > ((num == 0.0) ? 0.0 : num - 1.0))
                paging.PageIndex = Convert.ToInt32(num - 1.0);
            return paging;
        }

        static IQueryable<T> SortAndPage<T>(this IQueryable<T> query, Paging paging)
        {
            if (paging == null)
                paging = new Paging(0, 100);
            if (string.IsNullOrEmpty(paging.SortColumn))
            {
                paging.SortColumn = (from p in typeof(T).GetProperties()
                                     where p.PropertyType == typeof(string)
                                     || !p.PropertyType.GetInterfaces().Any((Type i) =>
                                     collections.Any((Type c) => i == c))
                                     select p).First().Name;
            }

            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "p");
            string methodName = ((paging.SortDirection == SortDirection.Descending) ? "OrderByDescending" : "OrderBy");
            string[] array = paging.SortColumn.Split(new char[1] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            PropertyInfo property = typeof(T).GetProperty(array[0]);
            if (property == null)
            {
                throw new ArgumentNullException("Sort Column" + array[0] + "doesnot  exist");
            }
            MemberExpression memberexpression = Expression.MakeMemberAccess(parameterExpression, property);
            for (int i = 1; i < array.Length; i++)
            {
                property = property.PropertyType.GetProperty(array[i]);
                memberexpression = Expression.MakeMemberAccess(memberexpression, property);
            }
            LambdaExpression expression = Expression.Lambda(memberexpression, parameterExpression);
            Expression expression2 = Expression.Call(typeof(Queryable), methodName, new Type[2]
                {
                    typeof(T),
                    property.PropertyType,
                }, query.Expression, Expression.Quote(expression));
            query = query.Provider.CreateQuery<T>(expression2);
            return query.Skip(paging.PageIndex * paging.PageSize).Take(paging.PageSize);


        }
    }
}
