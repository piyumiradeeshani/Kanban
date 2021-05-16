using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructures.Repositories.Contracts
{
    public interface IUserRepoitory
    {
        public Task<List<Board>> GetuserOwnedBoards(int id);
    }
}
