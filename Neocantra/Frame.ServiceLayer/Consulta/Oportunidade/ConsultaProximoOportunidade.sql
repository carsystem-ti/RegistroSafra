SELECT TOP 1 
	T0."OpprId"
	, T1."CardName"
FROM 
	"{0}".OOPR T0  LEFT JOIN 
	"{0}".OCRD T1 ON T0."CardCode" = T1."CardCode"
WHERE 
	T0."OpprId" > '{1}' 
ORDER BY 
	T0."OpprId"