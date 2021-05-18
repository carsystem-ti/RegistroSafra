WITH tableTemp as (	
SELECT 
	T0."empID"
	,T0."lastName" || ', '||  T0."firstName"
FROM 
	"{0}".OHEM T0
WHERE 
	T0."Active" = 'Y'
)
SELECT 
	 *
	,(SELECT COUNT(1) FROM tableTemp T0) AS "COUNT"
FROM 
	tableTemp T0 