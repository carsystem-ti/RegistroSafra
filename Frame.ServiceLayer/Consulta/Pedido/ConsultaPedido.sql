WITH tableTemp as (	
SELECT TOP 20
	T0."DocEntry"
FROM 
	"{0}".ORDR T0  
WHERE 
	    (UPPER('{1}') IN ('', UPPER(T0."CardCode")) OR UPPER(T0."CardCode") LIKE UPPER('%{1}%')) 
	AND (UPPER('{2}') IN ('', UPPER(T0."CardName")) OR UPPER(T0."CardName") LIKE UPPER('%{2}%'))
	AND ('{3}' IN ('', T0."DocNum") OR T0."DocNum" = '{3}')
ORDER BY 
	T0."DocEntry" DESC
)
SELECT 
	 *
	,(SELECT COUNT(1) FROM tableTemp T0) AS "COUNT"
FROM 
	tableTemp T0 