module Gyakzh2 where

dropAll :: Eq a => a -> [a] -> [a]
dropAll _ [] = []
dropAll x (y:xs) 
    | x == y = dropAll x xs
    | otherwise = y : dropAll x xs

unzipPairs :: [(a,a)] -> [a]
unzipPairs [] = []
unzipPairs ((x,y):xs) = [x,y] ++ unzipPairs xs

maybeDouble :: [Bool] -> [Integer] -> [Integer]
maybeDouble _ [] = []
maybeDouble [] _ = []
maybeDouble (x:xs) (y:ys)
    | x = y : y : maybeDouble xs ys
    | otherwise  = y : maybeDouble xs ys

reverseTruples :: [(a,b,c)] -> [(c,b,a)]
reverseTruples [] = []
reverseTruples ((x,y,z):xs) = (z,y,x) : reverseTruples xs

stormInHogwarts :: [(Double, Char, Bool)] -> Double
stormInHogwarts [] = 0
stormInHogwarts ((x,y,z):xs)
    | z = x + stormInHogwarts xs
    | otherwise = stormInHogwarts xs

toTupleList :: [a] -> [(a,a)]
toTupleList [] = []
toTupleList xs = [(x,x) | x <- xs]

toInfinityAndBeyond :: [a] -> [a]
toInfinityAndBeyond [] = []
toInfinityAndBeyond xs = xs ++ reverse xs ++ toInfinityAndBeyond xs

exactlyTwoTimes' :: Eq a => a -> [a] -> [a]
exactlyTwoTimes' _ [] = []
exactlyTwoTimes' y (x:xs)
    | y == x = x : exactlyTwoTimes' y xs
    | otherwise = exactlyTwoTimes' y xs

exactlyTwoTimes :: Eq a => a -> [a] -> Bool
exactlyTwoTimes _ [] = False
exactlyTwoTimes y (x:xs)
    | length (exactlyTwoTimes' y (x:xs)) == 2 = True
    | otherwise = False

faceLift :: Num a => [(a,a)] -> [[a]]
faceLift [] = []
faceLift ((x,y):xs) = [x,y] : faceLift xs