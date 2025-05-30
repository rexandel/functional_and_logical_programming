open System

type Event =
    | Bus of int
    | People of int

let parseEvent (s: string) =
    let parts = s.Split(' ')
    match parts.[0] with
    | "B" -> Bus (int parts.[1])
    | "P" -> People (int parts.[1])
    | _ -> failwith "Unknown event type"

let processEvents events =
    let rec loop remainingPeople acc = function
        | [] -> List.rev acc
        | event :: rest ->
            match event with
            | People p -> loop (remainingPeople + p) acc rest
            | Bus b ->
                let newPeople = max 0 (remainingPeople - b)
                let canBoard = if b > remainingPeople then "YES" else "NO"
                loop newPeople (canBoard :: acc) rest
    loop 0 [] events

[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> int
    let events = 
        List.init n (fun _ -> Console.ReadLine())
        |> List.map parseEvent
    let results = processEvents events
    results |> List.iter (printfn "%s")
    0