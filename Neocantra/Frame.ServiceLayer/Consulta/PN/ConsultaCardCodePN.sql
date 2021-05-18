SELECT 
	T0."BeginStr" || RIGHT(CONCAT('000000000000000', IFNULL(CAST(T0."NextNumber"  AS VARCHAR(15))  ,'')), T0."NumSize") AS "CardCode"
FROM 
	"{0}".NNM1 T0 
WHERE 
	T0."ObjectCode" = '2'
	AND  T0."DocSubType" = '{1}'
	AND  T0."Series" = {2}