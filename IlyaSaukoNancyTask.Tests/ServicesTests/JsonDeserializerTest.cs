using IlyaSaukoNancyTask.Models;
using IlyaSaukoNancyTask.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace IlyaSaukoNancyTask.Tests.ServicesTests
{
    class JsonDeserializerTest
    {
        private string json;
        private List<ArticleView> expected;

        [SetUp]
        public void Setup()
        {
            var path = Path.GetFullPath(@"..\..\..\") + @"Content\test_example.json";
            using (StreamReader r = new StreamReader(path))
            {
                json = r.ReadToEnd();
            }

            expected = new List<ArticleView>()
            {
                new ArticleView()
                {
                    Heading = "Young Migrants Crowd Shelters, Posing Test for Biden",
                    Link ="https://nyti.ms/2PK9qDX",
                    Updated = DateTime.Parse("2021-04-11T00:23:03-04:00") 
                },
                new ArticleView()
                {
                    Heading = "'I Have No Idea Where My Daughter Is': Migrant Parents Are Desperate for News",
                    Link = "https://nyti.ms/3myiZS3",
                    Updated = DateTime.Parse("2021-04-09T10:14:22-04:00")
                },
            };
        }

        [Test]
        public void GetListAsyncAssertTrue()
        {
            // Arrange
            JsonDeserializer des = new JsonDeserializer();

            // Act
            var actual = des.GetArticleViews(json);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetListAsyncReturnNull()
        {
            // Arrange
            JsonDeserializer des = new JsonDeserializer();

            // Act
            var actual = des.GetArticleViews(null);

            // Assert
            Assert.AreEqual(expected: null, actual: actual);
        }
    }
}
