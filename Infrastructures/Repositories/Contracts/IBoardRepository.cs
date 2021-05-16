using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = Entities.Task;

namespace Infrastructures.Repositories.Contracts
{
   public interface IBoardRepository
    {
        public void CreateBoard(Board board,string userName);
        public Board EditBoard(int id, Board board);
        public void DeleteBoard(int id);
        public Task<List<Board>> GetBoardTask();
        public Board InviteUsersToBoard(int id, string userName, User user);
    }
}
