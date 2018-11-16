using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace mvcGameReview.Models
{
    public class GameForumMessage
    {
        [Required]
        public long Id { get; set; }

        [DisplayName("Message Category Type")]
        public string Category { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Message Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        [DisplayName("Message")]
        public string Message { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime MessageDate { get; set; }

        public Boolean Approved { get; set; }
    }
}