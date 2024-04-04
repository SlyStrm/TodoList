using System.ComponentModel.DataAnnotations;

namespace todolist.Data
{
    public class Gorev
    {
        [Key]
        public int GorevId { get; set; }

        public required string Aciklama { get; set; }

        public int  GorevDurum { get; set; } 

    }
}

