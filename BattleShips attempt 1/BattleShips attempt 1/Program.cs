using System;
namespace BattleShips_attempt_1
{
    class Program
    {
        static int Generate_Random_Coirdinate()// generates random coirdinates for the computer to play
        {
            Random c = new Random();// creates a new random
            int coirdinate = c.Next(5);//initializes an integer with a random value under 5
            return coirdinate;//returns that value
        }
        static int[,] Set_Computer_Board(int[,] thecomputersea)//sets up the computer board
        {
            int i = 0;//amount of ships allready place
            while(i <= 7)// if there is less then or equal to the maxiumun amount of ships
            { 
                    var x = Generate_Random_Coirdinate();//generates coirdiante
                    var y = Generate_Random_Coirdinate();// ""
                    thecomputersea[x, y] = 1;//sets that coirdinates value to 1
                    i++;//iterates the ship count
                    //Console.WriteLine(value);//prints the value used when 
            }
            return thecomputersea;//returns the array
        }
        static int Get_Player_coirdinate()// takes user input and turns it into a coirdinate
        {
            string input = Console.ReadLine().ToLower();//reads what the user wrote
            Boolean ValidInput = false;//is the input a valid option
            while (ValidInput == false)
            {
                switch (input)//takes the input and turns it into an integer
                {
                    case "1" or "a":
                        return 0;
                    case "2" or "b":
                        return 1;
                    case "3" or "c":
                        return 2;
                    case "4" or "d":
                        return 3;
                    case "5" or "e":
                        return 4;
                    default://if the input was something unexpected
                        Console.WriteLine("try again");
                        input = Console.ReadLine().ToLower();
                        break;//breaks the switch case to return in the while loop
                }
            }
            return 10;//never happens
        }
        public static int i = 0;//general purpose
        public static int i2 = 0;// ""
        static int[,] Set_Player_Board(int[,] theplayersea)//sets the player board
        {
            while (i2 != 7)// keeps in a loop until there are 7 ships
            {
                Console.WriteLine("please choose an X coirdinate");
                int x = Get_Player_coirdinate();//uses annoted function to get a valid coirdinate 
                Console.WriteLine("Choose a Y Coirdinate");
                int y = Get_Player_coirdinate();// same as x just used for y
                Boolean ValidXY = false;
                while (ValidXY == false)//while the input is considred in valid
                {
                    if (theplayersea[x, y] != 1)//check if thart coirdinate has allready been used
                    {
                        theplayersea[x, y] = 1;// sets the value of coirdinate
                        ValidXY = true;//returns it was valuid
                    }
                    else//when not valid
                    {
                        Console.WriteLine("These Coirdinates have allready been used try again");// alerts user to mistake
                        Console.WriteLine("Choose a X Coirdinate");
                        x = Get_Player_coirdinate();//asks for a new valid input
                        Console.WriteLine("Choose a Y Coirdinate");
                        y = Get_Player_coirdinate();// """
                    }
                }
                i2++;// iterates valid ship count
            }
            return theplayersea;//returns the 2d array
        }
        static int[,] Check_Shot(int[,] theenemysea, int x, int y, Boolean askplayer)//checks the shot is vallid
        { 
            Boolean ValidShot = false;//checks if the shot was valild
            while (ValidShot == false)//while the shot isnt valid
            {
                int SeaValue = theenemysea[x, y];// assigns the value of an int to the value of the player chosen location in the 2d array
                switch (SeaValue)//creates a switch case to check,update and return the result in the arrays
                {
                    case 0://if the value of the array location is 0(blank sea)
                        theenemysea[x, y] = 2;//changes the value to a miss
                        Console.WriteLine("Miss");//alerts the player
                        ValidShot = true;
                        break;
                    case 1://if there was a ship there
                        theenemysea[x, y] = 3;//updates the array value
                        Console.WriteLine("Hit");//alerts the user that they where succesful
                        ValidShot = true;
                        break;
                    case 2 or 3://when the user was entered an invalid shot location
                        if (askplayer == true)
                        {
                            Console.WriteLine("Invalid You have allready attempted to shoot here.Please try Agian");//alerts the user of thier mistake
                            Console.WriteLine("Choose another X coirdinate");
                            x = Get_Player_coirdinate();//gets a new valid coirdinate from an annotated method
                            Console.WriteLine("Choose another Y Coirdinate");
                            y = Get_Player_coirdinate();

                        }
                        else
                        {
                            x = Generate_Random_Coirdinate();//generates a new coirdinate for the computer
                            y = Generate_Random_Coirdinate();// ""
                        }
                        break;
                }
            }
                return theenemysea;//returns the updated array and ends the method
        }
                
