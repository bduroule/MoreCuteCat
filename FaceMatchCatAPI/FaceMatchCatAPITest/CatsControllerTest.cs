using Services.Interface;
using Moq;
using Model;

namespace FaceMatchCatAPITest
{
    public class CatsControllerTest
    {
        [Fact]
        public void Test1()
        {
            // ARRANGE
            var serviceMoq = new Mock<ICatService>();
            //var catsController = new CatsController(serviceMoq);
            var listCats = new List<Cat>()
            {
                new Cat { Id = "MTgwODA3MA", Url = "http://24.media.tumblr.com/tumblr_m82woaL5AD1rro1o5o1_1280.jpg", Score = 0 },
                new Cat { Id = "tt", Url = "http://24.media.tumblr.com/tumblr_m29a9d62C81r2rj8po1_500.jpg", Score = 0 },
            };

            serviceMoq.Setup(item => item.GetAllCats()).Returns(listCats);

            // ACT

            // ASSERT
        }
    }
}