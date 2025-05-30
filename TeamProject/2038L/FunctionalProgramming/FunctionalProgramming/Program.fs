open System

// Все возможные способы нарезки одной доски 60 на части 18, 21 и 25
let generateSingleBoardCuts() =
    seq {
        for cut18 in 0 .. (60 / 18) do
            let remaining1 = 60 - cut18 * 18
            for cut21 in 0 .. (remaining1 / 21) do
                let remaining2 = remaining1 - cut21 * 21
                let cut25 = remaining2 / 25
                if cut18 * 18 + cut21 * 21 + cut25 * 25 <= 60 then
                    yield (cut18, cut21, cut25)
    } |> Seq.distinct |> Seq.toList

// Все возможные комбинации нарезки для заданного количества досок
let rec generateCombinations boardsLeft currentCombination allCombinations singleCuts =
    if boardsLeft = 0 then
        currentCombination :: allCombinations
    else
        singleCuts
        |> List.fold (fun acc (c18, c21, c25) ->
            let newComb = 
                match currentCombination with
                | None -> (c18, c21, c25)
                | Some (acc18, acc21, acc25) -> (acc18 + c18, acc21 + c21, acc25 + c25)
            generateCombinations (boardsLeft - 1) (Some newComb) acc singleCuts
        ) allCombinations

// Проверяет, можно ли нарезать нужное количество досок
let canCutBoards totalBoards n singleCuts =
    let allCombinations = generateCombinations totalBoards None [] singleCuts
    allCombinations
    |> List.exists (function
        | None -> false
        | Some (cut18, cut21, cut25) -> cut18 >= n && cut21 >= n && cut25 >= n)

// Находит минимальное количество досок
let findMinBoards n =
    let singleCuts = generateSingleBoardCuts()
    let upperBound = ceil(float (n * 18) / 60.0) + ceil(float (n * 21) / 60.0) + ceil(float (n * 25) / 60.0) |> int
    
    {1..upperBound}
    |> Seq.find (fun boards -> canCutBoards boards n singleCuts)

[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> int
    let result = findMinBoards n
    printfn "%d" result
    0