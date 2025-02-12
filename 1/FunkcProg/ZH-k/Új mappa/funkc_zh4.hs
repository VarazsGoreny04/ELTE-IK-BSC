module Zárthelyi4 where

--Parciális alkalmazás: A függvényt úgy alkalmazzuk, hogy nem adjuk meg az összes paraméterét
--Pl.:
--add :: Int -> Int -> Int
--add a b = a + b
--addOne = add 1


--upperCharToLower :: String -> String
--upperCharToLower x = filter ['A'..'Z']) x
--    where s y =  filter ['A'..'Z']

swapIfCond :: (a -> Bool) -> [(a,a)] -> [(a,a)]
swapIfCond f x = map (swap f) x

swap :: (a -> Bool) -> (a,a) -> (a,a)
swap f (x,y)
    | f x = (y,x)
    | otherwise = (x,y)

findIndices :: (a -> Bool) -> [a] -> [Int]
findIndices f xs = map fst (filter (f . snd) (zip [0..] xs))