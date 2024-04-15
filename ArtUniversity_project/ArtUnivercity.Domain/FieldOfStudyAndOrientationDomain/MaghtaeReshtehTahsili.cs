using System.ComponentModel.DataAnnotations;

namespace ArtUnivercity.Domain.FieldOfStudyAndOrientationDomain
{
    /// <summary>
    /// مقطع تحصیلی
    /// </summary>
    public enum MaghtaeReshtehTahsili
    {
        [Display(Name = "کاردانی")]
        kardany,
        [Display(Name = " کارشناسی ناپیوسته")]
        karshenasynapeyvasteh,
        [Display(Name = " کارشناسی پیوسته")]
        karshenasyvasteh,
        [Display(Name = "کارشناسی ارشد")]
        karshenasieArshad,
        [Display(Name = "دکترا")]
        doktora
    }
}
