module PvZ where
import Data.Maybe ( isNothing, fromJust )

type Coordinate = (Int,Int)
type Sun = Int

data Plant = Peashooter Int | Sunflower Int | Walnut Int | CherryBomb Int
    deriving (Show,Eq)
data Zombie = Basic Int Int | Conehead Int Int | Buckethead Int Int | Vaulting Int Int
    deriving (Show,Eq)
data GameModel = GameModel Sun [(Coordinate,Plant)] [(Coordinate,Zombie)]
    deriving (Show,Eq)

defaultPeashooter :: Plant
defaultPeashooter = Peashooter 3
defaultSunflower :: Plant
defaultSunflower = Sunflower 2
defaultWalnut :: Plant
defaultWalnut = Walnut 15
defaultCherryBomb :: Plant
defaultCherryBomb = CherryBomb 2

isPeashooter :: Plant -> Bool
isPeashooter (Peashooter _) = True
isPeashooter _ = False
isCherryBomb :: Plant -> Bool
isCherryBomb (CherryBomb _) = True
isCherryBomb _ = False
isSunflower :: Plant -> Bool
isSunflower (Sunflower _) = True
isSunflower _ = False

basic :: Zombie
basic = Basic 5 1
coneHead :: Zombie
coneHead = Conehead 10 1
bucketHead :: Zombie
bucketHead = Buckethead 20 1
vaulting :: Zombie
vaulting = Vaulting 7 2

tryPurchase :: GameModel -> Coordinate -> Plant -> Maybe GameModel
tryPurchase (GameModel s cp cz) (x,y) p
    | isNothing (lookup (x,y) cp) && x > -1 && x < 5 && y > -1 && y < 12 && (s > 149 || (p == defaultSunflower || p == defaultWalnut) && s > 49 ||
        p == defaultPeashooter && s > 99) = Just (GameModel (s - if isPeashooter p then 100 else if isCherryBomb p then 150 else 50) (((x,y),p):cp) cz)
    | otherwise = Nothing

placeZombieInLane :: GameModel -> Zombie -> Int -> Maybe GameModel
placeZombieInLane (GameModel s cp cz) z x
    | isNothing (lookup (x,11) cz) && x > -1 && x < 5 = Just (GameModel s cp (((x,11),z):cz))
    | otherwise = Nothing

performZombieActions :: GameModel -> Maybe GameModel
performZombieActions (GameModel s cps czs)
    | any ((< 0) . snd . fst) positions = Nothing
    | otherwise = Just (GameModel s (map (\(c,p) -> (c,attackPlant p $ sum [1 | x <- [co | (co,z) <- czs, not $ canVault z], x == c])) cps) positions)
    where
    positions = map (\(c,z) -> if canVault z then if cantMove c then (m c 1,vault z) else if cantMove $ m c 1 then (m c 2,vault z) else (m c 2,z)
       else if cantMove c then (c,z) else (m c 1,z)) czs
    canVault (Vaulting _ 2) = True
    canVault _ = False
    vault (Vaulting hp _) = Vaulting hp 1
    attackPlant (Peashooter x) d = Peashooter (x - d)
    attackPlant (Sunflower x) d = Sunflower  (x - d)
    attackPlant (Walnut x) d = Walnut  (x - d)
    attackPlant (CherryBomb x) d = CherryBomb  (x - d)
    cantMove c = c `elem` map fst cps
    m (x,y) n = (x,y - n)

cleanBoard :: GameModel -> GameModel
cleanBoard (GameModel s cp cz) = GameModel s (filter (cleanPlant . snd) cp) (filter (cleanZombie . snd) cz)
    where
    cleanPlant (Peashooter x) = x > 0
    cleanPlant (Sunflower x) = x > 0
    cleanPlant (Walnut x) = x > 0
    cleanPlant (CherryBomb x) = x > 0
    cleanZombie (Basic x _) = x > 0
    cleanZombie (Conehead x _) = x > 0
    cleanZombie (Buckethead x _) = x > 0
    cleanZombie (Vaulting x _) = x > 0

performPlantActions :: GameModel -> GameModel
performPlantActions (GameModel s cp cz) = GameModel (s + 25 * sum [1 | p <- cp, isSunflower $ snd p])
    (map (\(c,p) -> if isCherryBomb p then (c,CherryBomb 0) else (c,p)) cp)  (map (hit cp) cz)
    where
    hit [] z = z
    hit (((xp,yp),p):t) ((xz,yz),z)
        | isPeashooter p && xp == xz && not (any (\((x,y),_) -> x == xz && y < yz) cz) = hit t ((xz,yz), attackZombie z (subtract 1))
        | isCherryBomb p && xp - xz > -2 && xp - xz < 2 && yp - yz > -2 && yp - yz < 2 = hit t ((xz,yz), attackZombie z (const 0))
        | otherwise = hit t ((xz,yz), z)
    attackZombie (Basic hp ms) d = Basic (d hp) ms
    attackZombie (Conehead hp ms) d = Conehead (d hp) ms
    attackZombie (Buckethead hp ms) d = Buckethead (d hp) ms
    attackZombie (Vaulting hp ms) d = Vaulting (d hp) ms

defendsAgainst :: GameModel -> [[(Int,Zombie)]] -> Bool
defendsAgainst = defendsAgainstI id

defendsAgainstI :: (GameModel -> GameModel) -> GameModel -> [[(Int, Zombie)]] -> Bool
defendsAgainstI _ (GameModel _ _ []) [] = True
defendsAgainstI f gm ws
    | isNothing $ showtime gm =  False
    | null ws = defendsAgainstI f (addSuns $ cleanBoard $ fromJust $ showtime gm) []
    | otherwise = defendsAgainstI f (addSuns $ cleanBoard $ addWave (fromJust $ showtime gm) (head ws)) (tail ws)
    where
    showtime = performZombieActions . cleanBoard . performPlantActions . f
    addSuns (GameModel s cp cz) = GameModel (s + 25) cp cz
    addWave tgm [] = tgm
    addWave tgm ((c,z):zs) = addWave (fromJust $ placeZombieInLane tgm z c) zs