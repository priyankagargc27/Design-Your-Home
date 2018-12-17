using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DesignYourHome.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesignYourHome.Models.ImageViewModels
{
    public class AddImageViewModel
    {
        public Image Image { get; set; }
        public List<SelectListItem> IdeaboardId { get; set; }

        public int chosenIdeaboard { get; set; }

        public ApplicationUser User { get; set; }

        public AddImageViewModel() { }
        public AddImageViewModel(ApplicationDbContext ctx, ApplicationUser user)
        {
            IdeaboardId = ctx.Ideaboard.Where(o => o.User.Id == user.Id)
                                    .OrderBy(l => l.Title)
                                    .AsEnumerable()
                                    .Select(li => new SelectListItem
                                    {
                                        Text = li.Title,
                                        Value = li.IdeaboardId.ToString()
                                    }).ToList();

            IdeaboardId.Insert(0, new SelectListItem
            {
                Text = "Choose an Ideaboard...",
                Value = "0"
            });

            //List<Tag> allTags = ctx.Tag.OrderBy(s => s.Name).ToList();
            //this.Tags = new MultiSelectList(allTags, "TagId", "Name");
        }
    }
}