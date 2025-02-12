waterTheFlowers :: Int
waterTheFlowers = ceiling(50 * 0.25 /1.8)

isLeapYear :: Int -> Bool
isLeapYear days = days `mod` 400 == 0 || days `mod` 100 /= 0 && days `mod` 4 == 0

equivalent :: Bool -> Bool -> Bool
equivalent a b = a == b

implies :: Bool -> Bool -> Bool
implies a b = not (a && not b)