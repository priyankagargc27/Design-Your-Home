using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesignYourHome.Data;
using DesignYourHome.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using DesignYourHome.Models.ContractorViewModels;


namespace DesignYourHome.Controllers
{
    public class ContractorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
     

        public ContractorsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Contractors
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var contractors = await _context.Contractor.Include(i => i.User).Include(c => c.Services).Where(u => u.User.StreetAddress == user.StreetAddress).ToListAsync();
            var model = new FindContractorsViewModel(_context);
            model.CurrentUser = user;
            model.Contractors = contractors;
            return View(model);
        }
        public async Task<IActionResult> Filter(FindContractorsViewModel model)
        {
            List<int> serviceIds = model.FilterServiceIds;
            if (serviceIds == null)
            {
                return RedirectToAction("Index");
            }
            var user = await GetCurrentUserAsync();
            var allContractors = await _context.Contractor.Include(i => i.User).Include(f => f.Services).Where(u => u.User.StreetAddress == user.StreetAddress).ToListAsync();
            var allContractorServices = await _context.ContractorServices.ToListAsync();
            var contractorServices = (from c in allContractorServices
                                      from s in serviceIds
                                      where c.ServiceId == s
                                      select c).ToList();
            //var filteredContractors = (from c in allContractors
            //                           from s in contractorServices
            //                           where c.ContractorId == s.ContractorId
            //                           select c).ToList();
            FindContractorsViewModel newModel = new FindContractorsViewModel(_context);
            //newModel.Contractors = filteredContractors;
            newModel.CurrentUser = user;
            return View(newModel);
        }

        // GET: Contractors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ContractorProfile profile = new ContractorProfile(_context, id);
            var contractor = await _context.Contractor.Include(u => u.User).Include(c => c.Services).SingleOrDefaultAsync(c => c.ContractorId == id);

            profile.Contractor = contractor;
            if (contractor == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // GET: Contractors/Create
        public async Task<IActionResult> Create()
        {
            CreateContractorViewModel model = new CreateContractorViewModel(_context);
            var user = await GetCurrentUserAsync();
            model.User = user;
            return View(model);
        }

        // POST: Contractors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateContractorViewModel model)
        {
            ModelState.Remove("Contractor.User");
            ModelState.Remove("Contractor.UserId");


            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                model.Contractor.User = user;
                model.Contractor.UserId = user.Id;

                _context.Add(model.Contractor);
                await _context.SaveChangesAsync();

       
                await _context.SaveChangesAsync();
                
                    foreach (int serviceId in model.SelectedServices)
                    {
                        ContractorService contractorServices = new ContractorService()
                        {
                            ServiceId = serviceId,
                            ContractorId = model.Contractor.ContractorId
                        };
                        await _context.AddAsync(contractorServices);
                    }
                
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
    ViewData["ServiceId"] = new SelectList(_context.Service,"serviceId","Name",model.Contractor.ContractorId);

            return View(model);
        }
        

        // GET: Contractors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractor = await _context.Contractor.FindAsync(id);
            if (contractor == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", contractor.UserId);
            return View(contractor);
        }

        // POST: Contractors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContractorId,UserId,Name,City,State,PhoneNumber,Website,CompanyName")] Contractor contractor)
        {
            if (id != contractor.ContractorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contractor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractorExists(contractor.ContractorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", contractor.UserId);
            return View(contractor);
        }

        // GET: Contractors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractor = await _context.Contractor
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.ContractorId == id);
            if (contractor == null)
            {
                return NotFound();
            }

            return View(contractor);
        }

        // POST: Contractors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contractor = await _context.Contractor.FindAsync(id);
            _context.Contractor.Remove(contractor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractorExists(int id)
        {
            return _context.Contractor.Any(e => e.ContractorId == id);
        }
    }
}
