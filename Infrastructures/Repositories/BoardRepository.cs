using Entities;
using Infrastructures.Core;
using Infrastructures.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Infrastructures.Shared.Enums;
using Task = Entities.Task;

namespace Infrastructures.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        KanbanContext _kanbanContext;
        public BoardRepository(KanbanContext kanbanContext)
        {
            _kanbanContext = kanbanContext;
        }
        //Insert the board data into the database
        public void CreateBoard(Board board,string userName)
        {
            //save changes to the board and boarduser
            var retrievedUser = _kanbanContext.Users.Where(u => u.Username == userName).First();
            board.BoardUsers = new List<BoardUser> { new BoardUser { Board = board, User = retrievedUser, Role = BoardUserRole.Owner.ToString() } };
            _kanbanContext.Boards.Add(board);
            _kanbanContext.SaveChanges();

        }

        //Edit the board details
        public Board EditBoard(int id,Board board)
        {
            //save the edited board
            var retrievedBoard = _kanbanContext.Boards.Where(b => b.BoardId == id).First();
            retrievedBoard.BoardName = board.BoardName == ""?retrievedBoard.BoardName: board.BoardName;
            _kanbanContext.Boards.Update(retrievedBoard);
            _kanbanContext.SaveChanges();
            return retrievedBoard;

        }

        public void DeleteBoard(int id)
        {
           //delete the board and boarduser and and included tasks and their comments of the board
            var retrievedBoard = _kanbanContext.Boards.Include(e => e.BoardUsers).Include(d => d.Tasks).ThenInclude(c => c.Comments).Where(b => b.BoardId == id).First();
            _kanbanContext.Boards.Remove(retrievedBoard);
            _kanbanContext.SaveChanges();

        }
        public async Task<List<Board>> GetBoardTask()
        {
            //retrive the board and their tasks
            var retrievedBoard = await _kanbanContext.Boards.Include(d => d.Tasks).ThenInclude(s => s.Status).Include(d => d.Tasks).ThenInclude(s => s.Tag).Include(d => d.Tasks)
                .ThenInclude(s => s.Status).Include(d => d.Tasks).ThenInclude(s => s.Comments).Include(d => d.Tasks)
                .ThenInclude(s => s.TaskUsers).ThenInclude(u => u.User).ToListAsync();
            return retrievedBoard;
        }
        public Board InviteUsersToBoard(int id, string userName, User user)
        {
            // set role of the board user as "PendingInvitee" as below
            Board board = null;
            var retrievedUserId = _kanbanContext.Users.Where(u => u.Username == userName).First().UserId;
            var owner = _kanbanContext.BoardUsers.Where(b => b.BoardId == id && b.UserId == retrievedUserId && b.Role == BoardUserRole.Owner.ToString()).First();
            if (owner != null)
            {
                var inUser = _kanbanContext.Users.Where(u => u.Username == user.Username).FirstOrDefault();
                if ((inUser != null)) {
                    var boardUser = new BoardUser()
                    {
                        BoardId = id,
                        UserId = inUser.UserId,
                        Role = BoardUserRole.PendingInvitee.ToString()
                    };
                    _kanbanContext.BoardUsers.Add(boardUser);
                    _kanbanContext.SaveChanges();
                     board = _kanbanContext.Boards.Include(u =>u.BoardUsers).Where(u => u.BoardId == id).First();
                   
                }
            }
            return board;
        }
    }   
}
