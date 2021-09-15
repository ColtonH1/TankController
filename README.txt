GitHub: https://github.com/ColtonH1/TankController

Control scheme and Game Mechanics:
	-Basic movements as required for the project: WASD to move, spacebar to shoot, esc to quit, backspace to restart level
	-Additional control: Scroll with the mouse wheel to switch between bullet types
	-Both the player and the enemy have 3 health
	-When the enemy is close to the player, damage is done as to simulate being beaten by the enemy (animation is the only thing needed to make this look realistic)

Shoot Projectiles Innovation: 
	-A secondary projectile that instantly kills the enemy
	-A tertiary projectile that locks on to the enemy and fires at him no matter where he is
	
	Please note, at the moment, this is an easy switch for the player (use the scroll wheel to switch between them and therefore too easy, but the plan is to make the 
	player work to get this projectile and have it be on a random time frame that the player can obtain this projectile. In particular, I plan to have ammo boxes laid 
	by the enemy with random chance of getting bullets (less of a chance to get the strong bullets and more of a chance to get the normal bullet)

Boss Battle Design:
	-Movement Patterns: 
		*Patrol the area
		*Chase player when within range
		*Charge at player
	-Damage Attack Patterns
		*Shoot a fire ball at the player when within range
		*Charge at the player on a random amount of time (1/1000 updates)
	-Innovation 
		*Shoot a gas ball at the player knocking them backwards

VFX and SFX:
	-Each bullet has a sound effect and particle effect
	-When shooting, the tank has a flash bang particle effect that goes off
	-When killed, both characters have exploding particles
	-There are VFX and SFX for every aspect of something being done

Boss movement:
	Boss alternates between moving by starting off with patroling, then charging the player at random times or following the player if the player is too close
		Please note, it is possible that at the beginning of the level, the enemy charges the player rather than starting to patrol. Charging is done at random intervals, 
		so the random number could come up at the beginning.


Difficulties:
	-The part I got most stuck on was figuring out how to get the particle effect to both follow and damage the player
		I was able to find the proper way to have the particle effect follow the player, but I could never figure out how to get the particle effect collide with the player
		I ended up instantiating a "Dammage Bullet" (one of the type of bullets the player uses) and disabling the mesh renderer, so it couldn't be seen. I had this bullet
		instantiate at the same time as the particle effect and follow the player in the same exact way as the particle effect. My next problem was that since I couldn't
		get the particle effect to collide with the player, I had no way of disabling it at the right time. For this, I took the easy way out and told the script to disable
		any object in the hierarchy with the exact name as the particle effect.

Known bugs: There is only one bug I know of that I haven't figured out how to fix yet.
	-When shooting with the "Lock On" projectile, if you shoot exactly four time, then the first three bullets will kill the enemy, but the fourth will, for an unknown reason,
	bounce off where the enemy was and slowly fly backwards in the air (picture something floating in space, that's what this looks like)
	-A minor issue, though not a bug since I know the problem, bullets can damage other bullets. The way I set up my scripts, one script requires the health script to function.
	The bullets need the first script and so, because of this, bullets now have health even though they don't need it. I chose not to fix this since this could be considered 
	a feature since the player could block the enemy bullet by shooting back
	-Another issue: the bullets are friendly fire bullets, this is mainly a problem for the enemy since he can shoot and it'll take 5 seconds for the bullet to disappear 
	(unless it collides with the player first). In these 5 seconds, if the enemy gets in between the player and bullet, the bullet will collide with the enemy and count as a hit
