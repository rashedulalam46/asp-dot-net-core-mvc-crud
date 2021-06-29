using System;
using System.ComponentModel.DataAnnotations;


namespace ASP.NET_Core_MVC_Crud.Models
{
    public class Customers
    {
       [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> InsertDate { get; set; }
        public string InsertedBy { get; set; }
    }
}
