module Homework6 where
import Data.Char
import Data.List

listDiff :: Eq a => [a] -> [a] -> [a]
listDiff x [] = x
listDiff [] _ = []
listDiff (x:xs) y
    | x `notElem` y = x : listDiff xs y
    | otherwise = listDiff xs y

validGame :: String -> Bool
validGame a
    | last x /= head y = False
    | null xs = True
    | otherwise = validGame (unwords (y:xs))
    where (x:y:xs) = words a

countSingletons :: [[a]] -> Int
countSingletons [] = 0
countSingletons ([x]:xs) = 1 + countSingletons xs
countSingletons (_:xs) = countSingletons xs

sameParity :: [Int] -> Bool
sameParity [] = True
sameParity [x] = True
sameParity (x:y:xs)
    | x `mod` 2 /= y `mod` 2 = False
    | otherwise = sameParity (y:xs)

longestChain :: String -> Int
longestChain [] = 0
longestChain [_] = 1
longestChain a = maximum (chain a)
    where
    chain [x,y] = [link [x,y]]
    chain (x:y:xs) = link (x:y:xs) : chain (y:xs)
    link [_] = 1
    link (x:y:xs)
        | x == y = 1 + link (x:xs)
        | otherwise = 1

normalizeText :: String -> String
normalizeText [] = []
normalizeText (x:xs) = map toUpper (filter (== x) "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ") ++ normalizeText xs