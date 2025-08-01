using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Homework_13.Models;
using Homework_13.Data;

namespace Homework_13.Controllers;

public class NotesController(AppDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var notes = await dbContext.Notes.ToListAsync();

        return View(notes);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var note = await dbContext.Notes.FirstOrDefaultAsync(note => note.Id == id);

        if (note is null)
        {
            return NotFound();
        }

        return View(note);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,Text,Tags")] Note note)
    {
        if (!ModelState.IsValid)
        {
            return View(note);
        }

        note.CreatedAt = DateTime.Now;

        dbContext.Notes.Add(note);
        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var note = await dbContext.Notes.FindAsync(id);

        if (note is null)
        {
            return NotFound();
        }

        return View(note);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Text,CreatedAt,Tags")] Note note)
    {
        if (id != note.Id || !NoteExists(note.Id))
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(note);
        }

        dbContext.Notes.Update(note);
        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var note = await dbContext.Notes.FirstOrDefaultAsync(note => note.Id == id);

        if (note is null)
        {
            return NotFound();
        }

        return View(note);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var note = await dbContext.Notes.FindAsync(id);

        if (note is not null)
        {
            dbContext.Notes.Remove(note);
        }

        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private bool NoteExists(int id)
    {
        return dbContext.Notes.Any(note => note.Id == id);
    }
}
