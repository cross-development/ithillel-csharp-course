using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Homework_13.Models;
using Homework_13.Data;

namespace Homework_13.Controllers;

public class ContactsController(AppDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var contacts = await dbContext.Contacts.ToListAsync();

        return View(contacts);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var contact = await dbContext.Contacts.FirstOrDefaultAsync(contact => contact.Id == id);

        if (contact is null)
        {
            return NotFound();
        }

        return View(contact);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Phone,AlternatePhone,Email,Description")] Contact contact)
    {
        if (!ModelState.IsValid)
        {
            return View(contact);
        }

        dbContext.Contacts.Add(contact);
        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var contact = await dbContext.Contacts.FindAsync(id);

        if (contact is null)
        {
            return NotFound();
        }

        return View(contact);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone,AlternatePhone,Email,Description")] Contact contact)
    {
        if (id != contact.Id || !ContactExists(contact.Id))
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(contact);
        }

        dbContext.Update(contact);
        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var contact = await dbContext.Contacts.FirstOrDefaultAsync(contact => contact.Id == id);

        if (contact is null)
        {
            return NotFound();
        }

        return View(contact);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var contact = await dbContext.Contacts.FindAsync(id);

        if (contact is not null)
        {
            dbContext.Contacts.Remove(contact);
        }

        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private bool ContactExists(int id)
    {
        return dbContext.Contacts.Any(contact => contact.Id == id);
    }
}
