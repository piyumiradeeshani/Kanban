using Entities;
using Infrastructures.Repositories.Contracts;
using Services.Mappers;
using Services.Models;
using Services.Services.Contracts;
using Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IMapper<Board, BoardModel> _boardToBoardModelMapper;
        private readonly IMapper<List<Board>, List<BoardTask>> _boardToBoardtaskMapper;
        public BoardService(IBoardRepository boardRepository, IMapper<Board, BoardModel>
            boardToBoardModelMapper, IMapper<List<Board>, 
            List<BoardTask>> BoardToBoardtaskMapper)
        {
            _boardRepository = boardRepository;
            _boardToBoardModelMapper = boardToBoardModelMapper;
            _boardToBoardtaskMapper = BoardToBoardtaskMapper;
        }
        public void CreateBoard(Board board, string userName)
        {
            //call the repository layer as below
          _boardRepository.CreateBoard(board, userName);
            
        }

        public BoardModel EditBoard(int id, string userName, Board board)
        {
            //Check whether the user is authorized for editing the relevent board
            //call the repository
            var boardResponse = _boardRepository.EditBoard(id, board);

            return _boardToBoardModelMapper.Map(boardResponse); 

        }

        public void DeleteBoard(int id, string userName)
        {
            //Check whether the user is authorized for deleting the relevent board
            //call the repository
            _boardRepository.DeleteBoard(id);
            
        }

        public async Task<List<BoardTask>> GetBoardTask(string username)
        {
            var boardTasks =await _boardRepository.GetBoardTask();
            return _boardToBoardtaskMapper.Map(boardTasks);
        }
        public Board InviteUsersToBoard(int id, string userName, User user)
        {
            //Check whether the user is authorized for relevent board
           
            //call the repository method as below
            var board = _boardRepository.InviteUsersToBoard(id, userName, user);
            return board;

             

        }

    }
}
