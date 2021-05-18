WITH tableTemp as (	
SELECT TOP 20
	T0."ClgCode"
	, IFNULL(T1."CardName",'')
FROM 
	"{0}".OCLG T0  LEFT JOIN 
	"{0}".OCRD T1 ON T0."CardCode" = T1."CardCode"
WHERE 
	    (UPPER('{1}') IN ('', UPPER(T1."CardCode")) OR UPPER(T1."CardCode") LIKE UPPER('%{1}%')) 
	AND (UPPER('{2}') IN ('', UPPER(T1."CardName")) OR UPPER(T1."CardName") LIKE UPPER('%{2}%'))
	AND ('{3}' IN ('', T0."ClgCode") OR T0."ClgCode" = '{3}')
ORDER BY 
	T0."ClgCode" DESC
)
SELECT 
	 *
	,(SELECT COUNT(1) FROM tableTemp T0) AS "COUNT"
FROM 
	tableTemp T0 