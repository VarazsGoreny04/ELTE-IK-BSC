module Homework5 where
    
password :: [Char] -> [Char]
password [] = []
password (x:xs) = '*' : password xs

lookup' :: Eq a => a -> [(a, b)] -> b
lookup' k ((x,y):xs)
    | k == x = y
    | otherwise = lookup' k xs

toBin :: Integer -> [Int]
toBin 0 = []
toBin x
    | even x = 0 : toBin (x `div` 2)
    | otherwise = 1 : toBin (x `div` 2)
    
remdup :: Eq a => [a] -> [a]
remdup (x:y:xs)
    | x == y = remdup (x:xs)
    | x /= y = x : remdup (y:xs)
remdup x = x

mergeToSet :: Ord a => [a] -> [a] -> [a]
mergeToSet [] [] = []
mergeToSet x [] = remdup x
mergeToSet [] y = remdup y
mergeToSet (x:xr:xs) (y:ys)
    | x == y  = mergeToSet (x:xr:xs) ys
    | x > y = mergeToSet (y:x:xr:xs) ys
    | x < y && xr == y = x : mergeToSet (xr:xs) ys
    | x < y && xr > y = x : mergeToSet (y:xr:xs) ys
    | x < y && xr < y && x == xr = mergeToSet (xr:xs) (y:ys)
    | x < y && xr < y && x /= xr = x : mergeToSet (xr:xs) (y:ys)