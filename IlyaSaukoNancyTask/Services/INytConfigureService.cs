using IlyaSaukoNancyTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlyaSaukoNancyTask.Services
{
    public interface INytConfigureService
    {
        NancyNytApiConfig GetConfig();
    }
}
