using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mtsDMO.Context.Utility
{
    public class Journal
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        [Required]
        public Guid GoalId { get; set; }

        public string Comment { get; set; }

        public DateTime InsDT { get; set; }

        public DateTime UpdDT { get; set; }

        public bool IsRemoved { get; set; }
    }
}
