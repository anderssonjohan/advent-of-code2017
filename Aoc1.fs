module Tests

open Expecto

let charToString = fun c -> [| c |] |> System.String
let parseInt = fun str -> str |> System.Int32.Parse
let stringToCharList = fun (str:string) -> str.ToCharArray() |> Array.toList
let stringToListOfInt = fun str -> stringToCharList str |> List.map ( charToString >> parseInt ) 
let sumCaptcha = fun step (digitList:int list) ->
  let next = fun i -> 
    let nextIndex = i + step
    digitList.[ if nextIndex >= digitList.Length then nextIndex - digitList.Length else nextIndex ]
  let addIfNextDigitMatches = fun (index,digit) -> if digit = next( index ) then digit else 0
  let indexAndDigits = digitList |> List.mapi (fun i d -> (i, d))

  indexAndDigits |> List.sumBy addIfNextDigitMatches

let aoc1a = fun str ->
  let digitList = stringToListOfInt str
  digitList |> sumCaptcha 1
let aoc1b = fun str ->
  let digitList = stringToListOfInt str
  digitList |> sumCaptcha (digitList.Length / 2)

[<Tests>]
let tests =
  testList "Advent Of Code" [
    testList "1" [    
      testCase "Example A" <| fun _ ->
        let input = "1122"
        Expect.equal (aoc1a input) 3 "Invalid result"
      testCase "Example B" <| fun _ ->
        let input = "1111"
        Expect.equal (aoc1a input) 4 "Invalid result"
      testCase "Example C" <| fun _ ->
        let input = "1234"
        Expect.equal (aoc1a input) 0 "Invalid result"
      testCase "Example D" <| fun _ ->
        let input = "91212129"
        Expect.equal (aoc1a input) 9 "Invalid result"
    ]
    testList "1B" [
      testCase "Example A" <| fun _ ->
        let input = "1212"
        Expect.equal (aoc1b input) 6 "Invalid result"
      testCase "Example B" <| fun _ ->
        let input = "1221"
        Expect.equal (aoc1b input) 0 "Invalid result"
      testCase "Example C" <| fun _ ->
        let input = "123425"
        Expect.equal (aoc1b input) 4 "Invalid result"
      testCase "Example D" <| fun _ ->
        let input = "123123"
        Expect.equal (aoc1b input) 12 "Invalid result"
      testCase "Example E" <| fun _ ->
        let input = "12131415"
        Expect.equal (aoc1b input) 4 "Invalid result"
    ]
  ]