module XY where

    toInfinityAndBeyond :: [a] -> [a]
    toInfinityAndBeyond x = x ++ reverse x ++ toInfinityAndBeyond x