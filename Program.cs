using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class MainClass
    {
        static int score, highscore;
        static int maxAmount = 50, minAmount = 1;

        static void Main(string[] args)
        {
            string appName = "Number Guessr".ToUpper();
            string appVersion = "1.0.0";
            string appAuthor = "Dmitri @Novurran";

            Console.ForegroundColor = ConsoleColor.Black;
            //Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("{0}: Version {1}, Author: {2}",appName,appVersion,appAuthor);

            Console.WriteLine("What's your name?");
            string input = Console.ReadLine();

            SetName(input);

            Random randoNum1 = new Random();
            int rand = randoNum1.Next(minAmount, maxAmount);

            SetGuess(rand,input);

            int randomNum = rand, guessNum = 0;

            SetGuess(randomNum, input);
        }

        static void SetName(string usersName)
        {
            Console.WriteLine("Hello {0}, let's play Number Guessr", usersName);
        }


        static void SetGuess(int numberNeeded, string userName)
        {

            Random hint = new Random();
            int randomHint = hint.Next(1, 5);
            int hintedNumber = 0;

            if (numberNeeded - randomHint < 0)
            {
                hintedNumber = numberNeeded + randomHint;
            }
            else
            {
                Random addOrPlus = new Random();
                int randomAOP = addOrPlus.Next(0, 5);

                if (randomAOP >= 1)
                {
                    hintedNumber = numberNeeded + randomHint;
                }
                else if (randomAOP == 0)
                {
                    hintedNumber = numberNeeded - randomHint;
                }
            }

            if (hintedNumber > numberNeeded)
            {
                Console.WriteLine("Guess a number between 1 & {0}, my number is around but less than {1}", maxAmount.ToString(), hintedNumber);
            }
            else
            {
                Console.WriteLine("Guess a number between 1 & {0}, my number is around but more than {1}", maxAmount.ToString(), hintedNumber);
            }

            string numInput = Console.ReadLine();

            if (numInput == numberNeeded.ToString())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("you're right the answer is " + numberNeeded);
                Console.ResetColor();

                score += 5*(numberNeeded/2);
                if (score > highscore)
                {
                    highscore = score;
                }

                Random randoNum1 = new Random();
                int rand = randoNum1.Next(minAmount, maxAmount);

                PlayerDecision(userName);
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;

                score += 3 * (numberNeeded / 2);
                if (score > highscore)
                {
                    highscore = score;
                }

                Console.WriteLine("you're wrong, the answer was " + numberNeeded);
                Console.ResetColor();

                PlayerDecision(userName);
            }
        }

        static void PlayerDecision(string userName)
        {
            Console.WriteLine("Do you want to continue? [-Y] or [-N] or if you want to see your HighScore [-H]");
            string decisionInput = Console.ReadLine();

            switch (decisionInput)
            {
                case "[-Y]":
                    RestartGame(userName);

                    break;

                case "-Y":
                    RestartGame(userName);

                    break;

                case "-y":
                    RestartGame(userName);

                    break;

                case "[-N]":
                    ByeMessage(userName);

                    break;

                case "-N":
                    ByeMessage(userName);

                    break;

                case "-n":
                    ByeMessage(userName);

                    break;

                case "[-H]":
                    Console.WriteLine("Your High Score is {0}", highscore);
                    PlayerDecision(userName);

                    break;

                case "-H":
                    Console.WriteLine("Your High Score is {0}", highscore);
                    PlayerDecision(userName);

                    break;

                case "-h":
                    Console.WriteLine("Your High Score is {0}", highscore);
                    PlayerDecision(userName);

                    break;

                default:
                    Console.WriteLine("{0} is not a valid command, try again.", '"' + decisionInput + '"');
                    PlayerDecision(userName);
                    break;
            }

        }

        static void RestartGame(string userName)
        {
            Random randoNum = new Random();
            int rand = randoNum.Next(minAmount, maxAmount);

            SetGuess(rand, userName);
            highscore = 0;
            score = 0;
        }

        void GetHighScore()
        {

        }

        static void ByeMessage(string userName)
        {
            Console.WriteLine("Well, bye {0}", userName);
            Console.WriteLine("Your HighScore was {0}", highscore);
            Environment.Exit(-1);
        }
    }
}