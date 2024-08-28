using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lec5MVCL.Data;
using lec5MVCL.Models;

namespace lec5MVCL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GAPIController(Lec5Context context) : ControllerBase
{
    // GET: api/GAPI
    [HttpGet]
    public async Task<ActionResult> GetGenre()
    {
        var genres = await context.Genre.ToListAsync();
        return Ok(genres);
    }

    /*// GET: api/GAPI/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Genre>> GetGenre(int id)
    {
        var genre = await context.Genre.FindAsync(id);

        if (genre == null)
        {
            return NotFound();
        }

        return genre;
    }

    // PUT: api/GAPI/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGenre(int id, Genre genre)
    {
        if (id != genre.Id)
        {
            return BadRequest();
        }

        context.Entry(genre).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!GenreExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/GAPI
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Genre>> PostGenre(Genre genre)
    {
        context.Genre.Add(genre);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetGenre", new { id = genre.Id }, genre);
    }

    // DELETE: api/GAPI/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGenre(int id)
    {
        var genre = await context.Genre.FindAsync(id);
        if (genre == null)
        {
            return NotFound();
        }

        context.Genre.Remove(genre);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool GenreExists(int id)
    {
        return context.Genre.Any(e => e.Id == id);
    }*/
}

