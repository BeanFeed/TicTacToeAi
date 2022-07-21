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

        }
        private void Form1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(e);
        }

        private void slotClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            
        }
    }
}