﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TransportManagerSystem.Models.ModelsData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RegionalTransportOfficeEntities : DbContext
    {
        public RegionalTransportOfficeEntities()
            : base("name=RegionalTransportOfficeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<ownerDetail> ownerDetails { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TransportType> TransportTypes { get; set; }
        public virtual DbSet<Usertype> Usertypes { get; set; }
        public virtual DbSet<Regional> Regionals { get; set; }
        public virtual DbSet<TransportDetail> TransportDetails { get; set; }
        public virtual DbSet<TransportPart> TransportParts { get; set; }
    }
}
