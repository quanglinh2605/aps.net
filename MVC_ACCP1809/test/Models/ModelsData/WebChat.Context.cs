﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace test.Models.ModelsData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WebChatEntities1 : DbContext
    {
        public WebChatEntities1()
            : base("name=WebChatEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<groupDetail> groupDetails { get; set; }
        public virtual DbSet<GroupChat> GroupChats { get; set; }
        public virtual DbSet<UserChat> UserChats { get; set; }
    }
}
