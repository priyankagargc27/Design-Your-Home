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
using DesignYourHome.Models.ImageViewModels;

namespace DesignYourHome.Controllers
{
    public class IdeaboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public IdeaboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        // GET: Ideaboards
        [Authorize]

        public async Task<IActionResult> Index()
        {
            IdeaboardsViewModel model = new IdeaboardsViewModel();
            var user = await GetCurrentUserAsync();
            model.Ideaboards = await _context.Ideaboard.Where(i => i.User.Id == user.Id).ToListAsync();
            
            var allContractors = await _context.Contractor.Include(i => i.User).Include(f => f.Services).ToListAsync();
            model.MatchingContractors = (from c in allContractors
                                         select c).Distinct().Take(6).ToList();
            model.Services = await _context.Service.ToListAsync();
            model.CurrentUser = user;
            return View(model);
        }

        // GET: Ideaboard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaboard = await _context.Ideaboard
                .SingleOrDefaultAsync(m => m.IdeaboardId == id);
            if (ideaboard == null)
            {
                return NotFound();
            }
            var user = await GetCurrentUserAsync();
            var model = new ImageDetailViewModel(_context, user, ideaboard.IdeaboardId);
            model.Ideaboard = ideaboard;

            return View(model);
        }

        // GET: Ideaboards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ideaboards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdeaboardId,Title")] Ideaboard ideaboard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ideaboard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ideaboard);
        }

        // GET: Ideaboards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaboard = await _context.Ideaboard.FindAsync(id);
            if (ideaboard == null)
            {
                return NotFound();
            }
            return View(ideaboard);
        }

        // POST: Ideaboards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdeaboardId,Title")] Ideaboard ideaboard)
        {
            if (id != ideaboard.IdeaboardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ideaboard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdeaboardExists(ideaboard.IdeaboardId))
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
            return View(ideaboard);
        }

        // GET: Ideaboards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaboard = await _context.Ideaboard
                .FirstOrDefaultAsync(m => m.IdeaboardId == id);
            if (ideaboard == null)
            {
                return NotFound();
            }

            return View(ideaboard);
        }

        // POST: Ideaboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ideaboard = await _context.Ideaboard.FindAsync(id);
            _context.Ideaboard.Remove(ideaboard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdeaboardExists(int id)
        {
            return _context.Ideaboard.Any(e => e.IdeaboardId == id);
        }
    }
}