        static int[,] PlayerShot(int[,] thecomputersea)//handles a player shooting the enemy board
        {
            Console.WriteLine("Choose an X coirdinate");
            int x = Get_Player_coirdinate();//gets a valid coirdinate from the player through an anotated method
            Console.WriteLine("Choose a Y coirdinate");
            int y = Get_Player_coirdinate();// ""
            Boolean askplayer = true;//for the Check_Shot method have to ask the player if the coirdinates are invalid
            thecomputersea = Check_Shot(thecomputersea, x, y, askplayer);//calls method to check if the shot is valid and update array
            return thecomputersea;//returns the new computer sea
        }
        static int[,] Computer_Shot(int[,] theplayersea)
        {
            int x = Generate_Random_Coirdinate();//gets a valid random coirdinate
            int y = Generate_Random_Coirdinate();//""
            Boolean askplayer = false;//for the Check_Shot method have to ask the player if the coirdinates are invalid
            theplayersea = Check_Shot(theplayersea, x, y, askplayer);//calls method to check if the shot is valid and update array
            return theplayersea;//returns the new player sea
        }
        static void writearray(int[,] playerarray)//prints the player array
        {
            for (int h = 0; h < playerarray.GetLength(0); h++)//handles the horizontal aspect of the 2d array
            {
                for (int v = 0; v < playerarray.GetLength(1); v++)// handles the vertical aspect
                {
                    Console.Write(playerarray[h, v]);//writes the value of the array value
                    Console.Write(" ");// spaces out the results
                }
                Console.WriteLine();//splits the line into rows and columns
            }
        }
        static void write_computer_array(int[,] thecomputersea)//prints the player view of the computer array
        {
            for (int h = 0; h < thecomputersea.GetLength(0); h++)//handles the horizontal aspect of the 2d array
            {
                for (int v = 0; v < thecomputersea.GetLength(1); v++)// handles the vertical aspect
                {
                    if(thecomputersea[h, v] == 1)//if there is hip in that location
                    {
                      Console.Write("0");//write it as empty sea
                    }
                   else
                    {
                        Console.Write(thecomputersea[h, v]);//if not write the true value
                    }
                    Console.Write(" ");// spaces out the results
                }
                    Console.WriteLine();//spits into lines and collumns
            }

        }
        static void write_both_arrays_together(int [,] theplayersea , int [,] thecomputersea)
        {
            Console.Clear();
            Console.WriteLine("Battleshiups V 1.0.0");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Your sea:");
            writearray(theplayersea);//writes the player board
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Your shots:");
            write_computer_array(thecomputersea);//writes player view of computer sea
        }

        static int checkwin(int[,] array)//checks if the game is over
        {
            int shipcount = 0;//amount of remaining ships
            foreach (var value in array)//goes through the whole array
            {
                if (value == 1)// if the value is a code for  an unsunk ship
                {
                    shipcount++;//increase the count
                }
            }
            return shipcount;//return thr remaining amount of ships
        }
        static void Main(string[] args)//main
        {
            int[,] theplayersea = new int[5, 5];//creates a new blank array 25 spaces big
            int[,] thecomputersea = new int[5, 5];// ""
            Boolean gameover = false;//used later to verify if the game is over or not
            { 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("                                     # #  ( )");
                Console.WriteLine("                                  ___#_#___|__");
                Console.WriteLine("                              _  |____________|  _");
                Console.WriteLine("                       _=====| | |            | | |==== _");
                Console.WriteLine("                 =====| |.---------------------------. | |====");
                Console.WriteLine("   <--------------------'  B.A.T.L.L.E.S H .I P S.'----------------/");
                Console.WriteLine(@"    \                                                             /");
                Console.WriteLine(@"     \_______________________________________________HMS_________/");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine(@"  _______   _                _____            _                  ");
                Console.WriteLine(@" |__   __| | |              |  __ \          | |               _ ");
                Console.WriteLine(@"    | |    | |__     ___    | |__) |  _   _  | |   ___   ___  (_)");
                Console.WriteLine(@"    | |    | '_ \   / _ \   |  _  /  | | | | | |  / _ \ / __|    ");
                Console.WriteLine(@"    | |    | | | | |  __/   | | \ \  | |_| | | | |  __/ \__ \  _ ");
                Console.WriteLine(@"    |_|    |_| |_|  \___|   |_|  \_\  \__,_| |_|  \___| |___/ (_)");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1.The grid is 5 by 5");
                Console.WriteLine("2. All ships have a sizie of 1x1");
                Console.WriteLine("3.There are 7 ships");
                Console.WriteLine("4.The player allways goes first");
                Console.WriteLine("5.You can refrence both the X and Y axis with both the numbers 1 -5 and letters A-E");
                Console.WriteLine("6. the Game is not case sensitive");
                Console.WriteLine("7.The key for the sea is as follows 0 is empty space, 1 is a ship, 2 is a miss and 3 is sunk ship");
                Console.Write("Press enter to Continue");
                Console.ReadLine();
                Console.Clear();
            }//Print rules and title
            thecomputersea = Set_Computer_Board(thecomputersea);// calls a method to set up the computer board
            theplayersea = Set_Player_Board(theplayersea);//calls a method to setup a player array

            while (gameover == false)//game loop
            {
                write_both_arrays_together(theplayersea, thecomputersea);//write the player view of both arrays
                PlayerShot(thecomputersea);//does the player shot
                Computer_Shot(theplayersea);//does the computers shot
                if (checkwin(theplayersea) == 0)// if the computer wins 
                {
                    Console.WriteLine("You Lost");
                    gameover = true;//exists the game loop
                }
                if (checkwin(thecomputersea) == 0)//if the player wins
                {
                    Console.WriteLine("You Won!");
                    gameover = true;//exits the game loop
                }
                
            }
            Console.Read();//stops the program ending so the player can see the loop
        }
    }
}