using System.Collections.Generic;

namespace ATM.Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public int MobileNumber { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}
