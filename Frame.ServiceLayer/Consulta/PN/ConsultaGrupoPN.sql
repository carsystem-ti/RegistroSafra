WITH tableTemp as (	
SELECT 
	T0."GroupCode"
	, T0."GroupName"
FROM 
	"{0}".OCRG T0
WHERE 
	T0."GroupType" = '{1}'
GROUP BY
	T0."GroupCode"
	, T0."GroupName"
)
SELECT 
	 *
	,(SELECT COUNT(1) FROM tableTemp T0) AS "COUNT"
FROM 
	tableTemp T0 