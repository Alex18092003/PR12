//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PR12
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hotel
    {
        public Hotel()
        {
            this.HotelComment = new HashSet<HotelComment>();
            this.HotelImage = new HashSet<HotelImage>();
            this.HotelOfTour = new HashSet<HotelOfTour>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountOfStars { get; set; }
        public string CountryCode { get; set; }
        public string Description { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual ICollection<HotelComment> HotelComment { get; set; }
        public virtual ICollection<HotelImage> HotelImage { get; set; }
        public virtual ICollection<HotelOfTour> HotelOfTour { get; set; }
    }
}
