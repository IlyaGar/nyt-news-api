using System.Collections.Generic;
using System.Threading.Tasks;
using IlyaSaukoNancyTask.Models;

namespace IlyaSaukoNancyTask.Services
{
    /// <summary>
    /// Represents a getting model list service.
    /// </summary>
    public interface INewsService
    {
        /// <summary>
        /// Method getting of a ArticleView list.
        /// </summary>
        /// <param name="section">Search parameter of the news section.</param>
        /// <returns>List of ArticleView objects is returned by this method when it completes.</returns>
        Task<IEnumerable<ArticleView>> GetListAsync(string section);

        /// <summary>
        /// Method getting of a first item ArticleView.
        /// </summary>
        /// <param name="section">Search parameter of the news section.</param>
        /// <returns>ArticleView object is returned by this method when it completes.</returns>
        Task<ArticleView> GetListFirstAsync(string section);

        /// <summary>
        /// Method getting of a ArticleView list at current date.
        /// </summary>
        /// <param name="section">Search parameter of the news section.</param>
        /// <param name="updatedDate">Search parameter of the news date.</param>
        /// <returns>List of ArticleView objects is returned by this method when it completes.</returns>
        Task<IEnumerable<ArticleView>> GetListDateAsync(string section, string updatedDate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        Task<ArticleView> GetSingleByShortUrlAsync(string section);

        /// <summary>
        /// Method getting of a ArticleGroupByDateView list.
        /// </summary>
        /// <param name="section">Search parameter of the news section.</param>
        /// <returns>List of ArticleGroupByDateView objects is returned by this method when it completes.</returns>
        Task<IEnumerable<ArticleGroupByDateView>> GetArticleGroupByDateViews(string section);
    }
}
