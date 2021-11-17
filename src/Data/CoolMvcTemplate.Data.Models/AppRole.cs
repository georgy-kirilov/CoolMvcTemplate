namespace CoolMvcTemplate.Data.Models
{
    using CoolMvcTemplate.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class AppRole : IdentityRole, IAuditable, IDeletable
    {
        public AppRole()
            : this(null)
        {
        }

        public AppRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
