SELECT 
	T0."ItmsGrpCod"
FROM 
	"{0}".OITM T0 
WHERE 
	(T0."ItmsGrpCod" = 105 OR  T0."ItmsGrpCod" = '107') 
	AND  T0."ItemCode" = '{1}'