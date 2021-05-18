WITH tableTemp as (	
SELECT 
	T0."CardName"																			AS "NomeCliente"
	, T1."InstlmntID"																		AS "Parcela"
	--, T1."InsTotal"																		AS "ValorParcela"
	--, T2."SumApplied"																		AS "ValorParcela"
	, CASE WHEN IFNULL(T2."SumApplied",0) = 0 THEN T1."InsTotal" ELSE T2."SumApplied" END	AS "ValorParcela"
	, T0."Serial"																			AS "NumeroNota"
	, IFNULL(TO_NVARCHAR(T1."DueDate", 'dd/MM/yyyy'),'')									AS "DataVencimento"
	, IFNULL(TO_NVARCHAR(T3."DocDate", 'dd/MM/yyyy'),'')									AS "DataPagamento"
	,TT1."Project"																			AS "Projeto"
	,CASE WHEN IFNULL(T3."DocDate",'') <> '' THEN 'Recebido' ELSE 'Receber' END				AS "Status"

FROM 
	"{0}".OINV T0 INNER JOIN 
	"{0}".INV1 TT1 ON T0."DocEntry" = TT1."DocEntry" AND TT1."LineNum" = 0 LEFT JOIN 
	"{0}".INV6 T1 ON T0."DocEntry" = T1."DocEntry" LEFT JOIN 
	"{0}".RCT2 T2 ON T1."DocEntry" = T2."DocEntry" AND T1."InstlmntID" =  T2."InstId" LEFT JOIN 
	"{0}".ORCT T3 ON T2."DocNum" = T3."DocEntry" AND T3."Canceled" = 'N'

WHERE 
	T0."CANCELED" = 'N'	
	AND (UPPER('{1}') IN ('', UPPER(T0."CardName")) OR UPPER(T0."CardName") LIKE UPPER('%{1}%')) 

	AND ('{2}' IN ('', T1."DueDate") OR T1."DueDate" >= '{2}') 
	AND ('{3}' IN ('', T1."DueDate") OR T1."DueDate" <= '{3}') 	
	
	AND ('{4}' IN ('', T3."DocDate") OR T3."DocDate" >= '{4}') 
	AND ('{5}' IN ('', T3."DocDate") OR T3."DocDate" <= '{5}') 
	
	AND ('{6}' IN ('', TT1."Project") OR TT1."Project" = '{6}') 
	
	AND CASE WHEN '{7}' = 'Todos' THEN 'Todos' ELSE CASE WHEN IFNULL(T3."DocDate",'') <> '' THEN 'Recebido' ELSE 'Receber' END END = '{7}'
	
ORDER BY 
	T1."DueDate"
)
SELECT 
	 *
	,(SELECT COUNT(1) FROM tableTemp T0) AS "COUNT"
FROM 
	tableTemp T0 