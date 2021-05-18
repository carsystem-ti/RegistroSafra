WITH tableTemp as (	
SELECT 
	T0."Code"
	, T0."Name" 
FROM 
	"{0}".OCLO T0
GROUP BY
	T0."Code"
	, T0."Name" 

UNION ALL

SELECT 
	'-1'		AS "Code"
	, 'Nenhum'	AS "Name"
FROM 
	DUMMY

)
SELECT 
	 *
	,(SELECT COUNT(1) FROM tableTemp T0) AS "COUNT"
FROM 
	tableTemp T0 