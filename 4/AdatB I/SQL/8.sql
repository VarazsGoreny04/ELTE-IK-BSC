-- 1. feladat:
CREATE OR REPLACE PROCEDURE hello AS
BEGIN
    dbms_output.put_line('Hello World!');
END;
/

CALL hello();
EXECUTE hello;

BEGIN
    hello;
END;
/

-- 2. feladat:
CREATE OR REPLACE PROCEDURE osszeadas (a IN INTEGER, b IN INTEGER, c OUT INTEGER) AS
BEGIN
    c := a + b;
END;
/

DECLARE
    eredmeny INTEGER;
BEGIN
    osszeadas(1, 2, eredmeny);
    dbms_output.put_line('Osszeadas: ' || eredmeny);
END;
/
   
-- 3. feladat: 
CREATE OR REPLACE PROCEDURE negyzet (a IN OUT INTEGER) AS
BEGIN
    a := a * a;
END;
/

DECLARE
    eredmeny INTEGER;
BEGIN
    eredmeny := 5;
    osszeadas(eredmeny);
    dbms_output.put_line('Negyzet: ' || szam);
END;
/

-- 4. feladat:
CREATE OR REPLACE FUNCTION osszeadas_fv (a IN INTEGER, b IN INTEGER)
    RETURN INTEGER AS
    osszeg INTEGER;
BEGIN
    osszeg := a + b;
    RETURN osszeg;
END;
/
 
SELECT osszeadas_fv(1, 2) FROM dual;
 
DECLARE
    szam INTEGER;
BEGIN
    szam := osszeadas_fv(1, 2);
    dbms_output.put_line('Összeg: ' || szam);
END;
/

-- Kurzorok
-- CURSOR <kurzor_neve> IS SELECT * FROM <táblanév>
-- OPEN <kurzor_neve>
-- FETCH <kurzor_neve> INFO <változó_név>
-- CLOSE <kurzor_neve>
-- EXIT WHEN <kurzor_neve%notfound> LOOP

-- 5. feladat:
CREATE OR REPLACE PROCEDURE kurzorteszt1 AS
    CURSOR k IS SELECT * FROM dolgozo;
    sor dolgozo%rowtype;
BEGIN
    OPEN k;
    LOOP
        FETCH k INTO sor;
        EXIT WHEN k%notfound;
        dbms_output.put_line(sor.dnev);
    END LOOP;
    CLOSE k;
END;
/

EXECUTE kurzorteszt1;

-- 6. feladat:
CREATE OR REPLACE PROCEDURE kurzorteszt2 AS
    CURSOR k IS SELECT * FROM dolgozo;
    sor dolgozo%rowtype;
BEGIN
    FOR sor IN k LOOP
        dbms_output.put_line(sor.dnev);
    END LOOP;
END;
/

EXECUTE kurzorteszt2;

-- 7. feladat:
DROP FUNCTION prime;

CREATE OR REPLACE FUNCTION prime (num INTEGER) RETURN BOOLEAN AS
    i INTEGER;
BEGIN
    i := num / 2;
    WHILE i > 1 LOOP
        IF MOD(num, i) = 0 THEN
            RETURN TRUE;
        END IF;
        i := i - 1;
    END LOOP;
    RETURN FALSE;
END;
/

DECLARE
    num INTEGER;
    b BOOLEAN;
BEGIN
    num := 6;
    b := prime(num);
    IF b THEN
        dbms_output.put_line('Nem prim');
    ELSE
        dbms_output.put_line('Prim');
    END IF;
END;
/

-- 8. feladat:
CREATE OR REPLACE FUNCTION fibonacci (n INTEGER) RETURN INTEGER AS
    e INTEGER := 1;
    ee INTEGER := 0;
    m INTEGER;
    i INTEGER := 0;
BEGIN
    IF n > 0 AND n < 3 THEN
        RETURN 1;
    ELSE
        WHILE i < n LOOP
            m := e + ee;
            e := ee;
            ee := m;
            i := i + 1;
        END LOOP;
    END IF;
    RETURN ee;
END;
/

DECLARE
    num INTEGER;
    r INTEGER;
BEGIN
    num := 10;
    r := fibonacci(num);
    dbms_output.put_line(r);
END;
/

SELECT fibonacci(10) FROM dual;

-- 9. feladat:
CREATE OR REPLACE FUNCTION sumIfEven (n INTEGER) RETURN INTEGER AS
    r INTEGER := 0;
BEGIN
    FOR i IN 1..n LOOP
        IF i MOD 2 = 0 THEN
            r := r + i;
        END IF;
    END LOOP;
    RETURN r;
END;
/

SELECT sumIfEven(9) FROM dual;