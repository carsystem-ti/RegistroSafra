SELECT TOP 1 
	T0."CardCode" 
FROM 
	"{0}".OCRD T0 
WHERE 
	T0."CardCode" > '{1}' 
	AND	T0."CardType" = 'C'
ORDER BY 
	T0."CardCode"