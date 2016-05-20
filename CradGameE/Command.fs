module Command
open Data
//[<AutoOpen>]
    let rec tick =
        async {
            do! Async.Sleep 500
               //// Actions there by arg
            do! tick
        }
