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
    
    public partial class Oblast
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Oblast()
        {
            this.Predavanja = new HashSet<Predavanje>();
            this.Casovi = new HashSet<Cas>();
        }
    
        public int Id_oblasti { get; set; }
        public string naziv { get; set; }
        public int PredmetId_predmeta { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Predavanje> Predavanja { get; set; }
        public virtual Predmet Predmet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cas> Casovi { get; set; }
    }
}
