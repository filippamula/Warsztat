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
    
    public partial class klienci
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public klienci()
        {
            this.samochody = new HashSet<samochody>();
        }
    
        public int idKlienta { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string PESEL { get; set; }
        public int idDane { get; set; }
    
        internal virtual dane_kontaktowe dane_kontaktowe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        internal virtual ICollection<samochody> samochody { get; set; }
    }
}
