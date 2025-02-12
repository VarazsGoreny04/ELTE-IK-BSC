module Negyedik_ora where
    duplicateElements :: [a] -> [a]
    duplicateElements [] = []
    duplicateElements (x:xs) = x : x : duplicateElements xs

    everySecond :: [a] -> [a]
    everySecond [] = []
    everySecond [x] = []
    everySecond (x:y:xs) = y : everySecond xs

    take' :: Int -> [a] -> [a]
    take' _ [] = []
    take' 0 _ = []
    take' n (x:xs) 
        | n > 0 = x : take' (n - 1) xs
        | otherwise = []

    isPrefixOf :: Eq a => [a] -> [a] -> Bool
    isPrefixOf [] _ = True
    isPrefixOf _ [] = False
    isPrefixOf (x:xs) (y:ys) = (x == y) && isPrefixOf xs ys

    merge :: Ord a => [a] -> [a] -> [a]
    merge [] [] = []
    merge xs [] = xs
    merge [] ys = ys
    merge (x:xs) (y:ys)
        | x == y = x : y : merge xs ys
        | x < y = x : merge xs (y:ys) 
        | otherwise = y : merge (x:xs) ys

    sublist :: Int -> Int -> [a] -> [a]
    sublist _ _ [] = []
    sublist _ 0 _ = []
    sublist 0 m (x:xs) = x : sublist 0 (m - 1) xs
    sublist n m (x:xs) = sublist (n - 1) m xs

    pizza :: [(String, Int)] -> Int
    pizza [] = 0
    pizza [(x,y)] = 500 + y
    pizza ((x,y):xs) = y + pizza xs