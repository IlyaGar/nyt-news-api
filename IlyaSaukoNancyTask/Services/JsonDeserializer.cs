using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using IlyaSaukoNancyTask.Models;
using static IlyaSaukoNancyTask.Models.JsonKey;

namespace IlyaSaukoNancyTask.Services
{
    ///<inheritdoc cref="IJsonDeserializer"/>
    public class JsonDeserializer : IJsonDeserializer
    {
        public IEnumerable<ArticleView> GetArticleViews(string json)
        {
            if (json != null)
            {
                List<ArticleView> listResults = new List<ArticleView>();

                dynamic dynamicResponse = JsonConvert.DeserializeObject<ExpandoObject>(json, new ExpandoObjectConverter());

                foreach (var objProp in dynamicResponse as IDictionary<string, object> ?? new Dictionary<string, object>())
                {
                    if (objProp.Key == Keys.results.ToString())
                    {
                        foreach (var item in (IEnumerable)objProp.Value)
                        {
                            ArticleView articleView = new ArticleView();
                            foreach (var itemProp in item as IDictionary<string, object> ?? new Dictionary<string, object>())
                            {
                                if (itemProp.Key == Keys.title.ToString())
                                    articleView.Heading = itemProp.Value.ToString();
                                if (itemProp.Key == Keys.updated_date.ToString())
                                    articleView.Updated = Convert.ToDateTime(itemProp.Value.ToString());
                                if (itemProp.Key == Keys.short_url.ToString())
                                    articleView.Link = itemProp.Value.ToString();
                            }
                            listResults.Add(articleView);
                        }
                    }
                }
                return listResults;
            }
            else return null;
        }
    }
}
