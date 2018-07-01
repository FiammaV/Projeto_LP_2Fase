# Zombie Game

## Who did this project?

* __Inês Gonçalves__
  * a21702076

* __Inês Nunes__
  * a21702520

* __Sara Gama__
  * a21705494

## Git repository

We worked together in a public repository that can be found here:
[link](https://github.com/FiammaV/Projeto_LP_2Fase).

## Task distribution

Everyone equally colaborated in this project, in person.
But below, there's a more in-depth report of who did what.

* __Inês Gonçalves__
  * Classes: World, GameManager, UserInterface, Agent, Config, Playable, Program;
  * Added comments;
  * Made the report;
  * Enumeration: AgentType;
  * Made the fluxogram;
  * Made the UML.

* __Inês Nunes__
  * Classes: World, UserInterface, AI, Agent, Config, GameManager, Playable;
  * Added comments;
  * Made the report;
  * Made the fluxogram;
  * Made the UML.

* __Sara Gama__
  * Classes: World, Menu, Agent, Program, UserInterface;
  * Added comments;
  * Made the report;
  * Made the fluxogram;
  * Made the UML.

## Our solution

### Architecture

The project is divided into different classes, with enumerations and interfaces,
to keep everything organized.

When launching, the program will render a menu with four different options.
When the game begins, it will create 4 different kinds of agents:
Human, playable humans, zombie, and playable zombies.
The amount of each will be defined earlier by the player on the command arguments.
The agents will be shuffled randomly using the _Fisher Yates_ method.

There is two kinds of playing:
Automatic, which is played using an AI, and the Manual.
In the manual mode, the player can control either humans or zombies, identified with the color
blue and magenta, while the AI is identified with the color green and red.
The current player will be identified with the color yellow.

To check the winning condition, we have a _do-while_, making the game run until the program
has reached the maximum amount of turns and when all the humans have been infected.


### UML Diagram

![UML Diagram](https://i.imgur.com/doiZ7N3.png)

### Fluxogram

<p align="center">
  <img src="https://i.imgur.com/doiZ7N3.png" alt="Fluxogram"/>
</p>

## Conclusions

With this project, we have learned how to better organize the code into classes.
We have also learned how to structure our methods and constructors in a clearer way, which
has helped structure the fluxogram and specially, the UML.

## References

* <a name="ref1">[1]</a> Whitaker, R. B. (2016). The C# Player's Guide
  (3rd Edition). Starbound Software.
* We also have received guidance from our colleague Leandro Brás, who has
helped us with the AI and the agents' movements.

