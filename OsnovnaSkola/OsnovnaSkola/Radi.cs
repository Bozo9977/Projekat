
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
    using System.Collections.Generic;
    
public partial class Radi
{

    public int Kontrolna_tackaId_kontrolne_tacke { get; set; }

    public int UcenikId_ucenika { get; set; }

    public int ZaposleniId_zaposlenog { get; set; }

    public short ocena { get; set; }



    public virtual Kontrolna_tacka Kontrolna_tacka { get; set; }

    public virtual Ucenik Ucenik { get; set; }

    public virtual Zaposleni Zaposleni { get; set; }

}

}
