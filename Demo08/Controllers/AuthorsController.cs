
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo08.Models;

public class AuthorsController : Controller
{
    private readonly SystemDbContext _context;

    public AuthorsController(SystemDbContext context)
    {
        _context = context;
    }

    // GET: AUTHORS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Authors.ToListAsync());
    }

    // GET: AUTHORS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var author = await _context.Authors
            .FirstOrDefaultAsync(m => m.Id == id);
        if (author == null)
        {
            return NotFound();
        }

        return View(author);
    }

    // GET: AUTHORS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: AUTHORS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name")] Author author)
    {
        if (ModelState.IsValid)
        {
            _context.Add(author);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(author);
    }

    // GET: AUTHORS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var author = await _context.Authors.FindAsync(id);
        if (author == null)
        {
            return NotFound();
        }
        return View(author);
    }

    // POST: AUTHORS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name")] Author author)
    {
        if (id != author.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(author);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(author.Id))
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
        return View(author);
    }

    // GET: AUTHORS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var author = await _context.Authors
            .FirstOrDefaultAsync(m => m.Id == id);
        if (author == null)
        {
            return NotFound();
        }

        return View(author);
    }

    // POST: AUTHORS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author != null)
        {
            _context.Authors.Remove(author);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AuthorExists(int? id)
    {
        return _context.Authors.Any(e => e.Id == id);
    }
}
