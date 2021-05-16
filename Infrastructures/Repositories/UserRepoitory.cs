using Entities;
using Infrastructures.Core;
using Infrastructures.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Infrastructures.Shared.Enums;

namespace Infrastructures.Repositories
{
    public class UserRepoitory : IUserRepoitory
    {
        KanbanContext _kanbanContext;
        public UserRepoitory(KanbanContext kanbanContext)
        {
            _kanbanContext = kanbanContext;
        }
        public async Task<List<Board>> GetuserOwnedBoards(int id)
        {
            //retriving the relevant board
            var retrievedBoard = await _kanbanContext.Boards.Include(x => x.BoardUsers).Where(v => v.BoardUsers.Select(bu => bu.UserId).Contains(id)
            && v.BoardUsers.Select(bu => bu.Role).Contains(BoardUserRole.Owner.ToString())).ToListAsync();
            
            return retrievedBoard;
        }
    }
}
