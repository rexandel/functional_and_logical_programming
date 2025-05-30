open System

let generateTriangle n =
    let rec generateRows t acc i =
        if i > n then List.rev acc
        else
            let rec generateRow t rowAcc j =
                if j > i then (t, List.rev rowAcc)
                else
                    let newT = (615949L * t + 797807L) % (1L <<< 20)
                    let value = newT - (1L <<< 19)
                    generateRow newT (value :: rowAcc) (j + 1)
            
            let (newT, row) = generateRow t [] 1
            generateRows newT (row :: acc) (i + 1)
    
    generateRows 0L [] 1

let computeRowSums triangle =
    triangle
    |> List.map (fun row ->
        row
        |> List.scan (+) 0L
        |> List.tail)

let getRangeSum rowSums left right =
    let prefixRight = List.item right rowSums
    let prefixLeft = if left = 0 then 0L else List.item (left - 1) rowSums
    prefixRight - prefixLeft

let findMinSubTriangleFrom triangle rowSums startRow startCol =
    let n = List.length triangle
    
    let rec iterate currentRow currentCol currentSum minSum =
        if currentRow >= n then minSum
        else
            let rowSum = getRangeSum (List.item currentRow rowSums) currentCol (currentCol + (currentRow - startRow))
            let newSum = currentSum + rowSum
            let newMinSum = min minSum newSum
            iterate (currentRow + 1) currentCol newSum newMinSum
    
    iterate startRow startCol 0L Int64.MaxValue

let findMinSubTriangle triangle =
    let rowSums = computeRowSums triangle
    let n = List.length triangle
    
    seq {
        for i in 0 .. n - 1 do
            for j in 0 .. i do
                yield findMinSubTriangleFrom triangle rowSums i j
    }
    |> Seq.min

let solve n =
    let triangle = generateTriangle n
    findMinSubTriangle triangle

let result = solve 1000
printfn "%d" result