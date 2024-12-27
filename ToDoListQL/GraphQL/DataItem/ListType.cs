using HotChocolate;
using HotChocolate.Types;
using System.Linq;
using ToDoListQL.Data;
using ToDoListQL.Models;

namespace ToDoListQL.GraphQL.DataItem
{
    public class ListType : ObjectType<ItemList>
    {
        protected override void Configure(IObjectTypeDescriptor<ItemList> descriptor)
        {
            descriptor.Description("This model is used as Item for the to do list");

            descriptor.Field(x => x.ItemDatas)
                .ResolveWith<Resolvers>(x => x.GetItems(default!, default))
                .UseDbContext<AppDbContext>()
                .Description("This is the list that the Item belongs to");
        }

        private class Resolvers
        {
            public IQueryable<ItemData> GetItems(ItemList list, [ScopedService] AppDbContext context)
            {
                return context.Items.Where(x => x.ListId == list.Id);
            }
        }
    }
}
