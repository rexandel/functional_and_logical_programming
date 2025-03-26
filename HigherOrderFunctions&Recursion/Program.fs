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

let rec sumOfDigitsDown number =
    let rec sumDigitsDownLoop number sum =
        if number = 0 then sum
        else
            let newNumber = number / 10
            let digit = number % 10
            let newSum = sum + digit
            sumDigitsDownLoop newNumber newSum
    sumDigitsDownLoop number 0

let taskNumberSix flag =
    match flag with
        | true -> sumOfDigitsDown
        | false -> fibDown

let rec numberTraversal num (func: int->int->int) acc = 
     match num with
        | 0 -> acc
        | n -> numberTraversal (n / 10) func (func acc (n % 10))

[<EntryPoint>]
let main argv =
    Console.WriteLine($"Sum of digits of number: {numberTraversal 465 (fun x y -> (x + y)) 0}")
    Console.WriteLine($"Product of digits of number: {numberTraversal 465 (fun x y -> (x * y)) 1}")
    Console.WriteLine($"Minimum digit of number: {numberTraversal 465 (fun x y -> if x < y then x else y) 10}")
    Console.WriteLine($"Maximum digit of number: {numberTraversal 465 (fun x y -> if x > y then x else y) -1}")
    0
