WITH tableTemp as (	
SELECT 
	T0."PrjCode"
	, T0."PrjName"
FROM 
	"{0}".OPRJ T0
WHERE 
	T0."Active" = 'Y'
GROUP BY
	T0."PrjCode"
	, T0."PrjName"
)
SELECT 
	 *
	,(SELECT COUNT(1) FROM tableTemp T0) AS "COUNT"
FROM 
	tableTemp T0 