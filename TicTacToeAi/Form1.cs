namespace TicTacToeAi
{
    public partial class Form1 : Form
    {
        List<Button> buttons;
        private int[] grid = new int[] {0,0,0,0,0,0,0,0,0};   
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            buttons = this.Controls.OfType<Button>().ToList();
            List<Button> inputs = new List<Button>();
            foreach(Button button in buttons)
            {
                if (button.Name.Contains("slot"))
                {
                    inputs.Add(button);
                }
            }
            buttons = inputs;
        }
        private bool CheckBotWin()
        {
            if ((grid[0] + grid[1] + grid[2]) == 6) { return true; }
            if ((grid[3] + grid[4] + grid[5]) == 6) { return true; }
            if ((grid[6] + grid[7] + grid[8]) == 6) { return true; }
            if ((grid[0] + grid[3] + grid[6]) == 6) { return true; }
            if ((grid[1] + grid[4] + grid[7]) == 6) { return true; }
            if ((grid[2] + grid[5] + grid[8]) == 6) { return true; }
            if ((grid[0] + grid[4] + grid[8]) == 6) { return true; }
            if ((grid[2] + grid[4] + grid[6]) == 6) { return true; }
            return false;
        }
        private bool CheckPlayerWin()
        {
            if ((grid[0] + grid[1] + grid[2]) == 21) { return true; }
            if ((grid[3] + grid[4] + grid[5]) == 21) { return true; }
            if ((grid[6] + grid[7] + grid[8]) == 21) { return true; }
            if ((grid[0] + grid[3] + grid[6]) == 21) { return true; }
            if ((grid[1] + grid[4] + grid[7]) == 21) { return true; }
            if ((grid[2] + grid[5] + grid[8]) == 21) { return true; }
            if ((grid[0] + grid[4] + grid[8]) == 21) { return true; }
            if ((grid[2] + grid[4] + grid[6]) == 21) { return true; }
            return false;
        }
        private bool IsEven(int num)
        {
            if (num%2 == 0)
            {
                return true;
            }
            return false;
        }
        private int CalcOdds(int[] board)
        {
            int spaces = GetRemainingSpaces();
            int losses = 0;
            if (spaces == 0 && CheckPlayerWin())
            {
                return 1;
            }
            for (int i = 0; i < 8; i++)
            {
                int[] newBoard = board;
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
        private int NextBotMove()
        {
            List<int[]> results = new List<int[]>();
            for(int i = 0; i < 8; i++)
            {
                if (grid[i] == 0)
                {
                    int[] newGrid = grid;
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
            return lowestSlot;

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
        private void slotClick(object sender, EventArgs e)
        {
            bool playerWon = CheckPlayerWin();
            bool botWon = CheckBotWin();
            if (botWon)
            {
                this.test.Text = "O";
            }
            else if (playerWon)
            {
                this.test.Text = "X";
            }
            Button b = (Button)sender;
            int slotClicked = Int32.Parse(b.Name[4].ToString());
            this.test.Text = grid[slotClicked].ToString();
            
            if (grid[slotClicked] == 0)
            {
                grid[slotClicked] = 7;
                b.Text = "X";
                int botPick = NextBotMove();
                grid[botPick] = 2;
                buttons[botPick].Text = "O";
            }            
            
        }

        
    }
}