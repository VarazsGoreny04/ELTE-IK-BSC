-- Adott egy számpárokat tartalmazó lista. Szűrjük ki azokat az elemeket, ahol a pár első elemének négyzetére igaz a paraméterként kapott predikátum. 

f :: Num a => (a -> Bool) -> [(a,a)] -> [(a,a)]
f b = filter (b . (^2) . fst)