﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LayoutEg.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbMovieShopEntities : DbContext
    {
        public dbMovieShopEntities()
            : base("name=dbMovieShopEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblDisc> tblDiscs { get; set; }
        public virtual DbSet<tblMovie> tblMovies { get; set; }
        public virtual DbSet<UserData> UserDatas { get; set; }

        public System.Data.Entity.DbSet<LayoutEg.Models.SampleUserData> SampleUserDatas { get; set; }
    }
}
