//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace web_cinema.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class cinemaEntities : DbContext
    {
        public cinemaEntities()
            : base("name=cinemaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<admin> admin { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<visitors> visitors { get; set; }
        public virtual DbSet<movies> movies { get; set; }
        public virtual DbSet<saloon> saloon { get; set; }
        public virtual DbSet<new_records> new_records { get; set; }
        public virtual DbSet<seats> seats { get; set; }
    }
}
