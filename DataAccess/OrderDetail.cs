//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string OrderNumber { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> Discount { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<int> SKUId { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public Nullable<System.DateTime> ShipDate { get; set; }
        public Nullable<int> AddressId { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
