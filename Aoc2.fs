module Aoc2Tests

open Expecto

let checkSumDifference = fun spreadsheet -> 
  let rowSum = fun row -> (List.max row) - (List.min row)
  spreadsheet |> List.sumBy rowSum 

let checkSumED = fun spreadsheet ->
  let rowQoutient = fun row -> Seq.head (seq {
      for cell in row do
        for cellOther in row do
          if cell <> cellOther && cell % cellOther = 0 then
            yield cell / cellOther
  })
  spreadsheet |> List.sumBy rowQoutient

[<Tests>]
let tests = 
  testList "Advent Of Code" [
    testList "2" [
      testCase "Example A" <| fun _ -> 
        let input = [
          [ 5; 1; 9; 5];
          [ 7; 5; 3];
          [ 2; 4; 6; 8]
        ]
        Expect.equal (checkSumDifference input) 18 "Invalid checksum"
    ]
    testList "2B" [
      testCase "Example A" <| fun _ ->
        let input = [
          [5; 9; 2; 8]
          [9; 4; 7; 3]
          [3; 8; 6; 5]
        ]
        Expect.equal (checkSumED input) 9 "Invalid checksum"
    ]
  ]