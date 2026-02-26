using SurveyConfiguratorTask.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyConfiguratorTaskWeb.Models
{
    public class BasicQuestionViewModel
    {
        [Required]
        [MaxLength(60)]
        public string Text { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int Order { get; set; }
        [Required]
        [Display(Name ="Type of Question")]
        public TypeQuestionEnum QuestionType { get; set; }
    }
}