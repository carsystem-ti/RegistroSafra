WITH tableTemp as (	
SELECT 
	T0."USERID"
	, T0."U_NAME"
FROM 
	"{0}".OUSR T0
WHERE 
	T0."Locked" = 'N'
GROUP BY
	T0."USERID"
	, T0."U_NAME" 
)
SELECT 
	 *
	,(SELECT COUNT(1) FROM tableTemp T0) AS "COUNT"
FROM 
	tableTemp T0 