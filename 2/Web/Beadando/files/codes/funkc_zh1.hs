module Zárthelyi1 where

scalar :: (Int, Int, Int) -> (Int, Int, Int) -> Int
scalar (a, b, c) (d, e, f) = (a * d) + (b * e) + (c * f)

numbers :: [Int]
numbers = [x | x <- [1000,999..1], x `mod` 5 == 3, (3 * x) `mod` 7 == 2]

logicalFunctionA :: Bool -> Bool -> Bool -> Bool
logicalFunctionA a b c
    | a == b && b == c = a
    | a /= b && b == c = b
    | a == b && b /= c = c
    | otherwise = True