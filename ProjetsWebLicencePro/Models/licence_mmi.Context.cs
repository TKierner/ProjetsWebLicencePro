﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetsWebLicencePro.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class licence_mmiEntities : DbContext
    {
        public licence_mmiEntities()
            : base("name=licence_mmiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categorie> categorie { get; set; }
        public virtual DbSet<entreprise> entreprise { get; set; }
        public virtual DbSet<fonction> fonction { get; set; }
        public virtual DbSet<personne> personne { get; set; }
        public virtual DbSet<projet> projet { get; set; }
        public virtual DbSet<promo> promo { get; set; }
        public virtual DbSet<realisation> realisation { get; set; }
        public virtual DbSet<tache> tache { get; set; }
    }
}
