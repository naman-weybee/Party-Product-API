using Microsoft.EntityFrameworkCore;
using PartyProductUsingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProductUsingAPI.Repository
{
    public class PartyRepository : IPartyRepository
    {
        private readonly PartyProductMVCContext _context;

        public PartyRepository(PartyProductMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Party>> GetAllParty()
        {
            return await _context.Parties
                  .Select(party => new Party()
                  {
                      Id = party.Id,
                      PartyName = party.PartyName
                  }).ToListAsync();
        }

        public async Task<int> PartyAddAsync(Party partyModel)
        {
            var newParty = new Party()
            {
                PartyName = partyModel.PartyName
            };

            await _context.Parties.AddAsync(newParty);
            await _context.SaveChangesAsync();

            return newParty.Id;
        }

        public async Task EditPartyAsync(int id, Party party)
        {
            var updateParty = new Party()
            {
                Id = id,
                PartyName = party.PartyName
            };

            _context.Parties.Update(updateParty);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePartyAsync(int id)
        {
            var party = new Party() { Id = id };

            _context.Parties.Remove(party);
            await _context.SaveChangesAsync();
        }
    }
}
