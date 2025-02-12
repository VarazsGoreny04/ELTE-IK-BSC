module Gyak2 where

sumSquaresTo :: Integer -> Integer
sumSquaresTo 0 = 0
sumSquaresTo x 
    | x > 0 = x^2 + sumSquaresTo(x-1)
    | x < 0 = x^2 + sumSquaresTo(x+1)

divisors :: Integer -> [Integer]
divisors x = [n | n <- [2..x-1], x `mod` n == 0]

faceLift :: Num a => [(a,a)] -> [[a]]
faceLift [] = []
faceLift ((x,y):xs) = (x : [y]) : faceLift xs

    