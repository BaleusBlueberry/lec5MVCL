using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lec5MVCL.Data;
using lec5MVCL.Models;
using lec5MVCL.ViewModels;

namespace lec5MVCL.Controllers
{
    public class MoviesController(Lec5Context context) : Controller
    {
        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var movies = await context.Movie.Include(m=>m.Genres).ToListAsync();
            return View(movies);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var genres = await context.Genre.ToListAsync();
            var vm = new MovieWithGeneresViewModel()
            {
                Genres = genres.Select(g => new SelectGenre()
                {
                    Name = g.Name,
                    Id = g.Id,
                    IsSelected = false
                }).ToList()
            };
            return View(vm);
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieWithGeneresViewModel vm)
        {
            var genres = vm.Genres
                .Where(g => g.IsSelected)
                .Select(g => new Genre()
            {
                Name = g.Name,
                Id = g.Id,
            }).ToList();

            genres.ForEach(e => context.Attach(e));

            vm.Movie.Genres = genres;

            if (ModelState.IsValid)
            {
                context.Add(vm.Movie);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(movie);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
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
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await context.Movie.FindAsync(id);
            if (movie != null)
            {
                context.Movie.Remove(movie);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return context.Movie.Any(e => e.Id == id);
        }
    }
}
