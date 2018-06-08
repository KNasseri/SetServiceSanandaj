using System.ComponentModel.DataAnnotations;

namespace BOL.Data
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
