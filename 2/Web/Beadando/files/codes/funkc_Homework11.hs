module Homework11 where
import Data.Char

testFile0 :: File 
testFile0 = ["asd  qwe", "-- Foo", "", "\thello world "]

type Line = String
type File = [Line]

countWordsInLine :: Line -> Int
countWordsInLine a = length $ words a

countWords :: File -> Int
countWords = foldr ((+) . countWordsInLine) 0

countChars :: File -> Int
countChars xs = sum $ map length xs

capitalizeWordsInLine :: Line -> Line
capitalizeWordsInLine ys = unwords [toUpper x : xs | (x:xs) <- words ys]

isComment :: Line -> Bool
isComment (x:y:xs) = x == '-' && y == '-'
isComment _ = False

dropComments :: File -> File
dropComments = filter (not . isComment)

numberLines :: File -> File
numberLines = zipWith (++) [show x ++ ": " | x <- [1..]]

dropTrailingWhitespaces :: Line -> Line
dropTrailingWhitespaces xs = reverse $ dropWhile isSpace $ reverse xs

replaceTab :: Int -> Char -> [Char]
replaceTab x y
    | y == '\t' = replicate x ' '
    | otherwise = [y]

replaceTabs :: Int -> File -> File
replaceTabs x = map (concatMap $ replaceTab x)