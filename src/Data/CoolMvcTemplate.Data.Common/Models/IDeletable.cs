namespace CoolMvcTemplate.Data.Common.Models
{
    using System;

    public interface IDeletable
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
