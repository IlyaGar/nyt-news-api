using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlyaSaukoNancyTask.Models
{
    /// <summary>
    /// ArticleView contains information about news.
    /// </summary>
    public class ArticleView
    {
        public string Heading { get; set; }

        public DateTime Updated { get; set; }

        public string Link { get; set; }


        public override bool Equals(object obj) => Heading == (obj as ArticleView).Heading;

        public override int GetHashCode() => (Updated).GetHashCode();
    }
}