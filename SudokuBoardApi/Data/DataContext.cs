using Microsoft.EntityFrameworkCore;
using SudokuBoardApi.Model;

namespace SudokuBoardApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Board> Boards { get; set; }
    }
}
