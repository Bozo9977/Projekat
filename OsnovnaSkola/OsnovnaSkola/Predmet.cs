
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
    
public partial class Predmet
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Predmet()
    {

        this.Oblasti = new HashSet<Oblast>();

        this.Nastavnici = new HashSet<Nastavnik>();

    }


    public int Id_predmeta { get; set; }

    public short razred { get; set; }

    public string naziv { get; set; }

    public short broj_oblasti { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Oblast> Oblasti { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Nastavnik> Nastavnici { get; set; }

}

}
