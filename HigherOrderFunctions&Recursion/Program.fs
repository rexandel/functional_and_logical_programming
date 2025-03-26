open System

let rec fibUp number =
    match number with
        | 0 -> 0
        | 1 -> 1
        | n -> fibUp(n - 1) + fibUp(n - 2)

let rec fibDown number =
    let rec fibLoop pred now num =
        match num with
            | 0 -> now
            | _ -> fibLoop now (now + pred) (num - 1) 
    fibLoop 1 0 number

[<EntryPoint>]
let main argv =
    Console.WriteLine(fibUp 19)
    Console.WriteLine(fibDown 19)
    0
