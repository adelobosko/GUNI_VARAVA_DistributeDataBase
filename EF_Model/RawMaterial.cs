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
    
    public partial class RawMaterial
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RawMaterial()
        {
            this.RawMaterialProviderContract = new HashSet<RawMaterialProviderContract>();
            this.StockRawMaterial = new HashSet<StockRawMaterial>();
            this.Component = new HashSet<Component>();
        }
    
        public System.Guid ID_RawMaterial { get; set; }
        public string RawMaterialName { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public Nullable<int> MinTemperature { get; set; }
        public Nullable<int> MaxTemperature { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RawMaterialProviderContract> RawMaterialProviderContract { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockRawMaterial> StockRawMaterial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Component> Component { get; set; }
    }
}
