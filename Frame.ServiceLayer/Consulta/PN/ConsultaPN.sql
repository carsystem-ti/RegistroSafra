WITH tableTemp as (	
SELECT TOP 20
	T0."CardCode" 
FROM 
	"{0}".OCRD T0  INNER JOIN 
	"{0}".CRD7 T1 ON T0."CardCode" = T1."CardCode" 
WHERE 
	    (UPPER('{1}') IN ('', UPPER(T0."CardCode")) OR UPPER(T0."CardCode") LIKE UPPER('%{1}%')) 
	AND (UPPER('{2}') IN ('', UPPER(T0."CardName")) OR UPPER(T0."CardName") LIKE UPPER('%{2}%'))
	AND (UPPER('{3}') IN ('', UPPER(T1."TaxId0")) OR UPPER(T1."TaxId0") LIKE UPPER('%{3}%'))
	AND (UPPER('{4}') IN ('', UPPER(T1."TaxId4")) OR UPPER(T1."TaxId4") LIKE UPPER('%{4}%'))
	AND  T0."CardType" = 'C'
GROUP BY
	T0."CardCode" 
ORDER BY
	T0."CardCode" DESC
)
SELECT 
	 *
	,(SELECT COUNT(1) FROM tableTemp T0) AS "COUNT"
FROM 
	tableTemp T0 