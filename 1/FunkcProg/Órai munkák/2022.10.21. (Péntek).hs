module Péntek where
import Data.Char

cipher :: String -> String
cipher (x:y:z:xs)
        | isLetter x && isLetter y && isDigit z = [x,y] --x:y:[]
cipher _ = []

zip' :: [a] -> [b] -> [(a,b)]
zip' (x:xs) (y:ys) = (x,y) : zip' xs ys
zip' _ _ = []