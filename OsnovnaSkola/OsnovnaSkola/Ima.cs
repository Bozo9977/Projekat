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
    
    public partial class Ima
    {
        public int OdeljenjeId_odeljenja { get; set; }
        public int CasId_casa { get; set; }
    
        public virtual Odeljenje Odeljenje { get; set; }
        public virtual Cas Cas { get; set; }
    }
}