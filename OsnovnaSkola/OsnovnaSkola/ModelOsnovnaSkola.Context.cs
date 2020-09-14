﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace OsnovnaSkola
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;
using System.Linq;


public partial class ModelOsnovnaSkolaContainer : DbContext
{
    public ModelOsnovnaSkolaContainer()
        : base("name=ModelOsnovnaSkolaContainer")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Zaposleni> Zaposlenici { get; set; }

    public virtual DbSet<Kontrolna_tacka> Kontrolna_tacka { get; set; }

    public virtual DbSet<Predavanje> Predavanja { get; set; }

    public virtual DbSet<Oblast> Oblasti { get; set; }

    public virtual DbSet<Cas> Cas { get; set; }

    public virtual DbSet<Predmet> Predmeti { get; set; }

    public virtual DbSet<Odeljenje> Odeljenja { get; set; }

    public virtual DbSet<Ucenik> Ucenici { get; set; }

    public virtual DbSet<Ima> Imaju { get; set; }

    public virtual DbSet<Prisustvo> Prisustva { get; set; }

    public virtual DbSet<Radi> Rade { get; set; }

    public virtual DbSet<NastavnikOdeljenje> NastavnikOdeljenjes { get; set; }


    public virtual int DodajKontrolnuTackuUceniku(Nullable<int> idUcenika, Nullable<int> idZaposlenog, Nullable<int> idKontrolneTacke, Nullable<short> ocena, ObjectParameter success)
    {

        var idUcenikaParameter = idUcenika.HasValue ?
            new ObjectParameter("idUcenika", idUcenika) :
            new ObjectParameter("idUcenika", typeof(int));


        var idZaposlenogParameter = idZaposlenog.HasValue ?
            new ObjectParameter("idZaposlenog", idZaposlenog) :
            new ObjectParameter("idZaposlenog", typeof(int));


        var idKontrolneTackeParameter = idKontrolneTacke.HasValue ?
            new ObjectParameter("idKontrolneTacke", idKontrolneTacke) :
            new ObjectParameter("idKontrolneTacke", typeof(int));


        var ocenaParameter = ocena.HasValue ?
            new ObjectParameter("ocena", ocena) :
            new ObjectParameter("ocena", typeof(short));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DodajKontrolnuTackuUceniku", idUcenikaParameter, idZaposlenogParameter, idKontrolneTackeParameter, ocenaParameter, success);
    }


    [DbFunction("ModelOsnovnaSkolaContainer", "GetKontrolnuTackuAndRadeForZaposleniAndKontrolnaTacka")]
    public virtual IQueryable<GetKontrolnuTackuAndRadeForZaposleniAndKontrolnaTacka_Result> GetKontrolnuTackuAndRadeForZaposleniAndKontrolnaTacka(Nullable<int> idZaposlenog, Nullable<int> idKontrolneTacke)
    {

        var idZaposlenogParameter = idZaposlenog.HasValue ?
            new ObjectParameter("idZaposlenog", idZaposlenog) :
            new ObjectParameter("idZaposlenog", typeof(int));


        var idKontrolneTackeParameter = idKontrolneTacke.HasValue ?
            new ObjectParameter("idKontrolneTacke", idKontrolneTacke) :
            new ObjectParameter("idKontrolneTacke", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<GetKontrolnuTackuAndRadeForZaposleniAndKontrolnaTacka_Result>("[ModelOsnovnaSkolaContainer].[GetKontrolnuTackuAndRadeForZaposleniAndKontrolnaTacka](@idZaposlenog, @idKontrolneTacke)", idZaposlenogParameter, idKontrolneTackeParameter);
    }

}

}

