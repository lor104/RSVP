//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RSVP.Infrastucture.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            this.EventMeals = new HashSet<EventMeal>();
            this.GuestEventJunctions = new HashSet<GuestEventJunction>();
        }
    
        public int EventID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public System.DateTime EventStartDate { get; set; }
        public System.DateTime EventEndDate { get; set; }
        public string Venue { get; set; }
        public string Address { get; set; }
        public System.TimeSpan EventStartTime { get; set; }
        public System.TimeSpan EventEndTime { get; set; }
        public string Details { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventMeal> EventMeals { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GuestEventJunction> GuestEventJunctions { get; set; }
    }
}
