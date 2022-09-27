using PartyProductUsingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProductUsingAPI.Repository
{
    public interface IPartyRepository
    {
        Task<List<Party>> GetAllParty();
        Task<Party> PartyAddAsync(Party partyModel);
        Task<Party> EditPartyAsync(int id, Party party);
        Task<Party> GetPartyByIdAsync(int id);
        Task DeletePartyAsync(int id);
    }
}
