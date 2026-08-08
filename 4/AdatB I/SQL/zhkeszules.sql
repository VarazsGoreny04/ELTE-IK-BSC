SELECT * FROM dolgozo2;
SELECT * FROM osztaly2;
SELECT * FROM fiz_kategoria;

-- FORDICCSUNK
CREATE OR REPLACE FUNCTION compare (s1 VARCHAR2, s2 VARCHAR2) RETURN BOOLEAN AS
    n1 INTEGER := LENGTH(s1);
    n2 INTEGER := LENGTH(s2);
    CURSOR k IS SELECT * FROM dolgozo2;
    sor dolgozo2%rowtype;
BEGIN
    IF n1 != n2 THEN
        RETURN FALSE;
    END IF;

    FOR i IN 1..n1 LOOP
        IF SUBSTR(s1, i, 1) != SUBSTR(s2, n2 + i - 1, 1) THEN
            RETURN FALSE;
        END IF;
    END LOOP;
    
    FOR sor IN k LOOP
        IF sor.dnev = s1 THEN
            RETURN TRUE;
        END IF;
    END LOOP;
    
    RETURN FALSE;
END;
/

DECLARE
   string1 VARCHAR2(100) := 'SMITH';
   string2 VARCHAR2(100) := 'HTIMS';
   result BOOLEAN;
BEGIN
   result := compare(string1, string2);
   IF result THEN
      DBMS_OUTPUT.PUT_LINE('Found something');
   ELSE
      DBMS_OUTPUT.PUT_LINE('Sad story');
   END IF;
END;
/

-- UCCSOKETTO
CREATE OR REPLACE PROCEDURE rise (s1 IN CHAR, s2 IN CHAR) AS
    strEnd VARCHAR2(2) := CONCAT(s1, s2);
    CURSOR ok IS SELECT oazon FROM osztaly2 WHERE SUBSTR(onev, LENGTH(onev) - 1, 2) = strEnd;
    sor dolgozo%rowtype;
BEGIN
    FOR sor IN k LOOP
        UPDATE dolgozo2
        SET jutalek = NVL(jutalek, 0) + (SELECT MIN(jutalek) FROM dolgozo2)
        WHERE dkod IN (SELECT DISTINCT fonoke FROM dolgozo2);
    END LOOP;
END;
/