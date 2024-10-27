using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SudokuBoardApi.Data;
using SudokuBoardApi.Model;

namespace SudokuBoardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public BoardController(DataContext context)
        {
            _dataContext = context;
        }
        /// <summary>
        /// This api is used to get all info in table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Board>>> GetAllBoardInfor()
        {
            var boardInfo = await _dataContext.Boards.ToListAsync();
            if (boardInfo.Count > 0)
            {
                return Ok(boardInfo);
            }
            else
            {
                return BadRequest(boardInfo);
            }
        }

        /// <summary>
        /// This api is used to add new record to table
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<Board>>> AddBoardInfor(Board board)
        {
            _dataContext.Boards.Add(board);
            var result = await _dataContext.SaveChangesAsync();
            if (result > 0)
            {
                return Ok("Inserted successfully");
            }
            else
            {
                return BadRequest("Error while insert to db");
            }
        }

        /// <summary>
        /// This api is use to delete all records in table
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult DeleteBoardInfor()
        {
            _dataContext.Database.ExecuteSqlRaw("TRUNCATE TABLE [Boards]");
            return Ok("Deleted successfully");
        }
    }
}
