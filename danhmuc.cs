//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaiThucHanh
{
    using System;
    using System.Collections.Generic;
    
    public partial class danhmuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public danhmuc()
        {
            this.sanphams = new HashSet<sanpham>();
        }
    
        public string madm { get; set; }
        public string tendm { get; set; }
        public Nullable<bool> trangthai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sanpham> sanphams { get; set; }

        public override string ToString()
        {
            return tendm;
        }
    }
}
