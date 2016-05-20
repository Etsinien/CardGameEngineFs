module Data
open System

[<AutoOpen>]
type CardType = Fighter = 0 | Spell = 1 | Resource = 2 | Action = 3
type GamePhase = Prepare = 0 | Activate = 1 | Interfere = 2 | End = 3
type Players = First = 1 | Second = 2 | Third = 3 | Enemy = 0
type CardState = Active = 0 | Blocked = 1 | InHand = 2 | OnDesk = 3 | Used = 4 | Killed = 5 | InStack = 6

// Enemy Card Stack contains indexes for N cards
let ECardStack = [0..40]
let P1CardStack = [0..15]
let P2CardStack = [0..15]
let P3CardStack = [0..15]

type Card =
    Action of CardType
    | User of Players
    | State of CardState
    | Stack of int

type GlobalGamestate() =
    let mutable currentPlayer as Players = Players.First
    let nextPlayer =
        currentPlayer <- enum<Players>(((int)currentPlayer + 1) % 3)
    let mutable currentGamePhase as GamePhase = GamePhase.Prepare
    let nextGamePhase =
        currentGamePhase <- enum<GamePhase>(((int)currentGamePhase + 1) % 3)
        

        
