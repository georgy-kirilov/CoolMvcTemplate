namespace CoolMvcTemplate.Data.Common.Models
{
    using System;

    public interface IAuditable
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
