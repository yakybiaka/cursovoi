//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusTour
{
    using System;
    using System.Collections.Generic;
    
    public partial class Place
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Place()
        {
            this.Place_in_the_route = new HashSet<Place_in_the_route>();
        }
    
        public int Place_Id { get; set; }
        public Nullable<int> City_Id { get; set; }
        public Nullable<int> Type_Place_Id { get; set; }
        public string Place_short_descr { get; set; }
        public string Place_Image_Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Place_in_the_route> Place_in_the_route { get; set; }
        public virtual Place_Type Place_Type { get; set; }
        public virtual City City { get; set; }
    }
}
