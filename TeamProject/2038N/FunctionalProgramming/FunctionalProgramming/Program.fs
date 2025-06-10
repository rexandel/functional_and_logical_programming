open System

let getCorrectOperator (left: char) (right: char) : char =
    match compare (int left) (int right) with
        | result when result < 0 -> '<'
        | result when result > 0 -> '>'
        | _ -> '='

let isExpressionTrue (expression: string) : bool =
    let chars = expression.ToCharArray()
    let leftDigit = chars.[0]
    let operator = chars.[1]
    let rightDigit = chars.[2]
    let correctOperator = getCorrectOperator leftDigit rightDigit
    operator = correctOperator

let fixExpression (input: string) : string =
    match isExpressionTrue input with
        | true -> input
        | false ->
            let chars = input.ToCharArray() |> List.ofArray
            let leftDigit::op::rightDigit::_ = chars
            let correctOperator = getCorrectOperator leftDigit rightDigit
            [leftDigit; correctOperator; rightDigit]
            |> String.Concat

[<EntryPoint>]
let main (_: string[]) : int =
    let t = Console.ReadLine() |> int
    let testCases = [ for _ in 1..t -> Console.ReadLine() ]

    testCases
        |> List.map fixExpression
        |> List.iter (printfn "%s")
    0