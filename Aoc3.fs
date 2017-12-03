module Aoc3Tests

open Expecto

let sqrwave = fun period step ->
  if period = 0 then 0 else ( ( step + period / 2 ) % period ) - period / 2 |> abs
let getsidelength = fun (n:int) ->
  let rec next = fun (sidelength:int) ->
    if float sidelength ** 2.0 |> int >= n then sidelength else next ( sidelength + 2 )
  next 1

let mhd = fun (n:int) ->
  let sidelength = getsidelength n
  let maxringn = float sidelength ** 2.0 |> int
  let distancetocorner = maxringn - n
  let diff = sqrwave ( sidelength - 1 ) distancetocorner
  sidelength - 1 - diff

[<Tests>]
let tests = 
  testList "Advent Of Code" [
    testList "3" [
      testCase "Example A" <| fun _ -> 
        let input = 1
        Expect.equal (mhd input) 0 "Invalid distance"
      testCase "Example B" <| fun _ -> 
        let input = 12
        Expect.equal (mhd input) 3 "Invalid distance"
      testCase "Example C" <| fun _ -> 
        let input = 23
        Expect.equal (mhd input) 2 "Invalid distance"
      testCase "Example D" <| fun _ -> 
        let input = 1024
        Expect.equal (mhd input) 31 "Invalid distance"
      testCase "Distance 6" <| fun _ -> 
        for input in [ 31; 37; 43; 49 ] do
          Expect.equal (mhd input) 6 ( sprintf "Invalid distance for %i" input )
      testCase "Distance 5" <| fun _ -> 
        for input in [ 26; 30; 32; 36; 38; 42; 44; 48 ] do
          Expect.equal (mhd input) 5 ( sprintf "Invalid distance for %i" input )
      testCase "Distance 4" <| fun _ -> 
        for input in [ 13; 17; 21; 25; 27; 29; 33; 35; 39; 41; 45; 47 ] do
          Expect.equal (mhd input) 4 ( sprintf "Invalid distance for %i" input )
      testCase "Distance 3" <| fun _ -> 
        for input in [ 10; 12; 14; 16; 18; 20; 22; 24; 28; 34; 40; 46 ] do
          Expect.equal (mhd input) 3 ( sprintf "Invalid distance for %i" input )
      testCase "Distance 2" <| fun _ -> 
        for input in [ 3; 5; 7; 9; 11; 15; 19; 23 ] do
          Expect.equal (mhd input) 2 ( sprintf "Invalid distance for %i" input )
      testCase "Distance 1" <| fun _ -> 
        for input in [ 2; 4; 6; 8 ] do
          Expect.equal (mhd input) 1 ( sprintf "Invalid distance for %i" input )
    ]
  ]