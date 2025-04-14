# CS410 Game Programming Spring 2025: Project 2

Modifications to Unity Learn | 3D Beginner: John Lemon - Complete Project, implementing gameplay elements described below.

## Dot product - 

## Linear interpolation - 

## Particle effect with trigger - Coin pickup collision (Clio Tsao)
  A particle effect is triggered on collision between the player (John Lemon) and the coins on the map.
  Implemented by adding a "CoinParticles" Particle System under the player gameObject. "PlayerMovement.cs" plays the CoinParticle ParticleSystem on collision with gameObjects with the tag "Pickup".

## Sound effect with trigger - Coin pickup sound (Clio Tsao)
  A sound effect is triggered on collision between the player (John Lemon) and the coins on the map.
  Implemented by adding an "AudioManager" object to the scene associated with the script "AudioManager.cs" that contains the function ```public void PlayRandomSoundClip(AudioClip[] audioClip, Transform spawnTransform, float volume)```. This function is called from "PlayerMovement.cs" on collision with gameObjects with tag "Pickup" (which are coins), upon which it picks a random sound from an array (uploaded under the player gameObject), spawns an audioSource gameObject which plays the sound, and destroys it after playing.
  Sound effects from Unity Asset Store package "Coins Sfx" by Little Robot Sound Factory.
