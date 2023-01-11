using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortenUrl.Core;
using ShortenUrl.Core.Entities;
using ShortenUrl.Models;
using shortid;
using shortid.Configuration;

namespace ShortenUrl.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IShortenDbContext _context;
    private const string ServiceUrl = "http://localhost:5200/r";

    public HomeController(ILogger<HomeController> logger, IShortenDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    [HttpPost]
    public async Task<JsonResult> ShortenUrl(string longUrl)
    {
        // get shortened url collection
        //var shortenedUrlCollection = _mongoDatabase.GetCollection<ShortenedUrl>("shortened-urls");
        // first check if we have the url stored


        var shortenedUrl  = await _context.ShortenedUrls.FirstOrDefaultAsync(x => x.OriginalUrl == longUrl);
        
        // var shortenedUrl = await shortenedUrlCollection
        //     .AsQueryable()
        //     .FirstOrDefaultAsync(x => x.OriginalUrl == longUrl);

        // if the long url has not been shortened
        if (shortenedUrl == null)
        {
            var options = new GenerationOptions(useSpecialCharacters: false,useNumbers:true,length:9);
            var shortCode = ShortId.Generate(options);
            shortenedUrl = new ShortenedUrl
            {
                CreatedAt = DateTime.UtcNow,
                OriginalUrl = longUrl,
                ShortCode = shortCode,
                ShortUrl = $"{ServiceUrl}/{shortCode}"
            };
            // add to database
            _context.ShortenedUrls.Add(shortenedUrl);
            await _context.SaveChangesAsync();
            //await shortenedUrlCollection.InsertOneAsync(shortenedUrl);
        }
            
        return Json(shortenedUrl);
    }
    
    [HttpGet]
    [Route("{u}")]
    public async Task<IActionResult> Index(string u)
    {
        // // get shortened url collection
        // var shortenedUrlCollection = _mongoDatabase.GetCollection<ShortenedUrl>("shortened-urls");
        // first check if we have the short code
        var shortenedUrl  = await _context.ShortenedUrls.FirstOrDefaultAsync(x => x.ShortCode == u);
        // var shortenedUrl = await shortenedUrlCollection
        //     .AsQueryable()
        //     .FirstOrDefaultAsync(x => x.ShortCode == u);

        // // if the short code does not exist, send back to home page
        if (shortenedUrl == null)
        {
            return Redirect("/error/404");
            //return RedirectToAction(actionName:"Error",controllerName:"Home");
        }

        shortenedUrl.Clicked = shortenedUrl.Clicked +1;
        await _context.SaveChangesAsync();
        
        
        var remoteIpAddress = HttpContext.Connection.RemoteIpAddress;
        var ip = HttpContext.GetRemoteIPAddress().ToString();

        return Redirect(shortenedUrl.OriginalUrl);
    }

}