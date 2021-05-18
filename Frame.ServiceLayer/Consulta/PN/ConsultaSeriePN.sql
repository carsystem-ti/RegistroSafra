WITH tableTemp as (	
SELECT 
	T0."Series"
	, T0."SeriesName" 
FROM 
	"{0}".NNM1 T0 
WHERE 
	T0."ObjectCode" = '2'
	AND  T0."DocSubType" = '{1}'
)
SELECT 
	 *
	,(SELECT COUNT(1) FROM tableTemp T0) AS "COUNT"
FROM 
	tableTemp T0 