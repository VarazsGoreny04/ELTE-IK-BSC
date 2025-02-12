module Házifeladat where

onAxis :: (Int, Int) -> Bool
onAxis (0, 0) = True
onAxis (0, y) = True
onAxis (x, 0) = True
onAxis _ = False

shift :: Integral a => (a, a) -> a -> (a, a)
shift (x, y) z = (((x * 60 + y + z) `mod` 1440)`div` 60, (x * 60 + y + z) `mod` 60)

areAmicableNumbers :: Int -> Int-> Bool
areAmicableNumbers a b = sum [x | x <- [(a-1),(a-2)..1], a `mod` x == 0] == b && sum [x | x <- [(b-1),(b-2)..1], b `mod` x == 0] == a