SELECT TOP 1 
	T0."DocEntry" 
FROM 
	"{0}".ORDR T0 
WHERE 
	T0."DocEntry" > '{1}' 
ORDER BY 
	T0."DocEntry"