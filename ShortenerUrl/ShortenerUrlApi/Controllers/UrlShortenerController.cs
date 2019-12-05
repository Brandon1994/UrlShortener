using Microsoft.AspNetCore.Mvc;
using ShortenerUrlApi.Services;
using ShortenerUrlApi.Model;

namespace ShortenerUrlApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class urlshortener : ControllerBase
    {
        private readonly IUrlHandler _urlHandler;
        public urlshortener(IUrlHandler urlHandler)
        {
            _urlHandler = urlHandler;
        }

        [HttpGet("{token}")]
        public ActionResult<string> Get(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                var urlRetorno = _urlHandler.GetUrl(token);
                if (!string.IsNullOrEmpty(urlRetorno))
                    return Ok(urlRetorno);

                return NotFound();
            }
            return BadRequest();
        }


        [HttpPost]
        public ActionResult<string> Post([FromBody] UrlModel urlModel)
        {
            if (ModelState.IsValid)
            {
                var shortString = _urlHandler.Create(urlModel.Url);
                var urlToReturn = string.Concat(Request.Host.Value, Request.Path, "/", shortString);
                return Ok(urlToReturn);
            }
            else
                return BadRequest();
        }
    }
}