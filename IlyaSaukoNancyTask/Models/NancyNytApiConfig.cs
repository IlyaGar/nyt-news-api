using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlyaSaukoNancyTask.Models
{
    /// <summary>
    /// Connection parameters to NYT API.
    /// </summary>
    public class NancyNytApiConfig
    {
        public string Url { get; set; }

        public string Section { get; set; }

        public string Key { get; set; }
    }
}
