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
        Task<int> PartyAddAsync(Party partyModel);
        Task EditPartyAsync(int id, Party party);
        Task DeletePartyAsync(int id);
    }
}
