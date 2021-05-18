WITH tableTemp as (	
SELECT 
	T0."Num"
	, T0."Descript"
FROM 
	"{0}".OOST T0
WHERE 
	T0."SalesStage" = 'Y'
GROUP BY
	T0."Num"
	, T0."Descript"
)
SELECT 
	 *
	,(SELECT COUNT(1) FROM tableTemp T0) AS "COUNT"
FROM 
	tableTemp T0 