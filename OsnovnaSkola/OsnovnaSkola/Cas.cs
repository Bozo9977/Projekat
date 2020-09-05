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
    
    public partial class Cas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cas()
        {
            this.Imaju = new HashSet<Ima>();
            this.Prisustva = new HashSet<Prisustvo>();
            this.Kontrolna_tacka = new HashSet<Kontrolna_tacka>();
        }
    
        public int Id_casa { get; set; }
        public string pocetak { get; set; }
        public string kraj { get; set; }
        public System.DateTime datum { get; set; }
        public Nullable<int> OblastId_oblasti { get; set; }
        public int ZaposleniId_zaposlenog { get; set; }
    
        public virtual Oblast Oblast { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ima> Imaju { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prisustvo> Prisustva { get; set; }
        public virtual Zaposleni Zaposleni { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kontrolna_tacka> Kontrolna_tacka { get; set; }
    }
}
