using System;
using System.ComponentModel.DataAnnotations;

namespace ATM.DataObjects.Entities
{
    public class BaseEntity
    {

        [Key]
        public Guid Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
    }
}
