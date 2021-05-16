using Entities;
using Infrastructures.Repositories;
using Infrastructures.Repositories.Contracts;
using Services.Models;
using Services.Services.Contracts;
using Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepoitory _userRepository;
        private readonly IMapper<List<Board>, List<BoardModel>> _boardToBoardModelListMapper;
        public UserService(IUserRepoitory userRepository, IMapper<List<Board>, List<BoardModel>> boardToBoardModelListMapper)
        {
            _userRepository = userRepository;
            _boardToBoardModelListMapper = boardToBoardModelListMapper; ;
        }
        public async Task<List<BoardModel>> GetuserOwnedBoards(int id, string username)
        {
            // checked the user who send the request has authorization for this activity
            // use above username for that task

            var boardTasks = await _userRepository.GetuserOwnedBoards(id);

            return _boardToBoardModelListMapper.Map(boardTasks);
        }
    }
}
