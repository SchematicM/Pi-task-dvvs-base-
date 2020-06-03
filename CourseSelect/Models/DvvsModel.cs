using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CourseSelect.Models
{
    public class DvvsModel 
    {
        [Required]
        [Display(Name = "TeacherId")]
        public string TeacherId { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "EndDate")]
        public DateTime? EndDate { get; set; }
        [Required]
        [Display(Name = "NumberOfSeats")]
        public int? NumberOfSeats { get; set; }

        public IEnumerable <AspNetUsers> Teachers { get; set; }
    }
}