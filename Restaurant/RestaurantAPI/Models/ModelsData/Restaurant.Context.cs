﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestaurantAPI.Models.ModelsData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RESTAURANTEntities : DbContext
    {
        public RESTAURANTEntities()
            : base("name=RESTAURANTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<checkOrder> checkOrders { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<tablenumber> tablenumbers { get; set; }
    }
}