# Documentation


## CRC Cards
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



## Early pseudo code for planning game

```
// Load game example

Available games:		

Players: 3	Latest Move: 2020-03-30 15:12		ID: 1

Want to load a game? [Y/N]

var game = context.GetGameEtc()

var game = GameSession(game)



// New game example

GameBoard GameBoard {get; set;}

GameSession() {
    GameBoard = new GameBoard()
}

var game = new GameSession().
    .AddPlayer(new RedPlayer()).
    .AddPlayer(new BluePlayer())
    .RunGame()



RunGame()
{
    while(true) {
		    NextTurn(); { ... PlayerTurn = PlayerTurn + 1; }
		    ...			
	  }
}
```

## User Stories

* As a player i want to be able to play a game of ludo.
* As a player i want to be able to play with up to 3 friends.
* As a player i want to be able to choose color on my piece.
* As a player i want to be able to throw a dice.
* As a player i want to be able to move my piece.
* As a player i want to be able to knock my friends out.
* As a player i want to be able to save my progress.
* As a player i want to be able to start up where i left off.
* As a player i want to be able to finish a game.
* As a player i want to be able to clear the database from deprecated games.
* As a player i want to be able to see History of completed games.


## Process

Vi började med att spela Ludo online för att lära oss reglerna. Googlade på bilder för referens till spelplanen.

### Presentationsdelen

Presentationsdelen är core-projektet TheLudoGame som använder en IHostBuilder och IHostedService som startmetod. Därifrån visas en meny med spelhistorik och valet ges att fortsätta på en senaste spelomgången. Annars så flyttas tidigare spel till historik och man kommer in i ett nytt spel.

Spelets presentationsdel är uppbyggd med en Meny, ScoreBoards samt en Spelkonsoll. Varje spelare har en Scoreboard och GameConsole skriver ut händelser i spelet.

### Spelmotorn

En spelomgång instansieras med ett Game. Game håller koll på övergripande spelregler såsom turordning för spelare samt när ett spel ska anses avslutat.

Game klassen har relationer till andra element i spelet så att en spelomgång kan sparas och hämtas enbart via Game-objektet.

Board klassen håller spelets regler för rörelse på brädet och även kollisionsupptäckning.

Spelbjäser och markbrickor har X och Y koordinater som kan jämföras, och på det viset upptäcker man kollisioner(knuff).


## Designbeslut

Vi valde att förenkla menyn tillräckligt så att vi täckte uppgiftens krav. I lösningen kan endast ett spel vara pågående åt gången (pick up where you left off).

Vi beslutade att bygga objektorienterat med så få statiska medlemmar som möjligt.

En bra lösning tyckte vi var att bygga brädet på koordinater som hämtas ifrån lokala filer i GameEngine/Paths/. Filerna håller koordinater och färgkod för brickorna.


## Spelregler

* Spelare har bara en pjäs åt gången ute på spelplanen (**Unik**)
* Man får ut en pjäs från boet, även i mål, genom att slå en 6:a
* Att slå en 6:a ger ingen extra omgång
* En spelomgång är över när en spelare gått i mål med 4 pjäser
