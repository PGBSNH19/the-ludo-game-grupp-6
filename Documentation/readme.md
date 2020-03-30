# Documentation

| Class RedPlayer | Interaction |
| --------------- | ----------- |
|                 | Player      |

| abstract Class Player    | Interaction  |
| ------------------------ | ------------ |
| BoardSquare[] squarePath | BoardPiece   |
|                          | Game Session |
|                          | RedPlayer    |
|                          | BluePlayer   |
|                          | YellowPlayer |
|                          | GreenPlayer  |


| Class GameSession    | Interaction |
| -------------------- | ----------- |
| List<Player> Players | Player      |
|                      | GameBoard   |





### Pseudo code

// Load game example

Available games:		

Players: 3			Latest Move: 2020-03-30 15:12			ID: 1

Want to load a game? [Y/N]

var game = context.GetGameEtc()

var game = GameSession(game)



// New game example

GameBoard GameBoard {get; set;}

GameSession() {

​	GameBoard = new GameBoard()

}

var game = new GameSession().

​						.AddPlayer(new RedPlayer()).

​						.AddPlayer(new BluePlayer())

​						.RunGame()



RunGame()

{

​	while(true) {

​		NextTurn(); { ... PlayerTurn = PlayerTurn + 1; }

​		...

​			

​	}

}
| Class RedPlayer                | Interaction   |
| ------------------------------ | ------------- |
|                                | Player        |

| abstract Class Player          | Interaction   |
| ------------------------------ | ------------- |
| BoardSquare[] squarePath       | BoardPiece    |
|                                | Game Session  |
|                                | RedPlayer     |
|                                | BluePlayer    |
|                                | YellowPlayer  |
|                                | GreenPlayer   |


| Class GameSession              | Interaction   |
| ------------------------------ | ------------- |
|                                | Player        |
|                                | GameBoard     |

