namespace C__TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //C# PROJECT
        //TicTacToe


        string[,] TTT;
        bool WinCheck;
        string xOrO = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            gameStart();
        }

        //FUNCTION TO PRINT THE BOARD
        void PrintStaticArray()
        {
            int emptyPosition = 0; //keep this here, if outside the function, the variable will just accumulate value so we will never get 0 value to evaluate if the game is lost
            //richTextBox1.Clear();
            richTextBox1.Text = "This is TicTacToe\n";

            for (int i = 0; i <= TTT.GetUpperBound(0); i++) //this is where I actually print out the board
            {
                for (int j = 0; j <= TTT.GetUpperBound(1); j++)
                {
                    richTextBox1.Text += TTT[i, j];
                    if (TTT[i, j] == " * ") //add count *, if *==0 then full, if more then not full! 
                    {
                        emptyPosition++;
                    }
                }
                richTextBox1.Text += "\n";
            }
            WinCheckFunction(emptyPosition); //Check for win or draw. emptyPosition here is the arguement
        }

        //RESET THE GAME TO START AGAIN
        void gameStart()
        {
            TTT = new string[,] { { " * ", " * ", " * " }, { " * ", " * ", " * " }, { " * ", " * ", " * " } };
            WinCheck = false;
            xOrO = "";
            PrintStaticArray(); //recursive function. 2 types, self referencial, ab recursion.
        }
        //WINCHECK FUNCTION
        void WinCheckFunction(int emptyPosition) //int is introducing the parameter
        {
            if ((TTT[0, 0] == " X " && TTT[0, 1] == " X " && TTT[0, 2] == " X ") ||
                (TTT[0, 1] == " X " && TTT[1, 1] == " X " && TTT[2, 1] == " X ") ||
                (TTT[0, 2] == " X " && TTT[1, 2] == " X " && TTT[2, 2] == " X ") ||
                (TTT[0, 0] == " X " && TTT[0, 1] == " X " && TTT[0, 2] == " X ") ||
                (TTT[1, 0] == " X " && TTT[1, 1] == " X " && TTT[1, 2] == " X ") ||
                (TTT[2, 0] == " X " && TTT[2, 1] == " X " && TTT[2, 2] == " X ") ||
                (TTT[0, 0] == " X " && TTT[1, 1] == " X " && TTT[2, 2] == " X ") ||
                (TTT[0, 2] == " X " && TTT[1, 1] == " X " && TTT[2, 0] == " X "))
            {
                MessageBox.Show("Player X wins");
                xOrO = "";
                WinCheck = true;
            }
            else if ((TTT[0, 0] == " O " && TTT[0, 1] == " O " && TTT[0, 2] == " O ") ||
                (TTT[0, 1] == " O " && TTT[1, 1] == " O " && TTT[2, 1] == " O ") ||
                (TTT[0, 2] == " O " && TTT[1, 2] == " O " && TTT[2, 2] == " O ") ||
                (TTT[0, 0] == " O " && TTT[0, 1] == " O " && TTT[0, 2] == " O ") ||
                (TTT[1, 0] == " O " && TTT[1, 1] == " O " && TTT[1, 2] == " O ") ||
                (TTT[2, 0] == " O " && TTT[2, 1] == " O " && TTT[2, 2] == " O ") ||
                (TTT[0, 0] == " O " && TTT[1, 1] == " O " && TTT[2, 2] == " O ") ||
                (TTT[0, 2] == " O " && TTT[1, 1] == " O " && TTT[2, 0] == " O "))
            {
                MessageBox.Show("Player O wins");
                xOrO = "";
                WinCheck = true;
            }
            if (emptyPosition == 0) //check for draw
            {
                MessageBox.Show("The game is lost. Retry again");
                WinCheck = true;
            }
            if (WinCheck == true) //to reset the game
            {
                gameStart();
            }
        }

        //BUTTON CLICK TO TAKE TURNS
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please input location ");
                return;
            }
            int x = Convert.ToInt32(textBox1.Text);
            int y = Convert.ToInt32(textBox2.Text);

            if (y <= 2 && x <= 2) // to set limit to rows and columns (3,3)
            {
                if (TTT[y, x] == " * ")
                {
                    if (xOrO == "" || xOrO == " O ") //The game always starts with X
                    {
                        TTT[y, x] = " X ";
                        xOrO = " X ";
                    }
                    else if (xOrO == " X ")
                    {
                        TTT[y, x] = " O ";
                        xOrO = " O ";
                    }
                }
                else
                {
                    MessageBox.Show("Please choose another location not used yet");
                    return;
                }
            }
            //TTT[0, 1] = " X ";   //for debugging purposes
            PrintStaticArray(); //Print the array with X/O
        }
    }
}