using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace tictaetoe
{
    class Program
    {      
        static void Main(string[] args)
        {
            TicTaeToeGame game = new TicTaeToeGame();
            Console.WriteLine("                         ----------------TIC TAE TOE GAME || CREATED BY-MOHIT----------------\n");
            string[] playerName = new string[2];
            for(int i = 0; i < playerName.Length; i++)
            {
                Console.Write("Enter Player{0} Name: ",i+1);
                playerName[i] = Console.ReadLine();
            }
            game.Play(playerName);    
        }   
    }
    class TicTaeToeGame
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag = 0;
        public void Play(string[] players)
        {
           
            Random num = new Random();
            int index = num.Next(0,2);
            string player1, player2;
            player1 = players[index];
            if (index == 0)
            {
                player2 = players[1];
            }
            else
            {
                player2 = players[0];
            }
        begin:
            Console.Clear();
            Console.WriteLine("                         ----------------TIC TAE TOE GAME || CREATED BY-MOHIT----------------\n");
            char chchoice1=' ', chchoice2=' ';
            string stch1;
            Console.WriteLine("                                     Player {0} : choose X or O", player1);
            Console.Write("                                     Enter you choice: ");
            try
            {
                chchoice1 = char.Parse(Console.ReadLine());
                if (char.IsDigit(chchoice1) || (chchoice1!='X' && chchoice1!='O' && chchoice1 != 'x' && chchoice1 != 'o'))
                {
                    Console.WriteLine();
                    Console.WriteLine("                                    **Please choose X or O only");
                    Thread.Sleep(1000);
                    goto begin;
                }
            }
            catch(Exception exp)
            {
                Console.WriteLine();
                Console.WriteLine("                                      **Invalid Input!!");
                Thread.Sleep(2000);
                goto begin;
            }
            
            stch1 = chchoice1.ToString().ToUpper();
            if(stch1 == "X")
            {
                chchoice2 = 'O';
            }
            else if (stch1 == "O")
            {
                chchoice2 = 'X';
            }
            do
            {
                Console.Clear();
                Console.WriteLine("                         ----------------TIC TAE TOE GAME || CREATED BY-MOHIT----------------\n");
                Console.WriteLine("                             Player {0}: {1} and Player {2}: {3}",player1, stch1,player2, chchoice2);
                Console.WriteLine("\n");
                
                Board();
                Console.WriteLine();
            playerchance:
                if (player % 2 != 0)
                {
                    Console.Write("                             Player {0} Chance: ",player1);
                }
                else
                {
                    Console.Write("                             Player {0} Chance: ",player2);
                }
            
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if (choice <= 0 || choice>9 )
                    {
                        Console.WriteLine();
                        Console.Write("                         **Please select between 1-9");
                        Thread.Sleep(1000);
                        Console.SetCursorPosition(0, Console.CursorTop);
                        ClearCurrentConsoleLine();
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        ClearCurrentConsoleLine();
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        ClearCurrentConsoleLine();
                        goto playerchance;
                    }
                    
                }
                catch(Exception e)
                {
                    Console.WriteLine("                           **Please enter a valid input!!");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(0, Console.CursorTop);
                    ClearCurrentConsoleLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    goto playerchance;
                }
                
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("                            **Sorry the row {0} is already marked with {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Thread.Sleep(2000);
                }
                flag = CheckWin();
            } while (flag != 1 && flag != -1);
            Console.Clear();
            Board();
            if (flag == 1)
            {
                Console.WriteLine("                         ----------------TIC TAE TOE GAME || CREATED BY-MOHIT----------------\n\n");
                Console.WriteLine();
                Console.WriteLine("                                 Congratulations Player {0} has won", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("                         ----------------TIC TAE TOE GAME || CREATED BY-MOHIT----------------\n\n");
                Console.WriteLine("                                                It's a Draw");
            }
            Console.ReadLine();
        }
        private  void Board()
        {
            Console.WriteLine("                                       |     |      ");
            Console.WriteLine("                                    {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("                                  _____|_____|_____ ");
            Console.WriteLine("                                       |     |      ");
            Console.WriteLine("                                    {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("                                  _____|_____|_____ ");
            Console.WriteLine("                                       |     |      ");
            Console.WriteLine("                                    {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("                                       |     |      ");
        }
        private  int CheckWin()
        {
            if (arr[1] == arr[2] && arr[2] == arr[3])//Winning Condition For First Row   
            {
                return 1;
            }
            else if (arr[4] == arr[5] && arr[5] == arr[6])//Winning Condition For Second Row   
            {
                return 1;
            }
            else if (arr[7] == arr[8] && arr[8] == arr[9])//Winning Condition For Third Row   
            {
                return 1;
            }
            else if (arr[1] == arr[4] && arr[4] == arr[7])//Winning Condition For First Column    
            {
                return 1;
            }
            else if (arr[2] == arr[5] && arr[5] == arr[8])//Winning Condition For Second Column  
            {
                return 1;
            }
            else if (arr[3] == arr[6] && arr[6] == arr[9]) //Winning Condition For Third Column  
            {
                return 1;
            }
            else if (arr[1] == arr[5] && arr[5] == arr[9])//Winning Condition For Major Diagonal 
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])//Winning Condition For Minor Diagonal  
            {
                return 1;
            }
            //Check if all position been filled then its a Tie match
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public static void ClearCurrentConsoleLine()//Function to clear selected console only
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
