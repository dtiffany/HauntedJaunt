# CS410 Game Programming Spring 2025: Project 2

Modifications to Unity Learn | 3D Beginner: John Lemon - Complete Project, implementing gameplay elements described below.

## Dot product - Alarm when in enemy sight (Julia Wheless)
  Dot product is used to give the enemies a cone of vision. If the player is in the enemy's vision, an alarm sounds, warning the player that they will be caught if they move closer. Implemented by using the dot product of the enemy postion and the player position to give enemies a 3.5 unit view radius and a 90 degree view angle in the Observer script. Alarm sound was added to the prefab Observer script and set to play when player is in cone of view and stop when player is not.

## Linear interpolation - John Lemmon Bag change color & size (Dylan Tiffany)
  When coins are collected, Linear Interpolation is used to increase the size of John Lemmons bag.
    Created a new function in "PlayerMovement.cs" that will update the size of the bag every time our user collects a coin.
  When John Lemmon is near a ghost, Linear Interpolation is used to turn the color of the bag green.
    Implemented by adding a script "ColorChanger.cs" to a new 3D object 'Bag' as a child of JohnLemon, and attaching the Enemies group as "Ghost." 

## Particle effect with trigger - Coin pickup collision (Clio Tsao)
  A particle effect is triggered on collision between the player (John Lemon) and the coins on the map.
  Implemented by adding a "CoinParticles" Particle System under the player gameObject. "PlayerMovement.cs" plays the CoinParticle ParticleSystem on collision with gameObjects with the tag "Pickup".

## Sound effect with trigger - Coin pickup sound (Clio Tsao)
  A sound effect is triggered on collision between the player (John Lemon) and the coins on the map.
  Implemented by adding an "AudioManager" object to the scene associated with the script "AudioManager.cs" that contains the function ```public void PlayRandomSoundClip(AudioClip[] audioClip, Transform spawnTransform, float volume)```. This function is called from "PlayerMovement.cs" on collision with gameObjects with tag "Pickup" (which are coins), upon which it picks a random sound from an array (uploaded under the player gameObject), spawns an audioSource gameObject which plays the sound, and destroys it after playing.
  Sound effects from Unity Asset Store package "Coins Sfx" by Little Robot Sound Factory.
