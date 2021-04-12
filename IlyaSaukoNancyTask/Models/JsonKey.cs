using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlyaSaukoNancyTask.Models
{
    public class JsonKey
    {
        /// <summary>
        /// Enumerator for keys in json object.
        /// </summary>
        public enum Keys
        {
            results,
            title,
            updated_date,
            short_url
        }
    }
}
