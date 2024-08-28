using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lec5MVCL.Data;
using lec5MVCL.Models;
using lec5MVCL.ViewModels;

namespace lec5MVCL.Controllers
{
    public class SongsController(Lec5Context context) : Controller
    {
        // GET: Songs
        public async Task<IActionResult> Index()
        {
            var songs = await context.Songs.Include(s => s.Album).ToListAsync();
            //
            return View(songs);
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await context.Songs
                .Include(s => s.Album)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // GET: Songs/Create
        public async Task<IActionResult> Create()
        {
            var albums = await context.Alboms.ToListAsync();

            //pass the albums to view
            //ViewBag.Albums = albums;

            SongAlbomsViewModel vm = new SongAlbomsViewModel() { Albums = albums };

            return View(vm);
        }

        // POST: Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SongAlbomsViewModel vm)
        {

            if (ModelState.IsValid)
            {
                context.Add(vm.Song);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] Song song)
        {
            if (id != song.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(song);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.Id))
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
            return View(song);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await context.Songs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var song = await context.Songs.FindAsync(id);
            if (song != null)
            {
                context.Songs.Remove(song);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(int id)
        {
            return context.Songs.Any(e => e.Id == id);
        }
    }
}
