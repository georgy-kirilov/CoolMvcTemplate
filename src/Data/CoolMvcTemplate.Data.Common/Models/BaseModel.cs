﻿namespace CoolMvcTemplate.Data.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseModel<TKey> : IAuditable
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
