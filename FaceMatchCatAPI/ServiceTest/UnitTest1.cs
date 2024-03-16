using Model;
using Moq;
using Repository.Interface;
using Services;
using Services.Interface;

namespace ServiceTest
{
    public class UnitTest1
    {
        #region getAllCats Test
        [Fact]
        public void ShouldGetAllCatsWithMultipleValue()
        {
            // ARRANGE
            var repositoryMoq = new Mock<ICatRepository>();
            var listCats = new List<Cat>()
            {
                new Cat { Id = "MTgwODA3MA", Url = "http://24.media.tumblr.com/tumblr_m82woaL5AD1rro1o5o1_1280.jpg", Score = 0 },
                new Cat { Id = "tt", Url = "http://24.media.tumblr.com/tumblr_m29a9d62C81r2rj8po1_500.jpg", Score = 0 },
            };

            repositoryMoq.Setup(item => item.GetAllCats()).Returns(listCats);

            var catsService = new CatService(repositoryMoq.Object);

            // ACT
            var result = catsService.GetAllCats();

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(listCats, result);
        }

        [Fact]
        public void ShouldGetAllCatsWithNoValue()
        {
            // ARRANGE
            var repositoryMoq = new Mock<ICatRepository>();
            var listCats = new List<Cat>();

            repositoryMoq.Setup(item => item.GetAllCats()).Returns(listCats);

            var catsService = new CatService(repositoryMoq.Object);

            // ACT
            var result = catsService.GetAllCats();

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal(0, result.Count());
            Assert.Equal(listCats, result);

        }
        #endregion

        #region getRandomCats test
        [Fact]
        public void ShouldGetTwoRandomCatsWithExcludeId()
        {
            // ARRANGE
            var numbersOfCats = 2;
            var excludeIdsCat = new List<string>() { "tdvx" };
            var repositoryMoq = new Mock<ICatRepository>();
            var AllCatsList = new List<Cat>()
            {
                new Cat { Id = "MTgwODA3MA", Url = "http://24.media.tumblr.com/tumblr_m82woaL5AD1rro1o5o1_1280.jpg", Score = 0 },
                new Cat { Id = "tt", Url = "http://24.media.tumblr.com/tumblr_m29a9d62C81r2rj8po1_500.jpg", Score = 0 },
                new Cat { Id = "tdvx", Url = "http://24.media.tumblr.com/tumblr_m29a9d62C81shuvhfuvhir2rj8po1_500.jpg", Score = 0 }
            };

            var expectedCatList = new List<Cat>()
            {
                new Cat { Id = "tt", Url = "http://24.media.tumblr.com/tumblr_m29a9d62C81r2rj8po1_500.jpg", Score = 0 },
                new Cat { Id = "MTgwODA3MA", Url = "http://24.media.tumblr.com/tumblr_m82woaL5AD1rro1o5o1_1280.jpg", Score = 0 },
            };

            repositoryMoq.Setup(item => item.GetAllCats()).Returns(AllCatsList);

            var catsService = new CatService(repositoryMoq.Object);

            // ACT
            var result = catsService.GetRandomCats(numbersOfCats, excludeIdsCat);

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Collection(result,
                item =>
                {
                    Assert.Equal(expectedCatList[0].Id, item.Id);
                    Assert.Equal(expectedCatList[0].Url, item.Url);
                    Assert.Equal(expectedCatList[0].Score, item.Score);
                },
                item =>
                {
                    Assert.Equal(expectedCatList[1].Id, item.Id);
                    Assert.Equal(expectedCatList[1].Url, item.Url);
                    Assert.Equal(expectedCatList[1].Score, item.Score);
                }
            );
        }

        [Fact]
        public void ShouldGetTwoRandomCatsWithExcludeIdInListOfTwoCats()
        {
            // ARRANGE
            var numbersOfCats = 2;
            var excludeIdsCat = new List<string>() { "tdvx" };
            var repositoryMoq = new Mock<ICatRepository>();
            var AllCatsList = new List<Cat>()
            {
                new Cat { Id = "MTgwODA3MA", Url = "http://24.media.tumblr.com/tumblr_m82woaL5AD1rro1o5o1_1280.jpg", Score = 0 },
                new Cat { Id = "tdvx", Url = "http://24.media.tumblr.com/tumblr_m29a9d62C81shuvhfuvhir2rj8po1_500.jpg", Score = 0 }
            };

            var expectedCatList = new List<Cat>()
            {
                new Cat { Id = "MTgwODA3MA", Url = "http://24.media.tumblr.com/tumblr_m82woaL5AD1rro1o5o1_1280.jpg", Score = 0 },
            };

            repositoryMoq.Setup(item => item.GetAllCats()).Returns(AllCatsList);

            var catsService = new CatService(repositoryMoq.Object);

            // ACT
            var result = catsService.GetRandomCats(numbersOfCats, excludeIdsCat);

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal(1, result.Count());
            Assert.Collection(result,
                item =>
                {
                    Assert.Equal(expectedCatList[0].Id, item.Id);
                    Assert.Equal(expectedCatList[0].Url, item.Url);
                    Assert.Equal(expectedCatList[0].Score, item.Score);
                }
            );
        }

        /*var voteCat = new VoteModel
        {
            WinnerCatId = "tt",
            ParticipatingCats = new List<Cat>()
                {
                    new Cat { Id = "MTgwODA3MA", Url = "http://24.media.tumblr.com/tumblr_m82woaL5AD1rro1o5o1_1280.jpg", Score = 0 },
                    new Cat { Id = "tt", Url = "http://24.media.tumblr.com/tumblr_m29a9d62C81r2rj8po1_500.jpg", Score = 0 },
                }
        };*/

        [Fact]
        public void PutVoteForChat_WithValidModel_ShouldUpdateScores()
        {
            // Arrange
            var model = new VoteModel
            {
                WinnerCatId = "cat1",
                ParticipatingCats = new List<Cat>
                {
                    new Cat { Id = "cat1", Score = 1000 },
                    new Cat { Id = "cat2", Score = 1200 }
                }
            };

            var catRepositoryMock = new Mock<ICatRepository>();
            catRepositoryMock.Setup(repo => repo.UpdateCatScore(It.IsAny<string>(), It.IsAny<int>())).Verifiable();

            var catsService = new CatService(catRepositoryMock.Object);

            // Act
            catsService.PutVoteForChat(model);

            // Assert
            catRepositoryMock.Verify(repo => repo.UpdateCatScore("cat1", It.IsAny<int>()), Times.Exactly(2));
            catRepositoryMock.Verify(repo => repo.UpdateCatScore("cat2", It.IsAny<int>()), Times.Exactly(1));
        }
        #endregion
    }
}