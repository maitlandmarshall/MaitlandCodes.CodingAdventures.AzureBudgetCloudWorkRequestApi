using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MaitlandCodes.CodingAdventures.BudgetCloudWorkRequestApi.Data
{
    [Table(nameof(WorkRequest))]
    public class WorkRequest
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }
    }
}
