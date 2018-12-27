using System.ComponentModel.DataAnnotations;

namespace MeMeMe.Models
{
    public class FabbisognioFlaconi
    {
        [Display(Name = "consegna")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        //[Required(ErrorMessage = "data obbligatoria")]
        public System.DateTime? dataConsegna { get; set; }

        [Display(Name = "scadenza")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        [UIHint("SoloDate")]
        //[Required(ErrorMessage = "data obbligatoria")]
        public System.DateTime? dataScadenza { get; set; }
    }

 }