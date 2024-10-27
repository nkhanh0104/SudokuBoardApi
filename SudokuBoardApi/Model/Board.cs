namespace SudokuBoardApi.Model
{
    public class Board
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int Value { get; set; }
        public bool IsValid { get; set; } = false;
        public DateTime DateTime { get; set; }
    }
}
