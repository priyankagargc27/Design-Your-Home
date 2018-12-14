using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DesignYourHome.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesignYourHome.Models.ContractorViewModels
{
    public class FindContractorsViewModel
    {
        public ApplicationUser CurrentUser { get; set; }

        public List<Contractor> Contractors { get; set; }

        [Display(Name = "Filter by Service")]
        public MultiSelectList Services { get; set; }

        public List<int> FilterServiceIds { get; set; }

        public FindContractorsViewModel() { }
        public FindContractorsViewModel(ApplicationDbContext ctx)
        {
            List<Service> allServices = ctx.Service.ToList();
            this.Services = new MultiSelectList(allServices, "ServiceId", "Name");
        }
    }
}