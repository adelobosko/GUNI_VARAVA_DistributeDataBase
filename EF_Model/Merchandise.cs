//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF_Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Merchandise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Merchandise()
        {
            this.Purchase = new HashSet<Purchase>();
        }
    
        public System.Guid ID_Merchandise { get; set; }
        public System.Guid ID_Product { get; set; }
        public System.Guid ID_RealEstate { get; set; }
        public int Weight { get; set; }
        public System.DateTime ManufactureDate { get; set; }
        public int PricePerGramm { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase> Purchase { get; set; }
        public virtual RealEstate RealEstate { get; set; }
        public virtual Product Product { get; set; }
    }
}
