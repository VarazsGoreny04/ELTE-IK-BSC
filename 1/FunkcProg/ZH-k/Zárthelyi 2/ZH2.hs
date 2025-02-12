module Zárthelyi_2_A where

duplicateEverySecond :: [a] -> [a]
duplicateEverySecond [] = []
duplicateEverySecond [x] = [x]
duplicateEverySecond (x:y:xs) = x : y : y : duplicateEverySecond xs

sortTuples :: Ord a => [(a,a)] -> [(a,a)]
sortTuples [] = []
sortTuples ((x,y):xs)
    | x < y = (x,y) : sortTuples xs
    | otherwise = (y,x) : sortTuples xs

interleave :: [a] -> [a] -> [a]
interleave [] ys = ys
interleave xs [] = xs
interleave (x:xs) (y:ys) = x : y : interleave xs ys 