﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kyrsac
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbZavgorodEntities2 : DbContext
    {
        public dbZavgorodEntities2()
            : base("name=dbZavgorodEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<все_заказы> все_заказы { get; set; }
        public virtual DbSet<клиент> клиент { get; set; }
        public virtual DbSet<поставка> поставка { get; set; }
        public virtual DbSet<поставщик> поставщик { get; set; }
        public virtual DbSet<состав_заказа> состав_заказа { get; set; }
        public virtual DbSet<товар> товар { get; set; }
        public virtual DbSet<Security> Security { get; set; }
    }
}