using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace EntityFrameworkTutorial.Data.Models
{

    public partial class Shipper
    {
        public Shipper()
        {
            this.Orders = new List<Order>();
        }

        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
