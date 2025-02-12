id' :: a  -> a
id' x = x

firstParam :: a -> b -> a
firstParam x y = x

isEven :: Integral a => a -> Bool
isEven n = n `mod` 2 == 0

double :: Num a => a -> a
double x = x + x

isZero :: Int -> Bool
isZero 0 = True
isZero _ = False

oneDigitPrime :: Int -> Bool
oneDigitPrime 2 = True
oneDigitPrime 3 = True
oneDigitPrime 5 = True
oneDigitPrime 7 = True
oneDigitPrime _ = False

and' :: Bool -> Bool -> Bool
--and' False True = False
--and' True False = False
--and' True True = True
--and' False False = True
and' True True = True
and' _ _ = False


