using System;
using System.ComponentModel.DataAnnotations;

namespace mtsDMO.Context.Utility
{
    public class Connections
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [Required]
        public Guid GoalId { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
        public DateTime InsDT { get; set; }
        public DateTime UpdDT { get; set; }
        public bool IsRemoved { get; set; }
    }
}
