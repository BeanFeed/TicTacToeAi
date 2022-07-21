namespace TicTacToeAi
{
    public partial class Form1 : Form
    {
        private int[] grid = new int[] {0,0,0,0,0,0,0,0,0};   
        public Form1()
        {
            InitializeComponent();
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

        private void slotClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            
        }
    }
}