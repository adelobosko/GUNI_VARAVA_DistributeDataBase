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
    
    public partial class PerformedHeadOrder
    {
        public System.Guid ID_HeadOrder { get; set; }
        public System.Guid ID_Employee { get; set; }
        public System.Guid ID_PerformedOrder { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual HeadOrder HeadOrder { get; set; }
    }
}