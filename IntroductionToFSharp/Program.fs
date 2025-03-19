open System

type SolveResult =
    None
    | Linear of float
    | Quadratic of float*float

let solve a b c =
    let D = b * b - 4.0 * a * c
    if a = 0.0 then
        if b = 0.0 then None
        else Linear(-c / b)
    else
        if D < 0.0 then None
        else Quadratic((((-b + sqrt D) / (2.0 * a)), ((-b - sqrt D) / (2.0 * a))))

let circleArea radius =
    Math.PI * radius * radius

let cylinderVolume radius height=
    (circleArea radius) * height

let rec sumOfDigitsUp number =
    if number = 0 then 0
    else (number % 10) + sumOfDigitsUp (number / 10)

let rec sumOfDigitsDown number =
    let rec sumDigitsDownLoop number sum =
        if number = 0 then sum
        else
            let newNumber = number / 10
            let digit = number % 10
            let newSum = sum + digit
            sumDigitsDownLoop newNumber newSum
    sumDigitsDownLoop number 0


[<EntryPoint>]
let main argv =
    Console.Write("Enter number: ")
    let number = Console.ReadLine() |> int
    Console.WriteLine($"Sum of digits: {sumOfDigitsDown number}")
    0
