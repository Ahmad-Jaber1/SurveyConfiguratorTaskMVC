using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyConfiguratorTaskWeb.Models
{
    public class SliderQuestionViewModel
    {
        [Required]
        [Display(Name = "Start Value")]
        [Range(0,99)]
        public int StartValue { get; set; }
        [Required]
        [Display(Name = "End Value")]
        [Range(1, 100)]
        public int EndValue { get; set; }
        [Required]
        [Display(Name = "Start Caption")]
        public string StartCaption { get; set; }
        [Required]
        [Display(Name = "Start Caption")]
        public string EndCaption { get; set; }

        
    }
}