WITH tableTemp as (	
SELECT 
	T0."CloPrcnt"
FROM 
	"{0}".OOST T0
WHERE 
	 T0."Num" = {1}
)
SELECT 
	 *
	,(SELECT COUNT(1) FROM tableTemp T0) AS "COUNT"
FROM 
	tableTemp T0 