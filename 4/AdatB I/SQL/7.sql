SELECT * FROM dolgozo2;
SELECT * FROM osztaly2;
SELECT * FROM fiz_kategoria;

-- 1. feladat: Növeljük meg mindenkinek a jutalékát a maximális jutalékkal!
UPDATE dolgozo2
SET jutalek = NVL(jutalek, 0) + (SELECT MAX(jutalek) FROM dolgozo2);
COMMIT;
ROLLBACK;

-- 2. feladat: Növeljük meg azoknak a dolgozóknak a fizetését a minimális fizetéssel, akiknek van beosztottja!
UPDATE dolgozo2
SET jutalek = NVL(jutalek, 0) + (SELECT MIN(jutalek) FROM dolgozo2)
WHERE dkod IN (SELECT DISTINCT fonoke FROM dolgozo2);

UPDATE dolgozo2 fonok
SET jutalek = NVL(jutalek, 0) + (SELECT MIN(jutalek) FROM dolgozo2)
WHERE (SELECT COUNT(*) FROM dolgozo2 beosztott WHERE beosztott.fonoke = fonok.dkod) > 0;

COMMIT;
ROLLBACK;

-- Vingardium leviosa!
CREATE OR REPLACE VIEW oszt10 AS
SELECT dnev, fizetes
FROM dolgozo
WHERE oazon = 10;

SELECT * FROM dolgozo2;
SELECT * FROM oszt10;
DESCRIBE oszt10;

DECLARE
    message VARCHAR(20) := 'Hello World!';
BEGIN -- In di... in di bigininging!
    DBMS_OUTPUT.PUT_LINE(message);
    DBMS_OUTPUT.PUT_LINE('Hello World!');
END;
/

-- Típusok
DECLARE
    num1 INTEGER;
    num2 REAL;
    num3 DOUBLE PRECISION;
    num4 NUMERIC;
    
    char1 CHAR(10);
    char2 VARCHAR(20);
    char3 LONG;
    
    bool BOOLEAN;
    datum DATE;
BEGIN
    NULL;
END;
/

-- Deklaráció
DECLARE
    a INTEGER := 10;
    b CONSTANT INTEGER := 20;
    c INTEGER;
BEGIN
    c := a * b;
    DBMS_OUTPUT.PUT_LINE('Value of c: ' || c);
END;
/

-- SQL lekérdezések tárolása változókban
DECLARE
    myKod dolgozo.dkod%type := 7839;
    myDnev dolgozo.dnev%type;
    myFizetes dolgozo.fizetes%type;
BEGIN
    SELECT dnev, fizetes
    INTO myDnev, myFizetes
    FROM dolgozo
    WHERE dkod = myKod;
    
    DBMS_OUTPUT.PUT_LINE('Név: ' || myDnev || ' - Fizetés: ' || myFizetes);
END;
/

DECLARE
    myKod dolgozo.dkod%type := 7839;
    myDolgozo dolgozo%rowtype;
BEGIN
    SELECT *
    INTO myDolgozo
    FROM dolgozo
    WHERE dkod = myKod;
    
    DBMS_OUTPUT.PUT_LINE('Név: ' || myDolgozo.dnev || ' - Fizetés: ' || myDolgozo.fizetes);
END;
/

-- Vezérési szerkezetek

DECLARE
BEGIN
    FOR i IN 0..10 LOOP
        IF i < 5 THEN
            DBMS_OUTPUT.PUT_LINE('Less than 5!');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Greater than 5!');
        END IF;
    END LOOP;
END;
/

DECLARE
    i INTEGER := 0;
BEGIN
    WHILE i <= 10 LOOP
        IF i < 5 THEN
            DBMS_OUTPUT.PUT_LINE('Less than 5!');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Greater than 5!');
        END IF;
        i := i + 1;
    END LOOP;
END;
/