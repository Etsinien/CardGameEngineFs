module Command
open Data
//[<AutoOpen>]
//type timer() =
    let rec tick =
        async {
            do! Async.Sleep 500
               //// Actions there
            do! tick
        }
