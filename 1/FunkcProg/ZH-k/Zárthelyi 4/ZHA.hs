module ZHA where

--Elmélet1: Magasabb rendűnek nevezzük azt a függvényt ami paraméterként függvényt vár
--Elmélet2: Nem, mert nem vár további függvényt paraméterül (Num b => [b] -> [b])

doubleTheEven :: Integral a => [a] -> [a]
doubleTheEven = selectiveApply (*2) even

selectiveApply :: (a -> a) -> (a -> Bool) -> [a] -> [a]
selectiveApply f b x = map f (filter b x)

findIndices :: (a -> Bool) -> [a] -> [Int]
findIndices b x = map fst (filter (b . snd) (zip [0..] x))

findIndices' :: (a -> Bool) -> [a] -> [Int]
findIndices' b x = [e | (e,k) <- zip [0..] x, b k]

--findIndices'' :: (a -> Bool) -> [a] -> [Int]

{-
Elmélet++:

Magasabb rendű függvény: Függvényt vár paramétereként, vagy függvényt ad vissza (ilyen a (.) operátor is)
Pro tipp: Ha beírod ezt, :t <függvény neve>, és van benne zárójelben kettő vagy több paraméter, akkor magasabb rendű

Szeletek: Operátorokból képzett függvények
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