WITH tableTemp as (	
SELECT 
	T0."ID"
	, T0."Usage"
FROM 
	"{0}".OUSG  T0 
)
SELECT 
	 *
	,(SELECT COUNT(1) FROM tableTemp T0) AS "COUNT"
FROM 
	tableTemp T0 