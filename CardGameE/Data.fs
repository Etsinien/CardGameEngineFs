module Data
open System

[<AutoOpen>]
type CardType = Fighter | Spell | Resource | Action
type GamePhase = Prepare | Activate | Interfere | End
type Players = First | Second | Third | Enemy
type CardState = Active | Blocked | InHand | OnDesk | Used | Killed