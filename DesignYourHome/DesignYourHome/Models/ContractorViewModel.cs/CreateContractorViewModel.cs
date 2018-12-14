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
    public class CreateContractorViewModel
    {
        public Contractor Contractor { get; set; }

        public ApplicationUser User { get; set; }

        [Display(Name = "Contractor Tags")]
        public MultiSelectList Tags { get; private set; }
        public List<int> SelectedTags { get; set; }

        [Display(Name = "Services")]
        public MultiSelectList Services { get; private set; }
        public List<int> SelectedServices { get; set; }

        public CreateContractorViewModel() { }
        public CreateContractorViewModel(ApplicationDbContext ctx)
        {
            List<Service> allServices = ctx.Service.OrderBy(s => s.Name).ToList();
            this.Services = new MultiSelectList(allServices, "ServiceId", "Name");

           
        }
    }
}