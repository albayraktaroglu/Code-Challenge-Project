﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Code_Challenge_Project___Pluralsight
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_9CC311_infoalbayraktarEntities : DbContext
    {
        public DB_9CC311_infoalbayraktarEntities()
            : base("name=DB_9CC311_infoalbayraktarEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Distractor> Distractors { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
    }
}
