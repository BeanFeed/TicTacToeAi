namespace TicTacToeAi
{
    public partial class Form1 : Form
    {
        List<Button> buttons;
        private void Form1_Load(object sender, EventArgs e)
        {
            buttons = this.Controls.OfType<Button>().ToList();
            List<Button> inputs = new List<Button>();
            foreach (Button button in buttons)
            {
                if (button.Name.Contains("slot"))
                {
                    inputs.Add(button);
                }
            }
            buttons = inputs;
        }
        private Button GetButtonByName(string name)
        {
            foreach(Button button in buttons)
            {
                if(button.Name == name) return button;
            }
            return null;
        }
        private int CalcOdds(int[] board)
        {
            
            int spaces = GetRemainingSpaces();
            int losses = 0;
            if (spaces == 0 && GetWinner() == "X")
            {
                return 1;
            }
            for (int i = 0; i < 9; i++)
            {
                int[] newBoard = new int[9];
                Array.Copy(board, newBoard, 9);
                if (newBoard[i] == 0)
                {
                    if (IsEven(spaces))
                    {
                        newBoard[i] = 7;
                    }
                    else
                    {
                        newBoard[i] = 2;
                    }
                    losses += CalcOdds(newBoard);
                }
            }
            return losses;
        }
        private void BotMove(int[] board)
        {
            List<int[]> results = new List<int[]>();
            int[] newGrid = new int[9];
            Array.Copy(board,newGrid, 9);
            for (int i = 0; i < 9; i++)
            {
                if (grid[i] == 0)
                {
                    newGrid[i] = 2;
                    int losses = CalcOdds(newGrid);
                    results.Add(new int[] { i, losses });
                }
            }
            int lowestSlotNum = 999999999;
            int lowestSlot = 0;
            foreach (int[] result in results)
            {
                if (result[1] < lowestSlotNum)
                {
                    lowestSlot = result[0];
                }
            }
            Button buttonToPlay = GetButtonByName("slot" + lowestSlot);
            PlayPiece(lowestSlot, buttonToPlay);

        }
        private int GetRemainingSpaces()
        {
            int spaces = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                if (grid[i] == 0)
                {
                    spaces++;
                }
            }
            return spaces;
        }
        private bool IsEven(int num)
        {
            if (num%2 == 0)
            {
                return true;
            }
            return false;
        }
        int[] grid = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        bool isXTurn = true;
        bool gameOver = false;
        public Form1()
        {
            InitializeComponent();
        }
        private string GetWinner()
        {
            if ((grid[0] + grid[1] + grid[2]) == 6) { return "O"; }
            if ((grid[3] + grid[4] + grid[5]) == 6) { return "O"; }
            if ((grid[6] + grid[7] + grid[8]) == 6) { return "O"; }
            if ((grid[0] + grid[3] + grid[6]) == 6) { return "O"; }
            if ((grid[1] + grid[4] + grid[7]) == 6) { return "O"; }
            if ((grid[2] + grid[5] + grid[8]) == 6) { return "O"; }
            if ((grid[0] + grid[4] + grid[8]) == 6) { return "O"; }
            if ((grid[2] + grid[4] + grid[6]) == 6) { return "O"; }
            if ((grid[0] + grid[1] + grid[2]) == 21) { return "X"; }
            if ((grid[3] + grid[4] + grid[5]) == 21) { return "X"; }
            if ((grid[6] + grid[7] + grid[8]) == 21) { return "X"; }
            if ((grid[0] + grid[3] + grid[6]) == 21) { return "X"; }
            if ((grid[1] + grid[4] + grid[7]) == 21) { return "X"; }
            if ((grid[2] + grid[5] + grid[8]) == 21) { return "X"; }
            if ((grid[0] + grid[4] + grid[8]) == 21) { return "X"; }
            if ((grid[2] + grid[4] + grid[6]) == 21) { return "X"; }
            return "N";
        }
        private void PlayPiece(int slot, Button b)
        {
            if (isXTurn)
            {
                grid[slot] = 7;
                b.Text = "X";
            }
            else
            {
                grid[slot] = 2;
                b.Text = "O";
            }
            isXTurn = !isXTurn;
            string winner = GetWinner();
            if (winner != "N")
            {
                this.Winner.Text = winner;
                gameOver = true;
                this.GameState.Text = "Over";
            }
        }
        private void slotClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int slotClicked = int.Parse(button.Name[4].ToString());
            this.SlotVal.Text = grid[slotClicked].ToString();
            if (!gameOver)
            {

                if (grid[slotClicked] == 0)
                {
                    PlayPiece(slotClicked, button);
                    if (GetWinner() == "N")
                    {
                        BotMove(grid);
                    }
                }
            }
        }
    }
}