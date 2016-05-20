module Data
open System

[<AutoOpen>]
// helper enums for game mechanics
type CardType = Fighter = 0 | Spell = 1 | Resource = 2 | Action = 3
type GamePhase = Prepare = 0 | Activate = 1 | Interfere = 2 | End = 3
type Players = First = 1 | Second = 2 | Third = 3 | Enemy = 0
type CardState = Active = 0 | Blocked = 1 | InHand = 2 | OnDesk = 3 | Used = 4 | Killed = 5 | InStack = 6


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
    let mutable cardStackIndex = 0
    let mutable HP = 100
    let stack = Array.zeroCreate<Card> P1CardStack.Length
    let takeDamage n = HP <- HP - n
type P2() =
    let me = Players.Second
    let mutable activeCard = 0
    let mutable HP = 100
    let stack = Array.zeroCreate<Card> P2CardStack.Length
    let takeDamage n = HP <- HP - n
type P3() =
    let me = Players.Third
    let mutable cardStackIndex = 0
    let mutable HP = 100
    let stack = Array.zeroCreate<Card> P3CardStack.Length
    let takeDamage n = HP <- HP - n
type E() =
    let me = Players.Enemy
    let mutable cardStackIndex = 0
    let mutable HP = 100
    let stack = Array.zeroCreate<Card> ECardStack.Length
    let takeDamage n = HP <- HP - n

type GlobalGamestate() =
    let mutable currentPlayer as Players = Players.First
    let nextPlayer =
        currentPlayer <- enum<Players>(((int)currentPlayer + 1) % 3)
    let mutable currentGamePhase as GamePhase = GamePhase.Prepare
    let nextGamePhase =
        currentGamePhase <- enum<GamePhase>(((int)currentGamePhase + 1) % 3)