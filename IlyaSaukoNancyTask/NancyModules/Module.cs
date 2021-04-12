using IlyaSaukoNancyTask.Models;
using IlyaSaukoNancyTask.Services;
using Nancy;
using System;
using System.Collections.Generic;

namespace IlyaSaukoNancyTask.NancyModules
{
    /// <summary>
    /// Api controller.
    /// </summary>
    /// <param name="newsService">Service for work with nyt api.</param>
    public class Module : NancyModule
    {
        private readonly INewsService _newsService;

        public Module(INewsService newsService)
        {
            _newsService = newsService;

            Get("/", _ => Response.AsText("{\"nancy_api\":\"work\",\"author\":\"Ilya Sauko\"}"));

            Get("/list/{section}", async _ =>
            {
                try
                {
                    var section = _.section;

                    List<ArticleView> response = await _newsService.GetListAsync(section);

                    return Response.AsJson(response);
                }
                catch
                {
                    return Response.AsText("{\"message\":\"section not found\"}");
                }
            });

            Get("/list/{section}/first", async _ =>
            {
                try
                {
                    var section = _.section;

                    ArticleView response = await _newsService.GetListFirstAsync(section);

                    return Response.AsJson(response);
                }
                catch(Exception e)
                {
                    return Response.AsText("{\"message\":\"" + e.Message + "\"}");
                }
            });
            
            Get("/list/{section}/{updatedDate}", async _ =>
            {
                try
                {
                    var section = _.section;
                    var updatedDate = _.updatedDate;

                    List<ArticleView> response = await _newsService.GetListDateAsync(section, updatedDate);

                    return Response.AsJson(response);
                }
                catch(FormatException e)
                {
                    return Response.AsText("{\"message\":\"" + e.Message + "\"}");
                }
                catch (Exception e)
                {
                    return Response.AsText("{\"message\":\"" + e.Message + "\"}");
                }
            });

            Get("/article/{shortUrl}", async _ =>
            {
                try
                {
                    var shortUrl = _.shortUrl;

                    ArticleView response = await _newsService.GetSingleByShortUrlAsync(shortUrl);

                    if (response is null)
                        return Response.AsText("{\"message\":\"article not found\"}");
                    return Response.AsJson(response);
                }
                catch
                {
                    return Response.AsText("{\"message\":\"something went wrong\"}");
                }
            });

            Get("/group/{section}", async _ =>
            {
                try
                {
                    var section = _.section;

                    List<ArticleGroupByDateView> response = await _newsService.GetArticleGroupByDateViews(section);

                    return Response.AsJson(response);
                }
                catch
                {
                    return Response.AsText("{\"message\":\"something went wrong\"}");
                }
            });
        }
    }
}
