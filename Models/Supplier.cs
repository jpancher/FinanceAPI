using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace financeAPI.Models
{
    public class Supplier
    {
        [Key]
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Document}";
        }
    }
}
