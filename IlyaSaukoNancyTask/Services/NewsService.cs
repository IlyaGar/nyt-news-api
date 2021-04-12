using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using IlyaSaukoNancyTask.Models;

namespace IlyaSaukoNancyTask.Services
{
    ///<inheritdoc cref="INewsService"/>
    public class NewsService : INewsService
    {
        private readonly IHttpRequestService _httpRequestService;
        private readonly IJsonDeserializer _deserializer;

        public NewsService(IHttpRequestService httpRequestService, IJsonDeserializer deserializer)
        {
            _httpRequestService = httpRequestService;
            _deserializer = deserializer;
        }

        public async Task<IEnumerable<ArticleGroupByDateView>> GetArticleGroupByDateViews(string section)
        {
            var articles = await GetDespiralizedListAsync(section);

            var dictionary = articles.GroupBy(d=> d.Updated.Date).ToDictionary(d => d.Key, t => t.Count());

            var articleGroups = dictionary.Select(a => new ArticleGroupByDateView { Date = a.Key.ToString("yyyy-MM-dd"), Total = a.Value }).ToList();

            return articleGroups;
        }

        public async Task<IEnumerable<ArticleView>> GetListAsync(string section)
        {
            return await GetDespiralizedListAsync(section);
        }

        public async Task<IEnumerable<ArticleView>> GetListDateAsync(string section, string updatedDate)
        {
            DateTime date = DateTime.ParseExact(updatedDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var articles = await GetDespiralizedListAsync(section);

            var response = articles.Where(o => o.Updated.Date == date.Date).ToList();
            return response;
        }

        public async Task<ArticleView> GetListFirstAsync(string section)
        {
            var articles = await GetDespiralizedListAsync(section);

            return articles.FirstOrDefault();
        }

        public async Task<ArticleView> GetSingleByShortUrlAsync(string shortUrl)
        {
            var jsonNews = await _httpRequestService.GetListAsync("home");
            var articleViews = _deserializer.GetArticleViews(jsonNews);
            var articleView = articleViews.FirstOrDefault(art => art.Link.Contains(shortUrl));

            return articleView;
        }

        /// <summary>
        /// Get json string from nyt api and despiralized json to list objects.
        /// </summary>
        /// <param name="section">Search parameter of the news section.</param>
        /// <returns>List of despiralized ArticleView objects.</returns>
        private async Task<IEnumerable<ArticleView>> GetDespiralizedListAsync(string section)
        {
            var jsonNews = await _httpRequestService.GetListAsync(section);

            var articleViews = _deserializer.GetArticleViews(jsonNews);

            return articleViews;
        }
    }
}
