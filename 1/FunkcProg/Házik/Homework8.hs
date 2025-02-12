module Homework8 where
import Data.Char
import Data.List

data Base = A | T | G | C
    deriving (Show, Eq)

isComplement :: [Base] -> [Base] -> Bool
isComplement [] [] = True
isComplement [] _ = False
isComplement _ [] = False
isComplement (x:xs) (y:ys)
    | x == A && y == T || x == T && y == A ||  x == G && y == C || x == C && y == G = isComplement xs ys
    | otherwise = False

data Transaction = Transfer Int Int | Purchase Int | Receive Int Int String
    deriving (Show)

netGain :: [Transaction] -> Int
netGain [] = 0
netGain (x:xs) = gain x + netGain xs
    where
    gain (Transfer x _) = negate x
    gain (Purchase x) = negate x
    gain (Receive x _ _) = x

wasNegative :: [Transaction] -> Bool
wasNegative a = isNegative (reverse a)
    where
    isNegative [] = False
    isNegative (x:xs)
        | netGain (x:xs) < 0 = True
        | otherwise = isNegative xs

foo1 :: ([[a]],([a],String)) -> Int
foo1 ([_],(a:b,"Hello")) = 0
foo1 ([_],(a:b,'H':'e':'l':'l':'o':xs)) = 1
foo1 ([_,_,_],(a:b,'H':'e':'l':'l':'o':_:_:[])) = 2

foo1Solution2 :: Num a => ([[a]],([a],String))
foo1Solution2 = ([[1],[4],[7]],([10],"Helloka"))

data Gyumolcs = Alma Int Char | Barack | Cseresznye String

foo2 :: (Gyumolcs, String) -> Int
foo2 (Alma 12 'a', "Piros") = 0
foo2 (Barack, 's':'a':xs) = 1
foo2 (Cseresznye ('p':xs), 'p':[]) = 2

foo2Solution2 :: (Gyumolcs, String)
foo2Solution2 = (Cseresznye "paradicsom", "p")