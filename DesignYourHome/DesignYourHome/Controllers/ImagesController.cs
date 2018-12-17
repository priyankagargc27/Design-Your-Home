using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesignYourHome.Data;
using DesignYourHome.Models;
using DesignYourHome.Models.ImageViewModels;
using Microsoft.AspNetCore.Identity;
using DesignYourHome.Models.ImageDetailViewModels;

namespace DesignDirect.Controllers
{
    public class ImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        public ImagesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: Image
        public async Task<IActionResult> Index()
        {
            var allImages = await _context.Image.Include(i => i.Room).Include(i => i.Style).Take(33).ToListAsync();
            var model = new FilterResultsModel(_context);
            model.Images = allImages;
            return View(model);
        }

        // GET: Image/Details/5
        public async Task<IActionResult> AddToIdeaboard(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await GetCurrentUserAsync();

            var model = new AddImageViewModel(_context, user);

            model.Image = await _context.Image
                .Include(i => i.Room)
                .Include(i => i.Style)
                .SingleOrDefaultAsync(m => m.ImageId == id);

            return View(model);
        }
        // save the image to the ideaboard
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(AddImageViewModel model)
        {
            ModelState.Remove("User");
            model.User = await GetCurrentUserAsync();
            var ideaboardImage = new IdeaImage();
            ideaboardImage.IdeaboardId = model.chosenIdeaboard;
            ideaboardImage.ImageId = model.Image.ImageId;

            if (ModelState.IsValid)
            {
                _context.Add(ideaboardImage);
                await _context.SaveChangesAsync();

               
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        // Filter the images by style and room
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Filter(FilterResultsModel model)
        {
            List<int> roomIds = model.FilterRoomIds;
            List<int> styleIds = model.FilterStyleIds;
            var allImages = await _context.Image.ToListAsync();
            FilterResultsModel newModel = new FilterResultsModel(_context);

            if (roomIds == null && styleIds == null)
            {
                newModel.Images = allImages;
            }

            if (styleIds != null)
            {
                var match = (from i in allImages
                             from s in styleIds
                             where i.StyleId == s
                             select i).ToList();
                newModel.Images = match;
            }

            if (roomIds != null)
            {
                var match = (from i in allImages
                             from r in roomIds
                             where i.RoomId == r
                             select i).ToList();
                newModel.Images = match;
            }

            if (styleIds != null && roomIds != null)
            {
                var match = (from i in allImages
                             from r in roomIds
                             from s in styleIds
                             where i.StyleId == s
                             where i.RoomId == r
                             select i).ToList();
                newModel.Images = match;
            }
            return View(newModel);
        }


        // GET: Image/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Set<Room>(), "RoomId", "Name");
            ViewData["StyleId"] = new SelectList(_context.Set<Style>(), "StyleId", "Name");
            return View();
        }

        // POST: Image/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,Description,Source,RoomId,StyleId")] Image image)
        {
            if (ModelState.IsValid)
            {
                _context.Add(image);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["RoomId"] = new SelectList(_context.Set<Room>(), "RoomId", "Name", image.RoomId);
            ViewData["StyleId"] = new SelectList(_context.Set<Style>(), "StyleId", "Name", image.StyleId);
            return View(image);
        }

        // GET: Image/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Image.SingleOrDefaultAsync(m => m.ImageId == id);
            if (image == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Set<Room>(), "RoomId", "Name", image.RoomId);
            ViewData["StyleId"] = new SelectList(_context.Set<Style>(), "StyleId", "Name", image.StyleId);
            return View(image);
        }

        // POST: Image/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageId,Description,Source,RoomId,StyleId")] Image image)
        {
            if (id != image.ImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(image);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageExists(image.ImageId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["RoomId"] = new SelectList(_context.Set<Room>(), "RoomId", "Name", image.RoomId);
            ViewData["StyleId"] = new SelectList(_context.Set<Style>(), "StyleId", "Name", image.StyleId);
            return View(image);
        }

        // GET: Image/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Image
                .Include(i => i.Room)
                .Include(i => i.Style)
                .SingleOrDefaultAsync(m => m.ImageId == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var image = await _context.Image.SingleOrDefaultAsync(m => m.ImageId == id);
            _context.Image.Remove(image);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ImageExists(int id)
        {
            return _context.Image.Any(e => e.ImageId == id);
        }
    }
}