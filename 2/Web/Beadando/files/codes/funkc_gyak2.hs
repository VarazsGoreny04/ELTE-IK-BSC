module Házi where

--isEvenTouple :: Int -> (Int, Bool)
isEvenTuple :: Integral a => a -> (a, Bool)
isEvenTuple n = (n, even n)

isOrigo :: (Double, Double) -> Bool
--isOrigo (x, y) = x == 0 && y == 0
isOrigo (0, 0) = True
isOrigo _ = False

swap :: (a, b) -> (b, a)
swap (x, y) = (y, x)

triplicate :: a -> (a, a, a)
triplicate a = (a, a , a)

addPair :: (Num a, Num b) => (a, b) -> (a, b) -> (a, b)
--addPair (x1, y1) (x2, y2) = (x1 + x2, y1 + y2)
addPair x y = (fst x + fst y, snd x + snd y)

divisors :: Int -> [Int]
divisors n = [x | x <- [n,(n-1)..1], n `mod` x == 0]

isPrime :: Int -> Bool
isPrime n = n > 2
isPrime n = null (divisors n)