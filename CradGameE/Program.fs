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
    // |> Async.Start 
    Command.timer |> Async.Start
    Application().Run(window)
