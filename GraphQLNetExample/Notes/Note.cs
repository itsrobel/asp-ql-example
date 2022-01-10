using System.ComponentModel.DataAnnotations;

namespace GraphQLNetExample.Notes
{

    public class Note
    {
        public string? Id { get; set; }

        [Required]
        public string? Message { get; set; }
    }

}
