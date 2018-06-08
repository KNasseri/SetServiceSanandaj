using BOL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Domain
{
    public class Service : BaseEntity
    {
        public Service()
        {
            this.UserServices = new HashSet<UserService>();
        }

        /// <summary>
        /// نام خدمت
        /// </summary>
        public string Name { get; set; }
        public string Icon { get; set; }
        /// <summary>
        /// آدرس سایت
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// توضیخات مختصر
        /// </summary>
        public string Intro { get; set; }
        /// <summary>
        /// شرح کلی خدمت
        /// </summary>
        public string Description { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }


        public virtual ICollection<UserService> UserServices { get; set; }
    }
}
