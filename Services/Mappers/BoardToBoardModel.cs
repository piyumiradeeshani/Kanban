using Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Shared;

namespace Services.Mappers
{
    public class BoardToBoardModel : IMapper<Board, BoardModel>
    {
        public BoardModel Map(Board board)
        {
            return new BoardModel()
            {
                id = board.BoardId,
                BoardName = board.BoardName,
            };
        }
    }
}
