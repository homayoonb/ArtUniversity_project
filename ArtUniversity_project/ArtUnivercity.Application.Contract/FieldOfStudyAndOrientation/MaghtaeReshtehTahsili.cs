using System.ComponentModel.DataAnnotations;

namespace ArtUnivercity.Application.Contract.FieldOfStudyAndOrientation
{
    public enum MaghtaeReshtehTahsili
    {
        [Display(Name = "کاردانی")]
        kardany=1,
        [Display(Name = " کارشناسی ناپیوسته")]
        karshenasynapeyvasteh=2,
        [Display(Name = " کارشناسی پیوسته")]
        karshenasyvasteh=3,
        [Display(Name = "کارشناسی ارشد")]
        karshenasieArshad=4,
        [Display(Name = "دکترا")]
        doktora=5
    }
}