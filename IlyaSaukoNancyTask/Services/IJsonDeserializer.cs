using System.Collections.Generic;
using IlyaSaukoNancyTask.Models;

namespace IlyaSaukoNancyTask.Services
{
    /// <summary>
    /// Represents a service for deserialize json to a list ArticleView object.
    /// </summary>
    public interface IJsonDeserializer
    {
        /// <summary>
        /// Method deserialize a json string to a list objects.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>List of ArticleView objects.</returns>
        IEnumerable<ArticleView> GetArticleViews(string json);
    }
}
