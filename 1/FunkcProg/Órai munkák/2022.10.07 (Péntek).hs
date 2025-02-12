module Pentek_az_en_napom where

fact :: Integral a => a -> a
fact 0 = 1
fact n
    | n < 0 = 0
    | n > 0 = n * fact (n - 1)
    | otherwise = 42

null' :: [a] -> Bool
null' [] = True
null' _ = False

head' :: [a] -> a
head' (x:_) = x

--Potenciális ZH kérdés!!!
--Parciális függvény: Nincs minden létező esteben definiálva (nem a teljes értékkészlet van definiálva)
--Ilyen például a head' mert üres listára nem ad vissza eredményt

tail' :: [a] -> [a]
tail' (_:xs) = xs

singleton :: [a] -> Bool
--Pontosan 1 elem:
singleton [_] = True
singleton _ = False
--Pontosan 3 elem:
--singleton [a,b,c]
--Legalább 3 elem:
--singleton (a:b:c:_)

length' :: [a] -> Int -- > Rekurziót alkalmazunk
length' [] = 0
length' (x:xs) = 1 + length' xs -- > Minden rekurzív hivatkozásnál levesz egy elemet majd újra meghívja a függvényt
-- 1+1+1..+1+0