module Gyak where

unperm :: Eq a => [(a,b)] -> [a] -> [b]
unperm ts xs = [y | (x,y) <- ts, x `elem` xs]

rwx :: (r -> x) -> (r -> w) -> (r -> (w,x))
rwx f g r = (g r, f r)

type Name = [Char]
type Watered = Int

data Flower = Petunia Name Watered | Rose Name Watered Bool
toData :: Flower -> (Name, Watered, String, Bool)
toData (Rose a b c) = (a, b, "rose", c)
toData (Petunia a b) = (a, b, "petunia", False)

greet :: Flower -> String
greet = f . toData where
    f (a, b, c ,d) = "My name is " ++ a ++ ", I'm a " ++ show b ++ "% watered " ++ c ++if d then " with spikes." else " plant."
{-greet x
    | b = "My name is " ++ n ++ ", I'm a " ++ show w ++ "% watered " ++ d ++ " with spikes."
    | otherwise = "My name is " ++ n ++ ", I'm a " ++ show w ++ "% watered "++ d ++ " plant." where
        d = case x of Rose {} -> "rose"; _ -> "petunia"
        b = case x of Rose _ _ f -> f; _ -> False
        n = case x of Rose d _ _ -> d; Petunia c _ -> c
        w = case x of Rose _ d _ -> d; Petunia _ c -> c
-}


-- A monád egy monoid az endofunktorok területén
-- Kívül kicsi és oszthatatlan, belül viszont részekre bontható