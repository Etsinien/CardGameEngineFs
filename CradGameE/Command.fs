module Command
open Data

let GAME = new Data.GlobalGamestate()
//let Scoreboard = new ScoreBoard()
let rec tick =
    async {
        do! Async.Sleep 500
        //do  if GAME.checkIfEndGame
                //then showScoreBoard
               //// Actions there, would be better to dont use  
            //if PlayerIsDone
            //  then if NoMoreMovesInPhase
            //       then GAME.nextPhase()
            //  else GAME.nextPlayer()
            //       
        do! tick
    }
