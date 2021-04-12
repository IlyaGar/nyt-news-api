using System.Threading.Tasks;

namespace IlyaSaukoNancyTask.Services
{
    /// <summary>
    /// Represents a service for getting a json news string from api.
    /// </summary>
    public interface IHttpRequestService
    {
        /// <summary>
        /// Method getting a json string.
        /// </summary>
        /// <param name="section">Search parameter of the news section.</param>
        /// <returns>Json string is returned by this method when it completes.</returns>
        Task<string> GetListAsync(string section);
    }
}
