SELECT 
	T0."ClgCode"
	, IFNULL(T1."CardName",'')
FROM 
	"{0}".OCLG T0  LEFT JOIN 
	"{0}".OCRD T1 ON T0."CardCode" = T1."CardCode"
WHERE
	T0."ClgCode" = (SELECT MIN(TT0."ClgCode")  FROM "{0}".OCLG TT0) 