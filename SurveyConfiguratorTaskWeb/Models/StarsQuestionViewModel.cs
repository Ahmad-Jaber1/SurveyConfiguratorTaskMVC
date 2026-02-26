using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyConfiguratorTaskWeb.Models
{
    public class StarsQuestionViewModel
    {
        [Required]
        [Range(1,10)]
        [Display(Name ="Stars Count")]
        public int StarsCount { get; set; }
    }
}