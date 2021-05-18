WITH tableTemp as (	
SELECT 
	T0."AbsId"
	, T0."Name" 
FROM 
	"{0}".OCNT T0 
WHERE 
	T0."State" = '{1}'
GROUP BY
	T0."AbsId"
	, T0."Name" 
)
SELECT 
	 *
	,(SELECT COUNT(1) FROM tableTemp T0) AS "COUNT"
FROM 
	tableTemp T0 