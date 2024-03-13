using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QRMenuAPI.Models
{
	public class Restaurant
	{
        public int Id { get; set; }
        [StringLength(200, MinimumLength = 2)]
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; } = "";
        public byte StateId { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("StateId")]
        public State? State { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }
    }
}

