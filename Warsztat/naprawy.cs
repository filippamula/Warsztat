//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Warsztat
{
    using System;
    using System.Collections.Generic;
    
    public partial class naprawy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public naprawy()
        {
            this.czynnosci_naprawcze = new HashSet<czynnosci_naprawcze>();
        }
    
        public int idNaprawy { get; set; }
        public System.DateTime data_przyjecia { get; set; }
        public System.DateTime termin { get; set; }
        public Nullable<System.DateTime> data_wydania { get; set; }
        public int idSamochodu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<czynnosci_naprawcze> czynnosci_naprawcze { get; set; }
        public virtual samochody samochody { get; set; }
    }
}
