//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _21S2_BZ_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            this.Appointment = new HashSet<Appointment>();
        }
    
        public int Id { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        public string f_name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string l_name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string address { get; set; }

        [Required, MaxLength(10), MinLength(10)]
        public string phone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
