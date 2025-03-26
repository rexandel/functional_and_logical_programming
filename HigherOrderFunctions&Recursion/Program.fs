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

let rec numberTraversalWithCondition num (func: int->int->int) acc (condition: int->bool) =
    match num with
        | 0 -> acc
        | n -> 
            let digit = n % 10
            let nextNumber = n / 10
            let flag = condition digit
            match flag with
                | false -> numberTraversalWithCondition nextNumber func acc condition
                | true -> numberTraversalWithCondition nextNumber func (func acc digit) condition

let favouriteProgrammingLanguage language =
    match language with
        | "F#" | "Prolog" -> "Sneaky one..."
        | "Assembly" | "C" -> "Hardcore programmer!"
        | "Haskell" -> "Are you a fan of functional languages?"
        | "Python" -> "Practical choice!"
        | _ -> "Don't know that one..."

let askAboutFavouriteLangLanguageUsingSuperposition () = 
    Console.WriteLine("What is your favorite programming language?")
    (Console.ReadLine >> favouriteProgrammingLanguage >> Console.WriteLine)()

let askAboutFavouriteLangLanguageUsingCurry () =
    Console.WriteLine("What is your favorite programming language?")
    let pipeline inputReader processor outputWriter = 
        let userInput = inputReader()
        let processedResult = processor userInput
        outputWriter processedResult
    pipeline Console.ReadLine favouriteProgrammingLanguage Console.WriteLine

let rec gcd a b =
    match b with
    | 0 -> a
    | _ -> gcd b (a % b)

let traverseCoprimes number operation initialValue =
    let rec loop n op acc current =
        if current <= 0 then acc
        else
            let updatedAcc =
                if gcd n current = 1 then
                    op acc current
                else
                    acc
            loop n op updatedAcc (current - 1)
    loop number operation initialValue number

let eulerFunction number =
    traverseCoprimes number (fun x y -> x + 1) 0

let traverseCoprimesCondition number (func: int->int->int) (condition: int->bool) initial =
    let rec traversal number (func :int->int->int) (condition: int->bool) acc candidate =
        match candidate with
        | 0 -> acc
        | _ ->
            let nextCandidate = candidate-1
            let isCoprime = if gcd number candidate = 1 then true else false
            let flag = condition candidate
            match flag, isCoprime with
                | true, true -> traversal number func condition (func acc candidate) nextCandidate
                | _, _ -> traversal number func condition acc nextCandidate
    traversal number func condition initial number


let isPrime n =
    let rec check i =
        if i * i > n then true
        elif n % i = 0 then false
        else check (i + 1)
    if n <= 1 then false
    else check 2

let maxPrimeDivisor n =
    let rec findMaxDivisor acc current =
        if current <= 1 then acc
        elif n % current = 0 && isPrime current && (acc = 0 || current > acc) then
            findMaxDivisor current (current - 1)
        else
            findMaxDivisor acc (current - 1)
    findMaxDivisor 0 (abs n / 2)

[<EntryPoint>]
let main argv =
    Console.Write("Input a number: ")
    let number = Console.ReadLine() |> int
    
    Console.WriteLine($"Max prime divisor of {number}: {maxPrimeDivisor number}")
    0
