//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SushkovPW5.BDmodel
{
    using System;
    using System.Collections.Generic;
    
    public partial class TrailerDriver
    {
        public int ID { get; set; }
        public Nullable<int> IDDriver { get; set; }
        public Nullable<int> IDTrailer { get; set; }
        public Nullable<int> IDOrder { get; set; }
        public int IDRoleInTrailer { get; set; }
    
        public virtual Driver Driver { get; set; }
        public virtual Order Order { get; set; }
        public virtual RoleInTrailer RoleInTrailer { get; set; }
        public virtual Trailer Trailer { get; set; }
    }
}