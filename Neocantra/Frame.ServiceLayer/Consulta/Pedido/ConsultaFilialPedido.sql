WITH tableTemp as (	
SELECT 
	T0."BPLId"
	, T0."BPLName" 
FROM 
	"{0}".OBPL T0
WHERE 
	T0."Disabled" = 'N'

GROUP BY
	T0."BPLId"
	, T0."BPLName" 
)
SELECT 
	 *
	,(SELECT COUNT(1) FROM tableTemp T0) AS "COUNT"
FROM 
	tableTemp T0 