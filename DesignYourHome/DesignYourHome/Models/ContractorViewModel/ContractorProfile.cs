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
    public class ContractorProfile
    {
        public Contractor Contractor { get; set; }

        public List<Service> Services { get; set; }

        public ContractorProfile(ApplicationDbContext ctx, int? id)
        {
            var ContractorServices = ctx.ContractorServices.Where(c => c.ContractorId == id).Select(c => c.ServiceId).ToList();
            var allServices = ctx.Service.ToList();
            Services = (from s in allServices
                             from c in ContractorServices
                             where s.ServiceId == c
                             select s).ToList();
        }
    }
}