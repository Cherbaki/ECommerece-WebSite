using RealShop.Areas.Identity.Data;
using RealShop.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace RealShop.Models
{
#nullable disable

    public static class IndexPageExtensions{

         public static IQueryable<IndexPageModel> ToModel(this IQueryable<IndexPageEntity> entity)
         {
            return entity.Select(e => new IndexPageModel
            {
                EntityId = e.Id,
                TopImage = e.TopImage,
                TopImageId = e.TopImageId,
                SpecificImage = e.SpecificImage,
                SpecificImageId = e.SpecificImageId
            });
         }
    }
    public class IndexPageEntity
    {
        [Key]
        public int Id { get; set;}
        [Required]
        public Image TopImage { get; set; }
        [Required]        
        public int TopImageId { get; set; }
        [Required]
        public Image SpecificImage { get; set; }
        [Required]
        public int SpecificImageId { get; set; }

    }
}
