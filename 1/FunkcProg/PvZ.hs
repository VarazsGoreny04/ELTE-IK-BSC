module PvZ where
import Data.Char
import Data.Maybe

data Plant = Peashooter Int | Sunflower Int | Walnut Int |  CherryBomb Int
    deriving (Show, Eq)
data Zombie = Basic Int Int | Conehead Int Int | Buckethead Int Int | Vaulting Int Int
    deriving (Show, Eq)

type Coordinate = (Int, Int)
type Sun = Int

data GameModel = GameModel Sun [(Coordinate, Plant)] [(Coordinate, Zombie)]
    deriving (Show, Eq)

defaultPeashooter :: Plant
defaultPeashooter = Peashooter 3

defaultSunflower :: Plant
defaultSunflower = Sunflower 2

defaultWalnut :: Plant
defaultWalnut = Walnut 15

defaultCherryBomb :: Plant
defaultCherryBomb = CherryBomb 2

basic :: Zombie
basic = Basic 5 1

coneHead :: Zombie
coneHead = Conehead 10 1

bucketHead :: Zombie
bucketHead = Buckethead 20 1

vaulting :: Zombie
vaulting = Vaulting 7 2

tryPurchase :: GameModel -> Coordinate -> Plant -> Maybe GameModel
tryPurchase (GameModel _ _ _ ) (r, c) _
    | r < 0 || r > 4 || c < 0 || c > 11 = Nothing
tryPurchase (GameModel x (ps) z ) co p
    | (p == defaultPeashooter) && x >= 100 && (lookup co ps == Nothing)  = Just (GameModel (x-100) (ps ++ [(co, p)]) z)
    | (p == defaultWalnut) && x >= 50 && (lookup co ps == Nothing) = Just (GameModel (x-50) (ps ++ [(co, p)]) z)
    | (p == defaultSunflower) && x >= 50 && (lookup co ps == Nothing) = Just (GameModel (x-50) (ps ++ [(co, p)]) z)
    | (p == defaultCherryBomb) && x >= 150 && (lookup co ps == Nothing) = Just (GameModel (x-150) (ps ++ [(co, p)]) z)
    | otherwise = Nothing

placeZombieInLane :: GameModel -> Zombie -> Int -> Maybe GameModel
placeZombieInLane (GameModel _ _ _ ) _ r
    | r < 0 || r > 4 = Nothing
placeZombieInLane (GameModel x p (zs)) z r
    | (lookup (r, 11) zs) == Nothing = Just (GameModel x p ([((r,11), z)] ++ zs))
    | otherwise = Nothing

eat :: (Coordinate, Plant) -> (Coordinate, Plant)
eat (co, (Peashooter hp)) = (co, (Peashooter (hp-1)))
eat (co, (Sunflower hp)) = (co, (Sunflower (hp-1)))
eat (co, (Walnut hp)) = (co, (Walnut (hp-1)))
eat (co, (CherryBomb hp)) = (co, (CherryBomb (hp-1)))

vaulted :: Zombie -> Zombie
vaulted (Vaulting hp 2) = (Vaulting hp 1)

zombieAction :: [(Coordinate, Plant)] -> (Coordinate, Zombie) -> (Coordinate, Zombie)
zombieAction cps ((x,y), z)
    | z /= vaulting && isJust (lookup (x,y) cps) = ((x, y), z)
    | z /= vaulting = ((x, y-1), z)
    | isJust (lookup (x,y) cps) = ((x, y-1), vaulted z)
    | isJust (lookup (x,y-1) cps) = ((x, y-2), vaulted z)
    | otherwise = ((x, y-2), z)

zombieActions :: [(Coordinate, Zombie)] -> [(Coordinate, Plant)] -> [(Coordinate, Zombie)]
zombieActions czs cps = map (zombieAction cps) czs

plantFeast :: [(Coordinate, Zombie)] -> (Coordinate, Plant) -> (Coordinate, Plant)
plantFeast czs ((x,y),p)
    | elem (x,y) [c | (c,z) <- czs, z /= vaulting] = (eat ((x,y),p))
    | otherwise = ((x,y),p)

performZombieActions :: GameModel -> Maybe GameModel
performZombieActions (GameModel s p z)
    | not $ null (filter (\((x,y),z) -> y < 0) (zombieActions z p))= Nothing
    | otherwise = Just (GameModel s (map (plantFeast z) p) (zombieActions z p))

nullP :: Plant -> Bool
nullP (CherryBomb hp) = greaterThanOne  hp
nullP (Peashooter hp) = greaterThanOne  hp
nullP (Walnut hp) = greaterThanOne  hp
nullP (Sunflower hp) = greaterThanOne  hp

nullZ :: Zombie -> Bool
nullZ (Conehead hp _) = greaterThanOne  hp
nullZ (Vaulting hp _) = greaterThanOne hp
nullZ (Basic hp _) = greaterThanOne  hp
nullZ (Buckethead hp _) = greaterThanOne  hp

greaterThanOne :: Int -> Bool
greaterThanOne x
    | x < 1 = False
    | otherwise = True

cleanBoard :: GameModel -> GameModel
cleanBoard (GameModel s cps czs) = GameModel s [(c,p) | (c,p) <- cps, nullP p] [(c,z) | (c,z) <- czs, nullZ z]
