// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
module Main
open System
open System.Windows

[<STAThread>]
[<EntryPoint>]
let main argv = 
    let window = WPFLib.MainWindow()
    
    Application().Run(window)
