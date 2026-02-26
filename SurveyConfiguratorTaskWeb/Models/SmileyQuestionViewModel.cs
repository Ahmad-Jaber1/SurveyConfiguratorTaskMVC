using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyConfiguratorTaskWeb.Models
{
    public class SmileyQuestionViewModel
    {


        [Required]
        [Range(2,5)]
        [Display(Name ="Smiley Count")]
        public int SmileyCount { get; set; }
    }
}