# Battleships
  

##An introduction to the program and the report:
The entire program is contained within one class.This has greatly reduced complexity in the program as a whole.This report will be ordred in order of use in the program however if a method requires another method that method will be shown first.
As you can see  above the majority of the code is in nethods that are called when required. The vast majority of methods overite and return an array.
The opening screen
In my version of battleships, the screen opens on ASCII art of the title and then some rules as pictured below. These rules are vital as they allow a user to familiarize themselves with the game and allow them to see how to play.
Console Output:
As you can see the rules are relatively thorough so a user should have no isssues comprehending what to do at any stage in the game.Especcialy as the game does give instructions at each stage. 
The Code:
As you can see the program starts by initialising 2 2d arrays which are both 25 spaces big. These are named “theplayersea” and “thecomputersea”.  The 2d array “theplayersea” is used to store all the ship data relating to the player and all the shot data relating to the computer. However,” thecomputersea” is the same in reverse. It stores all the ship data for the computer and the shot data of the player. Next the Boolean gameover is initialised. This used in the game loop and is not important till later. Then the Console colour is changed, and this is entirely non-functional. The ascii art is now printed. While coding this section I had some issues printing the ascii art however later I realise this was due to backslashes present inside the art. However, this was then easily fixed by using @ at the start of the string to cancel all escape characters. The console then asks for user input to ensure they have read the rules and are ready to continue the game.
 
Next the console is cleared, and two methods are called.
Generate random Coordinate:
 
As you can see this is a simple method that is used to generate a random number under 5. This used any time the computer must make a move or place a ship.



##Set Computer Board:

 
This method is massively self-explanatory. It takes in the original blank 2d array and 7 ships in random coordinates from the previous method.
Get player coordinate:
 
This method starts by taking user input as a string and converting it all to lower case. This is very basic input sanitisation. Next the code enters a while loop to ensure that the method continues until it receives valid input. Then the string is fed into a switch case which returns a different value for each possible input. If an input is invalid it will be stuck in the while loop and keep asking the user to try again until a valid input is achieved. Outside the while statement the method will return 10. As you can see from the annotations, I am aware this never happens however it is easier than error suppression.

###This looks like this in the Console:
 

##Set Player Board:
As you can see above the first thing this method does is call the previous Get_player_Coordinate method. It asks the user for an X coordinate then calls the method. The same is repeated for y. The console output for this is screen shotted below:
Then a Boolean named validxy is initialised and used in a while loop to check if the coordinate input was valid (i.e. already a ship in this array). If it is not it updates the array value, so it is now a value of a ship. If it is it asks again which is pictured below:
 
Then the ship count (i2) is iterated. Once i2 is greater than or equal to 7 the first while loop is broken and the method returns the updated array with the 7 ships in.




##Write Player array:

 As you can see above this method writes the player array. It splits the array into the tow elements and writes out the array as a grid or matrix. The integer represents all the horizontal value whereas v represents all the vertical values. I have also added spacing so that the result looks neater when it is printed. There is console screen shot below to illustrate my point. This makes it more readable to humans.
No Spacing:		Spacing:


	

##Write Computer array:

 

As you can see this method is practically identical apart from an if statement. This if statement makes the console write the player view of the computer array. This means any ships are printed as empty sea and not ships. This allows a fair game.

Write Both arrays together:
 
This is the first method inside the game loop. The name is misleading and instead of just printing the m together it clears the console and then writes all the information that needs to be in the screen in a human friendly format.
Check Shot:
 
This method is fairly long. The first thing that happens is that there is a while statement that goes on for as long s the Boolean valis shot is false. This Boolean is representative of whether the coordinate has been checked and is valid. Then the value of the array location is set to the int sea value. Then there is another switch case that will update the array. If there is a value of 0 in the array it will update the value to a 2 (a miss) and if there is a value of a 1 it will change the value to a 3 (a hit). If the value is already a 2 and 3 this means there already has been an attempted shot. This where the other Boolean “ask player” comes into play. As both the computer and the player use this method to verify coordinates the if statements use the Boolean to know whether to randomly generate new coordinates or ask the player for new coordinates. 
It looks like this for repeat player coordinates:

Player Shot:
 
This the player shot it handles a player attempt to shot the enemy battleship. It works by getting a set of coordinates through the get player coordinate method. Then it assigns the value of the Boolean askplayer for check shot and then it calls check shot and sets the updated array as equal to thecomputersea. Then it returns the updated computer sea from check shot.
Computer Shot:
 
This is one is nearly identical to the player shot method however the values of the variables are different. Instead of X and Y being equal to the method get player coordinate they are equal to the method Generate Random Coordinate. As well as the Boolean askplayer being false instead of true.
Check Win:


This is the final method in the program, and it is used to check if the game is over. It works by importing an array and counting if amount of ships left in the array. It does this with a foreach statement. Every time there is value of 1 (the value of an un-sunk ship in the array) it iterates the count. It then returns the final count. This can be done to check if the game is over as the game only ends when there are 0 ships left. Therefore, when the variable shipcount is equal to 0 the game is over.
###Game Loop:
 

This the last bit of code that will be analysed in this report and is where the actual game is run from. The first line in the loop calls the method write both arrays together so that the player can see the board the game is played on. The next two lines call Player Shot and Computer Shot methods, respectively. These are the last two methods called at the end of a game. The next part is the if statement that can the game loop. It checks if the computer has won first and it does this by calling the check win statement. If shipcount is returned as 0 the code in the if statement is run. In this case it Writes the line You lost and ends the game loop by setting game over as true. The next part is another if statement that check if the player has won. It does this the same way the computer has won but instead of giving the check win method the player sea it give check win the computer sea. If the player has one It writes You win and exits the while loop by setting the Boolean Game Over to true. 
###Console view of win:			

###Console view of lost:
					
