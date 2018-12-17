using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DesignYourHome.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesignYourHome.Models.ImageDetailViewModels
{
    public class ImageDetailViewModel
    {
        public Ideaboard Ideaboard { get; set; }

        public IEnumerable<Image> Images { get; set; }

        public ImageDetailViewModel(ApplicationDbContext ctx, ApplicationUser user, int IdeaboardId)
        {
            List<Image> images = new List<Image>();
            var allImages = ctx.Image.ToList();
            var ideaboardImage = ctx.IdeaImage.Where(i => i.IdeaboardId == IdeaboardId).ToList();
            var imagesOnIdeaboard = (from i in allImages
                                     join id in ideaboardImage on i.ImageId equals id.ImageId
                                     select i
                                   ).ToList();
            foreach (var image in imagesOnIdeaboard)
            {
                images.Add(image);
            }

            Images = images;
        }
    }
}