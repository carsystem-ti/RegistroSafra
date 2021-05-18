﻿WITH tableTemp as (	
SELECT 
	T0."Code"
	, T0."Name" 
FROM 
	"{0}".OCST T0
GROUP BY
	T0."Code"
	, T0."Name" 
)
SELECT 
	 *
	,(SELECT COUNT(1) FROM tableTemp T0) AS "COUNT"
FROM 
	tableTemp T0 