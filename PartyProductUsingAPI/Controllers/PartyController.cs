using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyProductUsingAPI.Models;
using PartyProductUsingAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProductUsingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly IPartyRepository _partyRepository = null;

        public PartyController(IPartyRepository partyRepository)
        {
            _partyRepository = partyRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Party()
        {
            var data = await _partyRepository.GetAllParty();
            return Ok(data);
        }

        [HttpPost("")]
        public async Task<IActionResult> PartyAdd([FromBody] Party party)
        {
            var data = await _partyRepository.PartyAddAsync(party);
            return CreatedAtAction(nameof(PartyAdd), new { controller = "Party" }, data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditParty([FromRoute] int id, [FromBody] Party party)
        {
            var data = await _partyRepository.EditPartyAsync(id, party);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartyById([FromRoute] int id)
        {
            var party = await _partyRepository.GetPartyByIdAsync(id);
            if (party == null)
            {
                return NotFound();
            }
            return Ok(party);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParty([FromRoute] int id)
        {
            await _partyRepository.DeletePartyAsync(id);
            return Ok();
        }
    }
}
