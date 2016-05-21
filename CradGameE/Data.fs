module Data
open System

[<AutoOpen>]
// helper enums for game mechanics
type CardType = Fighter = 0 | Spell = 1 | Resource = 2 | Action = 3
type GamePhase = Prepare = 0 | Activate = 1 | Interfere = 2 | End = 3
type Players = First = 1 | Second = 2 | Third = 3 | Enemy = 0
type CardState = Active = 0 | Blocked = 1 | InHand = 2 | OnDesk = 3 | Used = 4 | Killed = 5 | InStack = 6

///
/// More Comments of Players, at the enemy: E()
///

//Card Stack contains indexes for N cards
let ECardStack = [0..40]
let P1CardStack = [0..15]
let P2CardStack = [0..15]
let P3CardStack = [0..15]

// Card type definition
type Card =
    Action of CardType
    | User of Players
    | State of CardState
    | Stack of int
    | HP of int
    | Attack of int

// Player type definitions
type P1() =
    let me = Players.First
    let mutable activeCard = 0
    let mutable HP = 100
    let stack = Array.zeroCreate<Card> P1CardStack.Length
    member this.takeDamage n = HP <- HP - n
    member this.activateCard c = activeCard <- c
    member this.drawCard = abs(activeCard - 1)
    member this.howsYou = HP
type P2() =
    let me = Players.Second
    let mutable activeCard = 0
    let mutable HP = 100
    let stack = Array.zeroCreate<Card> P2CardStack.Length
    member this.takeDamage n = HP <- HP - n
    member this.activateCard c = activeCard <- c
    member this.drawCard = abs(activeCard - 1)
    member this.howsYou = HP
type P3() =
    let me = Players.Third
    let mutable activeCard = 0
    let mutable HP = 100
    let stack = Array.zeroCreate<Card> P3CardStack.Length
    member this.takeDamage n = HP <- HP - n
    member this.activateCard c = activeCard <- c
    member this.drawCard = abs(activeCard - 1)
    member this.howsYou = HP
    // The Enemy is like an ordinary player, just the goal is to eliminate it; also, has stronger cards
type E() =
    let me = Players.Enemy
    let mutable activeCard = 0
    let mutable HP = 10000
    let stack = Array.zeroCreate<Card> ECardStack.Length
    // Other cards will invoke it with a parameter in action phase
    member this.takeDamage n = HP <- HP - n
    // Card activating, TODO: the card will use itself then automatically if have another target card selected
    member this.activateCard c = activeCard <- c
    member this.drawCard = abs(activeCard - 1)
    member this.howsYou = HP

    // This is the game's state tracker and modifier
type GlobalGamestate() =
    let mutable currentPlayer as Players = Players.First
    let mutable currentGamePhase as GamePhase = GamePhase.Prepare
    member this.nextPlayer =
        currentPlayer <- enum<Players>(((int)currentPlayer + 1) % 3)
    member this.nextGamePhase =
        currentGamePhase <- enum<GamePhase>(((int)currentGamePhase + 1) % 3)
    // The game ends when the enemy had been destroyed
    member this.checkIfEndGame =
        if E().howsYou > 0
            then false
            else true