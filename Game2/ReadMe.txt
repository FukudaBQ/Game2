In this program, you can use WASD or arrow to control the sprite which is link. Then you can use 1, 2, 3 to use projectiles. In order to use sword, you can press Z or N.
Then you can press T, Y, U, I, O to change the state of enemies. Lastly, use q to quit, use R to reset the game.
Bugs: 1. After using Z or N to use sword, and pressing 1,2, or 3 to use projectiles, the projectiles will stay at player's location.
	  2. When walk close to those four blocks on the map, sometimes the link can't move. So we need to use some other direction keys to walk through the space between blocks.



For sprint 3, you can still use WASD or arrow to control the sprite which is link. Then you can use 1, 2, 3 to use projectiles. In order to use sword, you can press Z or N.
There are some bugs which still haven't been solve:    1. Since we use radius to construct blocks in the map, sometimes the player can't move through directly,
												       so you may need to move around, and find a way to walk through.
													   2. Another thing is that after using sword, then if you press 1, 2 or 3 to use projectiles right after using sword, 
													   the projectile will stay next to the player.
The tool we used to construct the map is called Tiled. We put blocks and items into the map by using this tool. Then we just need to call each item and block by using a 
for loop in the main class, then the items and blocks will show up.
