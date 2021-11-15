namespace CoolMvcTemplate.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    using CoolMvcTemplate.Data.Common.Models;

    public class AppRole : IdentityRole, IAuditable, IDeletable
    {
        public AppRole() : this(null)
        {
        }

        public AppRole(string? name) : base(name)
        {
            Id = Guid.NewGuid().ToString();
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
