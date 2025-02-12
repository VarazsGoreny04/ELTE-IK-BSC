module ZH3A where

data Peksuti = Kifli String | Zsemle String Bool | KakaosCsiga Int

f :: [Peksuti] -> Int
f (_:_:Zsemle _ True:_)             = 0
f (_:_:Zsemle [] _:[])              = 1
f (_:Kifli [_]:Zsemle [] _:[xs])    = 2
f (_:Kifli _:Zsemle _ _:xs)         = 3
--elméleti: [(Kifli "kifli"),(Kifli "k"),(Zsemle "" False),(Kifli "alma")]