module Homework1 where

    greater :: Int -> Int -> Bool
    greater x y = x > y

    rectPerimeter :: Int -> Int -> Int
    rectPerimeter q r = (q + r) * 2

    isPythagoreanTriple :: Int -> Int -> Int -> Bool
    isPythagoreanTriple a b c = a^2 + b^2 == c^2 || a^2 + c^2 == b^2 || b^2 + c^2 == a^2