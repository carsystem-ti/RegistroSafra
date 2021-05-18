WITH tableTemp as (	
SELECT TOP 20
	T0."ItemCode"
	,T0."ItemName"
FROM 
	"{0}".OITM T0  
WHERE 
	    (UPPER('{1}') IN ('', UPPER(T0."ItemCode")) OR UPPER(T0."ItemCode") LIKE UPPER('%{1}%')) 
	AND (UPPER('{2}') IN ('', UPPER(T0."ItemName")) OR UPPER(T0."ItemName") LIKE UPPER('%{2}%'))
	AND T0."SellItem" = 'Y'
	AND T0."validFor"  = 'Y'
)
SELECT 
	 *
	,(SELECT COUNT(1) FROM tableTemp T0) AS "COUNT"
FROM 
	tableTemp T0 