using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchPeopleDie.tv.Data;
using WatchPeopleDie.tv.Models;

namespace WatchPeopleDie.tv.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;
    readonly IBufferedFileUploadService _bufferedFileUploadService;

    public HomeController(ApplicationDbContext context, IBufferedFileUploadService bufferedFileUploadService, UserManager<User> userManager)
    {
        _userManager = userManager;
        _context = context;
        _bufferedFileUploadService = bufferedFileUploadService;

    }

    public IActionResult Index()
    {
        var videos = _context.Video
            .Include(v=> v.poster)
            .ToList();
        return View(videos);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(Video video, IFormFile videoFile)
    {
        try
        {
            if (videoFile != null)
            {
                // Update the file path after upload
                video.filePath = await _bufferedFileUploadService.UploadFile(videoFile);
                var userId = _userManager.GetUserId(User);

                // Get the current user's User object
                var currentUser = _userManager.FindByIdAsync(userId).Result;
                video.UserId = userId;
                video.poster = currentUser;

            }
            else
            {
                Console.WriteLine("No file uploaded."); // Log a message if no file is uploaded
            }

           
                Console.WriteLine("Create action is called.");

                // Ensure the file is not null before passing it to the upload service

                _context.Video.Add(video);
                await _context.SaveChangesAsync();

                Console.WriteLine("Video created successfully.");

                return RedirectToAction(nameof(Index));
            
                
        }
        
        catch (Exception ex)
        {
            Console.WriteLine($"Error in Create action: {ex.Message}"); // Log any exceptions
            throw; // Rethrow the exception to see the details in the console or log
        }

        Console.WriteLine("ModelState is not valid. Errors: {0}", string.Join("; ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))); // logging lol

        return View(video);
    }
    

    public IActionResult Edit()
    {
        throw new NotImplementedException();
    }

    // GET: Video/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Video == null)
        {
            return NotFound();
        }

        var video = await _context.Video
            .FirstOrDefaultAsync(m => m.Id == id);
        if (video == null)
        {
            return NotFound();
        }

        return View(video);
    }

    // POST: Video/Delete/5
    [Authorize]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Video == null)
        {
            return Problem("Entity set 'ApplicationDbContext.Video'  is null.");
        }
        var video = await _context.Video.FindAsync(id);
        if (video != null)
        {
            _context.Video.Remove(video);
        }
            
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool VideoExists(int id)
    {
        return (_context.Video?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}


 
