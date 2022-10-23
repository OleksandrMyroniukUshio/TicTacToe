using System;
using System.Threading;

namespace TicTacToe
{
    internal class Program
    {
        // Filling board with spaces(1,5,6,7,8 positions have ASCII symbol Alt+255 to avoid conflict with WinLogic();) 
        static char[] table = { 'a', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '};
        static uint turn = 1;
        static int choice;
        static bool GameRun = true;
        static void Draw()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", table[1], table[2], table[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", table[4], table[5], table[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", table[7], table[8], table[9]);
            Console.WriteLine("     |     |      ");
        }
        static void Main(string[] args)
        {
            while (GameRun)
            {
                Console.Clear();
                Draw();
                TurnChoice();
                Validate();
                WinLogic();
            }
            WinMsg();
        }
        static void TurnChoice()
        {
            if(turn % 2 != 0) Console.WriteLine("Player:X TURN:\nChoose your position");
            else Console.WriteLine("Player:O TURN:\nChoose your position");
        }
        static void Validate()
        {
            try {choice = Convert.ToInt32(Console.ReadLine()); }
            catch (Exception) {Terminate();}
            if (choice < 1 || choice > 9) Terminate();
            if (table[choice] != 'O' && table[choice] != 'X')
            {
                if (turn % 2 == 0) { 
                    table[choice] = 'O';
                    turn++;
                }
                else {
                    table[choice] = 'X'; 
                    turn++; 
                }
            }
            else {
                Console.WriteLine("Position {0} is already taken by {1}!", choice, table[choice]);
                Thread.Sleep(1000);
            }
        }
        static void WinLogic()
        {
            if (turn > 9) {GameRun = false; return;}
            //horizontal axis
            if (table[1] == table[2] && table[2] == table[3]) GameRun = false;
            else if (table[4] == table[5] && table[5] == table[6]) GameRun = false;
            else if (table[7] == table[8] && table[8] == table[9]) GameRun = false;
            //vertical axis 
            else if (table[1] == table[4] && table[4] == table[7]) GameRun = false;
            else if (table[2] == table[5] && table[5] == table[8]) GameRun = false;
            else if (table[3] == table[6] && table[6] == table[9]) GameRun = false;
            //horizontal axis
            else if (table[1] == table[5] && table[5] == table[9]) GameRun = false;
            else if (table[3] == table[5] && table[5] == table[7]) GameRun = false;
        }
        static void WinMsg()
        {
            Console.Clear();
            Draw();
            if (turn > 9){ Console.WriteLine("\nDRAW"); return; }
            if (turn % 2 == 0) Console.WriteLine("\nPLAYER:X WON THE GAME!");
            else Console.WriteLine("\nPLAYER:O WON THE GAME!");
        }
        static void Terminate()
        {
            Console.WriteLine("Something wrong with input");
            GameRun = false;
            Environment.Exit(0);
        }
    }
}
