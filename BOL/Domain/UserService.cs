using BOL.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL.Domain
{
    public class UserService : BaseEntity
    {
        public string UserId { get; set; }

        public int ServiceId { get; set; }

        
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }
    }
}
