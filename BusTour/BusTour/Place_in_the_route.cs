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
    
    public partial class Place_in_the_route
    {
        public int Place_in_the_route_Id { get; set; }
        public Nullable<int> Place_Id { get; set; }
        public Nullable<int> Route_Id { get; set; }
        public Nullable<int> Number_of_Day { get; set; }
        public string Day_Description { get; set; }
    
        public virtual Place Place { get; set; }
        public virtual Route Route { get; set; }
    }
}
