using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Model;
using Services.Interface;
using System.Text;
using System;

namespace FaceMatchCatAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly ICatService _catService;

        public CatsController(ICatService catService)
        {
            _catService = catService;
        }

        #region Public methods

        /// <summary>
        /// Get all cats
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Cat> GetAllCats()
        {
            var cats = _catService.GetAllCats();
            return cats;
        }

        /// <summary>
        /// get n random cats are not in the list of exclude ids
        /// </summary>
        /// <param name="count"></param>
        /// <param name="excludeIds"></param>
        /// <returns></returns>
        [HttpGet("getRandomCats")]
        public IActionResult GetRandomCats(int count, [FromQuery] List<string> excludeIds)
        {
            var randomCats = _catService.GetRandomCats(count, excludeIds);
            return Ok(randomCats);
        }

        /// <summary>
        /// update note of cat voted
        /// </summary>
        /// <param name="catVote"></param>
        /// <returns></returns>
        [HttpPost("vote")]
        public IActionResult VoteForCat([FromBody] VoteModel catVote)
        {
            try
            {
                _catService.PutVoteForChat(catVote);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
        #endregion
    }
}
