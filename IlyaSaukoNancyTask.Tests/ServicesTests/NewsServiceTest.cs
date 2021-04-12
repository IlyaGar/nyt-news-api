using IlyaSaukoNancyTask.Models;
using IlyaSaukoNancyTask.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace IlyaSaukoNancyTask.Tests.ServicesTests
{
    class NewsServiceTest
    {
        private string json;
        private string section;
        private string shortUrl;
        private string updatedDate;
        private Mock<IHttpRequestService> mockHttprequest;
        private Mock<IJsonDeserializer> mockJsonDeserializer;
        private List<ArticleView> expected;
        private List<ArticleGroupByDateView> expectedByDate;

        [SetUp]
        public void Setup()
        {
            section = "home";
            shortUrl = "3myiZS3";
            updatedDate = "2021-04-11";
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

            expectedByDate = new List<ArticleGroupByDateView>()
            {
                new ArticleGroupByDateView() { Date = "2021-04-11", Total = 1 },
                new ArticleGroupByDateView() { Date = "2021-04-09", Total = 1 }
            };

            mockHttprequest = new Mock<IHttpRequestService>();
            mockHttprequest.Setup(a => a.GetListAsync(section)).Returns(Task.FromResult(json));

            mockJsonDeserializer = new Mock<IJsonDeserializer>();
            mockJsonDeserializer.Setup(a => a.GetArticleViews(json)).Returns(expected);
        }

        [Test]
        public void GetListAsyncAssertTrue()
        {
            // Arrange
            var newsService = new NewsService(mockHttprequest.Object, mockJsonDeserializer.Object);

            // Act
            var actual = newsService.GetListAsync(section).Result;

            // Assert
            CollectionAssert.AreEqual(expected: expected, actual: actual);
        }

        [Test]
        public void GetListFirstAsyncAssertTrue()
        {
            // Arrange
            var newsService = new NewsService(mockHttprequest.Object, mockJsonDeserializer.Object);

            // Act
            var actual = newsService.GetListFirstAsync(section).Result;

            // Assert
            Assert.AreEqual(expected: expected[0], actual: actual);
        }

        [Test]
        public void GetSingleByShortUrlAsyncAssertTrue()
        {
            // Arrange
            var newsService = new NewsService(mockHttprequest.Object, mockJsonDeserializer.Object);

            // Act
            var actual = newsService.GetSingleByShortUrlAsync(shortUrl).Result;

            // Assert
            Assert.AreEqual(expected: expected[1], actual: actual);
        }

        [Test]
        public void GetListDateAsyncAssertTrue()
        {
            // Arrange
            var newsService = new NewsService(mockHttprequest.Object, mockJsonDeserializer.Object);

            // Act
            var actual = newsService.GetListDateAsync(section, updatedDate).Result;

            // Assert
            CollectionAssert.AreEqual(expected: new List<ArticleView>() { expected[0] }, actual: actual);
        }

        [Test]
        public void GetArticleGroupByDateViewsAssertTrue()
        {
            // Arrange
            var newsService = new NewsService(mockHttprequest.Object, mockJsonDeserializer.Object);

            // Act
            var actual = newsService.GetArticleGroupByDateViews(section).Result;

            // Assert
            CollectionAssert.AreEqual(expected: expectedByDate, actual: actual);
        }
    }
}
