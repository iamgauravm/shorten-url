using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortenUrl.Core;
using ShortenUrl.Core.Entities;
using ShortenUrl.Models;
using shortid;
using shortid.Configuration;

namespace ShortenUrl.Controllers;


[Route("generate")]
public class GenerateController : Controller
{
    private readonly ILogger<GenerateController> _logger;
    private readonly IShortenDbContext _context;
    private const string ServiceUrl = "http://localhost:5200";

    public GenerateController(ILogger<GenerateController> logger, IShortenDbContext context)
    {
        _logger = logger;
        _context = context;
    }

   
    [HttpPost]
    [Route("shortenurl")]
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

}