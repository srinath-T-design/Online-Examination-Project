//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bussiness_Object_Layer.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class option_tb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public option_tb()
        {
            this.Answertbls = new HashSet<Answertbl>();
        }
    
        public int optionID { get; set; }
        public string optionsname { get; set; }
        public int quesID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answertbl> Answertbls { get; set; }
        public virtual Question Question { get; set; }
        public bool Checked { get; set; }
    }
}