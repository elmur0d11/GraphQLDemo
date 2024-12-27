using HotChocolate;
using HotChocolate.Data;
using System.Linq;
using ToDoListQL.Data;
using ToDoListQL.Models;

namespace ToDoListQL.GraphQL
{
    public class Query
    { 
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemList> GetList([ScopedService] AppDbContext context)
        {
            return context.Lists;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemData> GetDatas([ScopedService] AppDbContext context)
        {
            return context.Items;
        }
    }
}
