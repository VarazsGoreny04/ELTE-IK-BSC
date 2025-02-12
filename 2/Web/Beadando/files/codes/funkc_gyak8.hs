module Péntek where
import Prelude hiding (map, filter)

apply :: (a -> a) -> a -> a
apply f = f

applyTwice :: (a -> a) -> a -> a
applyTwice f x = f (f x)

map :: (a -> b) -> [a] -> [b]
map f [] = []
map f xs = [f x | x <- xs]
-- map f (x:xs) = f x : map f xs

filter :: (a -> Bool) -> [a] -> [a]
filter f xs = [x | x <- xs, f x]
-- filter f (x:xs) 
--     | f x = x : filter xs
--     | otherwise = filter xs