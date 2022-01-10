using GraphQL;
using GraphQL.Types;
using GraphQLNetExample.EntityFramework;

namespace GraphQLNetExample.Notes
{
    public class NotesMutation : ObjectGraphType
    {
        public NotesMutation()
        {
            Field<NoteType>(
                "createNote",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "message"}
                ),
                resolve: context =>
                {
                    var message = context.GetArgument<string>("message");
                    var id = Guid.NewGuid().ToString().Replace("-", string.Empty);
                    var DataContext = context.RequestServices.GetRequiredService<NotesContext>();
                    Note note = new Note
                    {
                        Id   = id,
                        Message = message,
                    };
                    Console.WriteLine(note.Message);
                    DataContext.Notes.Add(note);
                    DataContext.SaveChanges();
                    return note;
                }
            );
        }
    }
}
