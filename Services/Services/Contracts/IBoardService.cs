using Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services.Contracts
{
    public interface IBoardService
    {
        public void CreateBoard(Board board, string username);
        public BoardModel EditBoard(int id, string userName, Board board);
        public void DeleteBoard(int id, string userName);
        public Task<List<BoardTask>> GetBoardTask(string username);
        public Board InviteUsersToBoard(int id, string userName, User user);
    }
}
