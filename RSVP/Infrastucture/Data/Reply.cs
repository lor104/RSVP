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
    
    public partial class Reply
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reply()
        {
            this.GuestEventJunctions = new HashSet<GuestEventJunction>();
        }
    
        public int RepliesID { get; set; }
        public bool Attending { get; set; }
        public string AttendeeEmail { get; set; }
        public Nullable<int> MealId { get; set; }
        public string Notes { get; set; }
        public string LicensePlate { get; set; }
    
        public virtual EventMeal EventMeal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GuestEventJunction> GuestEventJunctions { get; set; }
    }
}
