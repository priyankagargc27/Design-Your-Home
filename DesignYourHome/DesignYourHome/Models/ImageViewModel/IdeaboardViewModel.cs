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
    public class IdeaboardsViewModel
    {
        public List<Ideaboard> Ideaboards { get; set; }

        public List<Contractor> MatchingContractors { get; set; }

        public List<Service> Services { get; set; }

        public ApplicationUser CurrentUser { get; set; }
    }
}