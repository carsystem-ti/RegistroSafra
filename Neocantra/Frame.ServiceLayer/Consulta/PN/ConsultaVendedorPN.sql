﻿WITH tableTemp as (	
SELECT 
	T0."SlpCode"
	, T0."SlpName"
FROM 
	"{0}".OSLP T0
WHERE 
	T0."Active" = 'Y'
GROUP BY
	T0."SlpCode"
	, T0."SlpName"
)
SELECT 
	 *
	,(SELECT COUNT(1) FROM tableTemp T0) AS "COUNT"
FROM 
	tableTemp T0 