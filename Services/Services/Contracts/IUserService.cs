using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services.Contracts
{
    public interface IUserService
    {
        public Task<List<BoardModel>> GetuserOwnedBoards(int id, string username);
    }
}
