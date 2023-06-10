﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tech_Market_WebMVC7UI.Models
{
    [Table("OrderStatus")]
    public class OrderStatus
    {

        public int Id { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        [MaxLength(40)]
        public string ?StatusName { get; set; }

    }
}
