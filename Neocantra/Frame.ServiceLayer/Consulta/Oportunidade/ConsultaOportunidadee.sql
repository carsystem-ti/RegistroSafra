WITH tableTemp as (	
SELECT TOP 20
	T0."OpprId"
	, T1."CardName"
FROM 
	"{0}".OOPR T0  LEFT JOIN 
	"{0}".OCRD T1 ON T0."CardCode" = T1."CardCode"
WHERE 
	    (UPPER('{1}') IN ('', UPPER(T1."CardCode")) OR UPPER(T1."CardCode") LIKE UPPER('%{1}%')) 
	AND (UPPER('{2}') IN ('', UPPER(T1."CardName")) OR UPPER(T1."CardName") LIKE UPPER('%{2}%'))
	AND ('{3}' IN ('', T0."OpprId") OR T0."OpprId" = '{3}')
ORDER BY 
	T0."OpprId" DESC
)
SELECT 
	 *
	,(SELECT COUNT(1) FROM tableTemp T0) AS "COUNT"
FROM 
	tableTemp T0 