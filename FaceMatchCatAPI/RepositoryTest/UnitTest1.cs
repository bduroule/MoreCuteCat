using Microsoft.EntityFrameworkCore;
using Model;
using Moq;
using Repository;
using Repository.Data;
using Repository.Interface;
using System.Reflection.Metadata;

namespace RepositoryTest
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldGetAllCatsRepositoryWithMultipleValue()
        {
            // ARRANGE
            var listCats = new List<Cat>()
            {
                new Cat { Id = "MTgwODA3MA", Url = "http://24.media.tumblr.com/tumblr_m82woaL5AD1rro1o5o1_1280.jpg", Score = 0 },
                new Cat { Id = "tt", Url = "http://24.media.tumblr.com/tumblr_m29a9d62C81r2rj8po1_500.jpg", Score = 0 },
            };

            var mockSet = new Mock<DbSet<Cat>>();

            mockSet.As<IQueryable<Cat>>().Setup(m => m.Provider).Returns(listCats.AsQueryable().Provider);
            mockSet.As<IQueryable<Cat>>().Setup(m => m.Expression).Returns(listCats.AsQueryable().Expression);
            mockSet.As<IQueryable<Cat>>().Setup(m => m.ElementType).Returns(listCats.AsQueryable().ElementType);
            mockSet.As<IQueryable<Cat>>().Setup(m => m.GetEnumerator()).Returns(() => listCats.AsQueryable().GetEnumerator());

            var options = new DbContextOptionsBuilder<CatContext>().UseInMemoryDatabase(databaseName: "TestDB").Options;
            var mockContext = new CatContext(options);

            mockContext.Cats = mockSet.Object;
            var catRepository = new CatRepository(mockContext);

            // ACT
            var result = catRepository.GetAllCats();

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(listCats, result);
        }

        [Fact]
        public void ShouldGetAllCatsRepositoryWithNoValue()
        {
            // ARRANGE
            var listCats = new List<Cat>();

            var mockSet = new Mock<DbSet<Cat>>();

            mockSet.As<IQueryable<Cat>>().Setup(m => m.Provider).Returns(listCats.AsQueryable().Provider);
            mockSet.As<IQueryable<Cat>>().Setup(m => m.Expression).Returns(listCats.AsQueryable().Expression);
            mockSet.As<IQueryable<Cat>>().Setup(m => m.ElementType).Returns(listCats.AsQueryable().ElementType);
            mockSet.As<IQueryable<Cat>>().Setup(m => m.GetEnumerator()).Returns(() => listCats.AsQueryable().GetEnumerator());

            var options = new DbContextOptionsBuilder<CatContext>().UseInMemoryDatabase(databaseName: "TestDB").Options;
            var mockContext = new CatContext(options);

            mockContext.Cats = mockSet.Object;
            var catRepository = new CatRepository(mockContext);

            // ACT
            var result = catRepository.GetAllCats();

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal(0, result.Count());
            Assert.Equal(listCats, result);
        }

        [Fact]
        public void CreateBlog_saves_a_blog_via_context() // change
        {
            var catId = "tt";
            var newScore = 1500;
            var existingCat = new Cat { Id = catId, Url = "http://24.media.tumblr.com/tumblr_m29a9d62C81r2rj8po1_500.jpg", Score = 1000 };

            var options = new DbContextOptionsBuilder<CatContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            var mockContext = new CatContext(options);
            mockContext.Cats.Add(existingCat);
            mockContext.SaveChanges();

            var catRepository = new CatRepository(mockContext);

            // Act
            catRepository.UpdateCatScore(catId, newScore);

            // Assert
            var updatedCat = mockContext.Cats.Find(catId);
            Assert.NotNull(updatedCat);
            Assert.Equal(newScore, updatedCat.Score);
        }
    }
}