using Entities;
using Services.Models;
using Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public class BoardToBoardModelListMapper : IMapper<List<Board>, List<BoardModel>>
    {
        public List<BoardModel> Map(List<Board> board)
        {
            List<BoardModel> listModel = new List<BoardModel>();
            foreach (var b in board)
            {
                var boardModel = new BoardModel() 
                {
                    id = b.BoardId,
                    BoardName = b.BoardName
                };
                listModel.Add(boardModel);
            }
            return listModel;


        }
    }
}
