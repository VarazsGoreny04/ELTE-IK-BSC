module Alma where

or' :: [Bool] -> Bool
or' = foldr (||) False

and' :: [Bool] -> Bool
and' = foldr (&&) True

concat' :: [[a]] -> [a]
concat' = foldr (++) []

length' :: [a] -> Int
length' = foldr (\x -> (+) 1) 0

maximum' :: Ord a => [a] -> a
maximum' = foldr1 max

map' :: (a -> b) -> [a] -> [b]
map' f = foldr ((:) . f) []
--map' f = foldr (\x xs -> f x : xs) []

filter' :: (a -> Bool) -> [a] -> [a]
filter' b = foldr (\x xs -> if b x then x:xs else xs) []