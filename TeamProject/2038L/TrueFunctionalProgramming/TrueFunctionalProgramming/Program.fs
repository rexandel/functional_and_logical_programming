open System

let generateSingleBoardCuts len18 len21 len25 =
    [ for cut18 in 0 .. (60 / len18) do
        let remaining1 = 60 - cut18 * len18
        for cut21 in 0 .. (remaining1 / len21) do
            let remaining2 = remaining1 - cut21 * len21
            for cut25 in 0 .. (remaining2 / len25) do
                if cut18 * len18 + cut21 * len21 + cut25 * len25 <= 60 then
                    yield (cut18, cut21, cut25) ]

let canCutBoards totalBoards need18 need21 need25 len18 len21 len25 =
    let rec checkCombinations boardsLeft need18 need21 need25 combinations =
        if boardsLeft = 0 then
            need18 <= 0 && need21 <= 0 && need25 <= 0
        else
            combinations
            |> List.exists (fun (cut18, cut21, cut25) ->
                checkCombinations (boardsLeft - 1) (need18 - cut18) (need21 - cut21) (need25 - cut25) combinations)
    
    let possibleCuts = generateSingleBoardCuts len18 len21 len25
    checkCombinations totalBoards need18 need21 need25 possibleCuts

let minBoards n =
    let len18, len21, len25 = 18, 21, 25
    let upperBound = ceil (float (n * len18) / 60.0) + ceil (float (n * len21) / 60.0) + ceil (float (n * len25) / 60.0) |> int
    [1 .. upperBound]
    |> List.find (fun totalBoards -> canCutBoards totalBoards n n n len18 len21 len25)

[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> int
    let result = minBoards n
    printfn "%d" result
    0