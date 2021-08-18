using System;
using System.ComponentModel.DataAnnotations;

namespace mtsDMO.Context.Utility
{
    public class Goals
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Goal title is required.")]
        [Display(Name="Title")]
        public string Name { get; set; }

        public DateTime InsDT { get; set; }

        public DateTime UpdDT { get; set; }

        public bool IsRemoved { get; set; }

        [Required(ErrorMessage ="UserId is required.")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage ="Total count required.")]
        [Display(Name="Power of")]
        public int Count { get; set; }
    }
}
