module Faszom3 where

import Prelude hiding (zipWith, filter, map)
--selectiveApply :: (a -> a) -> (a -> Bool) -> [a] -> [a]
--selectiveApply a b c = [a x| x <- c, b x]

selectiveApply :: (a -> a) -> (a -> Bool) -> [a] -> [a]
selectiveApply a b c = map a (filter b c)

findIndices :: (a -> Bool) -> [a] -> [Int]
findIndices b x = map fst (filter (b . snd) (zip [0..] x))

--doubleTheEven :: Integral a => [a] -> [a]
--doubleTheEven x = [a*2| a <- x, even a]

doubleTheEven :: Integral a => [a] -> [a]
doubleTheEven = selectiveApply (* 2) even

{-
Elmélet1:
M

Elmélet:

Magasabb rendű függvény: 
Függvényt vár paramétereként, vagy függvényt ad vissza (ilyen a (.) operátor is)
Magasabb rendűnek nevezzük azt a függvényt ami paraméterként függvényt vár
:t <függvény neve> -> tipus , és van benne zárójelben két paraméter, akkor magasabb rendű
:i tipusosztaly

Szeletek: Operátorokból képzett függvények
Csak magasabb rendu fuggvenyek parameterekent? -> Nem, mert nem vár további függvényt paraméterül (Num b => [b] -> [b])
Pl.: (3 <), (> 3), (^ 2), (4 *), (`div` 7)

Parciális függvény: Nem minden adható paramétert váró függvény
Parciális alkalmazás (Más néven curryzés): Azt jelenti, hogy egy függvénynek nem adjuk meg az összes paraméterét
Pl.:
add :: Int -> Int -> Int
add x y = x + y
addOne = add 1

Névtelen függvények (Lambdák): Név nélkül működő függvények, melyek segítségével bármilyen szelet kifejezhető
Pl.: \x -> x + 1 
A fenti függvény egyenlő ezzel: (+1)

Függvénykompozíció: Függvények egymásba ágyazva úgy, hogy az egyik függvény bemenete lesz a másik eredménye
                    A kompozíciót egy függvényként kezeljük

-}

--9.gyak 
apply :: (a -> b) -> a -> b
apply f = f

applyTwice :: (a -> a) -> a -> a
applyTwice f x = f (f x)

map :: (a -> b) -> [a] -> [b]
map f [] = []
map f (x:xs) = f x : map f xs

filter :: (a -> Bool) -> [a] -> [a]
filter f xs = [ x | x <- xs, f x ]

---------
--10.gyak

zipWith :: (a -> b -> c) -> [a] -> [b] -> [c]
zipWith f (x:xs) (y:ys) = f x y : zipWith f xs ys
zipWith _ _ _ = []

differences :: Num a => [a] -> [a]
differences [] = []
differences (x:xs) = zipWith (-) xs (x:xs)

isUniform :: Eq b => (a -> b) -> [a] -> Bool
isUniform f (x:y:xs) = f x == f y && isUniform f (y:xs)
isUniform _ _ = True

selectivelyApply :: (a -> a) -> (a -> Bool) -> [a] -> [a]
selectivelyApply _ _ [] = []
selectivelyApply f p (x:xs)
    | p x = f x : selectivelyApply f p xs
    | otherwise = x : selectivelyApply f p xs

dropSpaces :: String -> String
dropSpaces = dropWhile (==' ')

--reverse dropspace
trim :: String -> String
--trim xs = reverse ( dropSpaces ( reverse ( dropSpaces xs )))
trim xs = reverse $ dropSpaces $ reverse $ dropSpaces xs

monogram :: String -> String
--monogram xs = unwords $ (map (:['.'])) $ (map head) $ words xs
monogram xs = unwords $ map ((:['.']) . head) $ words xs

evenList :: Integral a => [[a]] -> [[a]]
evenList = filter (even . sum)