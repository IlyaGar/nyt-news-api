using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlyaSaukoNancyTask.Models
{
    /// <summary>
    /// ArticleGroupByDateView contains information about group news.
    /// </summary>
    public class ArticleGroupByDateView
    {
        public string Date { get; set; }

        public int Total { get; set; }


        public override bool Equals(object obj) => Date == (obj as ArticleGroupByDateView).Date;

        public override int GetHashCode() => (Total).GetHashCode();
    }
}