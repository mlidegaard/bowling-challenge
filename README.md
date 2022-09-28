# Design choices
I've tried to model the implementation to match that of a real bowling game, while ensuring that each class only has a single responsibility.
* "Program" is what initialises the program. It is in charge of the bowling game simulation, and allows you to play it.
* "BowlingGame" starts a new game when it's initialised. It lets you roll the ball and see the score. Each game is initialised with 1 scoreboard and 10 frames.
* "Frame" keeps track of i.e. whether you're allowed to roll again within that frame & the rolls you have performed within the frame.  The frame only knows about itself and its own state. Frame only expose one public method which is to knock over pins.
* "Scoreboard" is responsible of all the calculations of giving points based on the frames. The scoreboard doesn't have any dependencies, and only exposes one public method which is CalculateScore, which points based on the frames it's given as input.

I have furthermore created a set of unit tests to cover the various different scenarios in which you can get points while playing the bowling game.

A few words on design decisions on routes I chose not to take
* I've chosen not to add Roll as a class, as I thought the class itself would become too simple, and thus introducing more complexity than gaining. A list of integers 'rolls' has taken a place in its stead which recides in Frame.
* The 10th Frame is different from all the other frames in that if we get a strike or a spare we'll get a 3rd roll. I could have chosen to split the first 9 frames and the last frame into different classes, using the same interface, or go some polymorphic route. But again I thought the simplicity of introducing 2 more methods "IsLastFrame" and "NeedThirdRollForBonus" to Frame far outweighed the complexity I would need to introduce, while still adhering to match the implementation to the real game.
 
# Assumptions
I have chosen only to do simple integer validation on amount of pins knocked, as you can't knock down more pins than physically exists in a game of bowling.

# How to run the program
The program is a console application. To run it clone the project and either:
1) Open the solution in your favourite .NET IDE and run the program
2) Navigate to the folder bowling-challenge/bin/Release/net6.0 and run bowling-challenge.exe
