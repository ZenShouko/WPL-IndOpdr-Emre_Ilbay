using ClassLib.Business.Entities;
using ClassLib.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokeCardController : ControllerBase
    {
        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                string json = JsonConvert.SerializeObject(new CardData().GetCards(""));
                return Ok(json);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("ByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetByName(string name)
        {
            //Checking if the json object is null.
            if (name == null)
                return BadRequest("No name given.");

            //Processing the request.
            try
            {
                string jsonResult = JsonConvert.SerializeObject(new CardData().GetCards(name));
                return Ok(jsonResult);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] object json)
        {
            //Checking if the json object is null.
            if (json == null)
                return BadRequest("No card given.");

            Card newCard;
            //Deserializing the json object.
            try
            {
                newCard = JsonConvert.DeserializeObject<Card>(json.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            //Processing the request.
            try
            {
                new CardData().AddCard(newCard);
                return Ok("Card added.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
