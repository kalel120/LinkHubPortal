﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL {
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class LinkHubDbEntities : DbContext {
        public LinkHubDbEntities()
            : base( "name=LinkHubDbEntities" ) {
        }

        protected override void OnModelCreating( DbModelBuilder modelBuilder ) {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<tbl_Category> tbl_Category { get; set; }
        public virtual DbSet<tbl_Url> tbl_Url { get; set; }
        public virtual DbSet<tbl_User> tbl_User { get; set; }
    }
}
