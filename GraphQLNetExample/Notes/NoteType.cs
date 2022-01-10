using GraphQL.Types;
namespace GraphQLNetExample.Notes
{
    public class NoteType : ObjectGraphType<Note>
    {
        public NoteType()
        {
            Name = "Note";
            Field(x => x.Id ).Description("Note Id");
            Field(x => x.Message).Description("Note Message");
        }

    }
}