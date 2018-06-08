using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Domain
{
    public class Company : BaseEntity
    {
        public Company()
        {
            this.Services = new HashSet<Service>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Service> Services { get; set; }

    }
}
