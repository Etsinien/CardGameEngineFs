// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
module Main
open System
open System.Windows
open Data
open Command

[<STAThread>]
[<EntryPoint>]
let main argv = 
    let window = WPFLib.MainWindow()
    // Business Logic should be in Command, here just UI related methods
    Command.tick |> Async.Start
    Application().Run(window)
