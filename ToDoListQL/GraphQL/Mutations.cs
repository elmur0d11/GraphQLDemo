using HotChocolate;
using HotChocolate.Data;
using System.Threading.Tasks;
using ToDoListQL.Data;
using ToDoListQL.GraphQL.DataItem;
using ToDoListQL.GraphQL.Lists;
using ToDoListQL.Models;

namespace ToDoListQL.GraphQL
{
    public class Mutations
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddListPayload> AddListAsync(AddListInput input, [ScopedService] AppDbContext context)
        {
            var list = new ItemList
            {
                Name = input.Name
            };

            context.Lists.Add(list);
            await context.SaveChangesAsync();

            return new AddListPayload(list);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddItemPayload> AddItemAsync(AddItemInput input, [ScopedService] AppDbContext context)
        {
            var item = new ItemData
            {
                IsDone = input.isDone,
                ListId = input.listId,
                Title = input.title,
                Description = input.description
            };

            context.Items.Add(item);
            await context.SaveChangesAsync();
            return new AddItemPayload(item);
        }
    }
}
