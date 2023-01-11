using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShortenUrl.Core.Entities;

public class ShortenedUrl
{
    [Key]
    public long Id { get; set; }
    public string OriginalUrl { get; set; }
    public string ShortCode { get; set; }
    public string ShortUrl { get; set; }
    [DefaultValue(0)]
    public int Clicked { get; set; }
    public DateTime CreatedAt { get; set; }
}