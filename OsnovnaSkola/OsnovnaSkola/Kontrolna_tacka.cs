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
    
    public partial class Kontrolna_tacka
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kontrolna_tacka()
        {
            this.Rade = new HashSet<Radi>();
        }
    
        public int Id_kontrolne_tacke { get; set; }
        public string zadatak { get; set; }
        public int ZaposleniId_zaposlenog { get; set; }
    
        public virtual Zaposleni Zaposleni { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Radi> Rade { get; set; }
        public virtual Oblast Oblast { get; set; }
    }
}
