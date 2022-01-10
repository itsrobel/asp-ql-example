
using GraphQL.Types;
using GraphQLNetExample.EntityFramework;

namespace GraphQLNetExample.Notes
{

    public class NotesQuery : ObjectGraphType
    {
        public NotesQuery()
        {
            Field<ListGraphType<NoteType>>("notes", resolve: context => new List<Note> {
          new Note { Id = Guid.NewGuid().ToString().Replace("-", string.Empty), Message = "Hello World!" },
          new Note { Id = Guid.NewGuid().ToString().Replace("-", string.Empty), Message = "Hello World! How are you?" }
        });
            Field<ListGraphType<NoteType>>("notesFromEF", resolve: context =>
            {
                var DataContext = context.RequestServices.GetRequiredService<NotesContext>();

                var Notes = DataContext.Notes.ToArray();
                Console.WriteLine(Notes);
                // Console.WriteLine(DataContext.Notes);
                // foreach(var note in Notes)
                // {
                //     Console.WriteLine("COCK SUCKER");
                // }
                return DataContext.Notes.DefaultIfEmpty();
             
            }
            );
        }

    }

}
