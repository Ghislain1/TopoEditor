using System;

namespace TopoEditor.Infrastructure.Models
{
    public class NewsArticle
    {
        public string Body { get; set; }
        public string IconUri { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Title { get; set; }
    }
}