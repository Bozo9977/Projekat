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
    
    public partial class Ucenik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ucenik()
        {
            this.Prisustva = new HashSet<Prisustvo>();
            this.Rade = new HashSet<Radi>();
        }
    
        public int Id_ucenika { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public int OdeljenjeId_odeljenja { get; set; }
    
        public virtual Odeljenje Odeljenje { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prisustvo> Prisustva { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Radi> Rade { get; set; }
    }
}
