﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Frame.ServiceLayer.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Frame.ServiceLayer.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT TOP 1  
        ///	T0.&quot;ClgCode&quot;
        ///	, T1.&quot;CardName&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OCLG T0  LEFT JOIN 
        ///	&quot;{0}&quot;.OCRD T1 ON T0.&quot;CardCode&quot; = T1.&quot;CardCode&quot;
        ///WHERE 
        ///	T0.&quot;ClgCode&quot; &lt; &apos;{1}&apos;  
        ///ORDER BY 
        ///	T0.&quot;ClgCode&quot; DESC.
        /// </summary>
        internal static string ConsultaAnteriorAtividade {
            get {
                return ResourceManager.GetString("ConsultaAnteriorAtividade", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT TOP 1  
        ///	T0.&quot;OpprId&quot;
        ///	, T1.&quot;CardName&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OOPR T0  LEFT JOIN 
        ///	&quot;{0}&quot;.OCRD T1 ON T0.&quot;CardCode&quot; = T1.&quot;CardCode&quot;
        ///WHERE 
        ///	T0.&quot;OpprId&quot; &lt; &apos;{1}&apos;  
        ///ORDER BY 
        ///	T0.&quot;OpprId&quot; DESC.
        /// </summary>
        internal static string ConsultaAnteriorOportunidade {
            get {
                return ResourceManager.GetString("ConsultaAnteriorOportunidade", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT TOP 1  
        ///	T0.&quot;DocEntry&quot; 
        ///FROM 
        ///	&quot;{0}&quot;.ORDR T0 
        ///WHERE 
        ///	T0.&quot;DocEntry&quot; &lt; &apos;{1}&apos;  
        ///ORDER BY 
        ///	T0.&quot;DocEntry&quot; DESC.
        /// </summary>
        internal static string ConsultaAnteriorPedido {
            get {
                return ResourceManager.GetString("ConsultaAnteriorPedido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT TOP 1  
        ///	T0.&quot;CardCode&quot; 
        ///FROM 
        ///	&quot;{0}&quot;.OCRD T0 
        ///WHERE 
        ///	T0.&quot;CardCode&quot; &lt; &apos;{1}&apos;  
        ///	AND	T0.&quot;CardType&quot; = &apos;C&apos;
        ///ORDER BY 
        ///	T0.&quot;CardCode&quot; DESC.
        /// </summary>
        internal static string ConsultaAnteriorPN {
            get {
                return ResourceManager.GetString("ConsultaAnteriorPN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;Code&quot;
        ///	, T0.&quot;Name&quot; 
        ///FROM 
        ///	&quot;{0}&quot;.OCLS T0
        ///WHERE 
        ///	T0.&quot;Active&quot; = &apos;Y&apos; 
        ///	AND  T0.&quot;Type&quot; = &apos;{1}&apos; 
        ///GROUP BY
        ///	T0.&quot;Code&quot;
        ///	, T0.&quot;Name&quot; 
        ///
        ///UNION ALL
        ///
        ///SELECT 
        ///	&apos;-1&apos;		AS &quot;Code&quot;
        ///	, &apos;Nenhum&apos;	AS &quot;Name&quot;
        ///FROM 
        ///	DUMMY
        ///
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaAssuntoAtividade {
            get {
                return ResourceManager.GetString("ConsultaAssuntoAtividade", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT TOP 20
        ///	T0.&quot;ClgCode&quot;
        ///	, T1.&quot;CardName&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OCLG T0  LEFT JOIN 
        ///	&quot;{0}&quot;.OCRD T1 ON T0.&quot;CardCode&quot; = T1.&quot;CardCode&quot;
        ///WHERE 
        ///	    (UPPER(&apos;{1}&apos;) IN (&apos;&apos;, UPPER(T1.&quot;CardCode&quot;)) OR UPPER(T1.&quot;CardCode&quot;) LIKE UPPER(&apos;%{1}%&apos;)) 
        ///	AND (UPPER(&apos;{2}&apos;) IN (&apos;&apos;, UPPER(T1.&quot;CardName&quot;)) OR UPPER(T1.&quot;CardName&quot;) LIKE UPPER(&apos;%{2}%&apos;))
        ///	AND (&apos;{3}&apos; IN (&apos;&apos;, T0.&quot;ClgCode&quot;) OR T0.&quot;ClgCode&quot; = &apos;{3}&apos;)
        ///ORDER BY 
        ///	T0.&quot;ClgCode&quot; DESC
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///F [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ConsultaAtividade {
            get {
                return ResourceManager.GetString("ConsultaAtividade", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///	T0.&quot;BeginStr&quot; || RIGHT(CONCAT(&apos;000000000000000&apos;, IFNULL(CAST(T0.&quot;NextNumber&quot;  AS VARCHAR(15))  ,&apos;&apos;)), T0.&quot;NumSize&quot;) AS &quot;CardCode&quot;
        ///FROM 
        ///	&quot;{0}&quot;.NNM1 T0 
        ///WHERE 
        ///	T0.&quot;ObjectCode&quot; = &apos;2&apos;
        ///	AND  T0.&quot;DocSubType&quot; = &apos;{1}&apos;
        ///	AND  T0.&quot;Series&quot; = {2}.
        /// </summary>
        internal static string ConsultaCardCodePN {
            get {
                return ResourceManager.GetString("ConsultaCardCodePN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;CardName&quot;																AS &quot;NomeCliente&quot;
        ///	, T1.&quot;InstlmntID&quot;															AS &quot;Parcela&quot;
        ///	, T1.&quot;InsTotal&quot;																AS &quot;ValorParcela&quot;
        ///	, T0.&quot;Serial&quot;																AS &quot;NumeroNota&quot;
        ///	, IFNULL(TO_NVARCHAR(T1.&quot;DueDate&quot;, &apos;dd/MM/yyyy&apos;),&apos;&apos;)						AS &quot;DataVencimento&quot;
        ///	, IFNULL(TO_NVARCHAR(T3.&quot;DocDate&quot;, &apos;dd/MM/yyyy&apos;),&apos;&apos;)						AS &quot;DataPagamento&quot;
        ///	,TT1.&quot;Project&quot;																AS &quot;Projeto&quot;
        ///	,CASE WHEN IFNULL(T3.&quot;DocDate&quot;,&apos;&apos;) &lt;&gt; &apos;&apos; THEN &apos;Recebido&apos; ELSE &apos;Receber&apos; END AS &quot;Sta [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ConsultaContasReceber {
            get {
                return ResourceManager.GetString("ConsultaContasReceber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;Num&quot;
        ///	, T0.&quot;Descript&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OOIN T0
        ///GROUP BY
        ///	T0.&quot;Num&quot;
        ///	, T0.&quot;Descript&quot;
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaDescricao {
            get {
                return ResourceManager.GetString("ConsultaDescricao", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;Code&quot;
        ///	, T0.&quot;Name&quot; 
        ///FROM 
        ///	&quot;{0}&quot;.OCST T0
        ///GROUP BY
        ///	T0.&quot;Code&quot;
        ///	, T0.&quot;Name&quot; 
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaEstadoPN {
            get {
                return ResourceManager.GetString("ConsultaEstadoPN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;Num&quot;
        ///	, T0.&quot;Descript&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OOST T0
        ///WHERE 
        ///	T0.&quot;SalesStage&quot; = &apos;Y&apos;
        ///GROUP BY
        ///	T0.&quot;Num&quot;
        ///	, T0.&quot;Descript&quot;
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaEtapa {
            get {
                return ResourceManager.GetString("ConsultaEtapa", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;BPLId&quot;
        ///	, T0.&quot;BPLName&quot; 
        ///FROM 
        ///	&quot;{0}&quot;.OBPL T0
        ///WHERE 
        ///	T0.&quot;Disabled&quot; = &apos;N&apos;
        ///
        ///GROUP BY
        ///	T0.&quot;BPLId&quot;
        ///	, T0.&quot;BPLName&quot; 
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaFilialPedido {
            get {
                return ResourceManager.GetString("ConsultaFilialPedido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;Code&quot;
        ///	, T0.&quot;Name&quot; 
        ///FROM 
        ///	&quot;{0}&quot;.OCST T0
        ///GROUP BY
        ///	T0.&quot;Code&quot;
        ///	, T0.&quot;Name&quot; 
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaGrupoItem {
            get {
                return ResourceManager.GetString("ConsultaGrupoItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;GroupCode&quot;
        ///	, T0.&quot;GroupName&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OCRG T0
        ///WHERE 
        ///	T0.&quot;GroupType&quot; = &apos;{1}&apos;
        ///GROUP BY
        ///	T0.&quot;GroupCode&quot;
        ///	, T0.&quot;GroupName&quot;
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaGrupoPN {
            get {
                return ResourceManager.GetString("ConsultaGrupoPN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT TOP 20
        ///	T0.&quot;ItemCode&quot;
        ///	,T0.&quot;ItemName&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OITM T0  
        ///WHERE 
        ///	    (UPPER(&apos;{1}&apos;) IN (&apos;&apos;, UPPER(T0.&quot;ItemCode&quot;)) OR UPPER(T0.&quot;ItemCode&quot;) LIKE UPPER(&apos;%{1}%&apos;)) 
        ///	AND (UPPER(&apos;{2}&apos;) IN (&apos;&apos;, UPPER(T0.&quot;ItemName&quot;)) OR UPPER(T0.&quot;ItemName&quot;) LIKE UPPER(&apos;%{2}%&apos;))
        ///	AND T0.&quot;SellItem&quot; = &apos;Y&apos;
        ///	AND T0.&quot;validFor&quot;  = &apos;Y&apos;
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaItensPedido {
            get {
                return ResourceManager.GetString("ConsultaItensPedido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;Code&quot;
        ///	, T0.&quot;Name&quot; 
        ///FROM 
        ///	&quot;{0}&quot;.OCLO T0
        ///GROUP BY
        ///	T0.&quot;Code&quot;
        ///	, T0.&quot;Name&quot; 
        ///
        ///UNION ALL
        ///
        ///SELECT 
        ///	&apos;-1&apos;		AS &quot;Code&quot;
        ///	, &apos;Nenhum&apos;	AS &quot;Name&quot;
        ///FROM 
        ///	DUMMY
        ///
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaLocalAtividade {
            get {
                return ResourceManager.GetString("ConsultaLocalAtividade", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;AbsId&quot;
        ///	, T0.&quot;Name&quot; 
        ///FROM 
        ///	&quot;{0}&quot;.OCNT T0 
        ///WHERE 
        ///	T0.&quot;State&quot; = &apos;{1}&apos;
        ///GROUP BY
        ///	T0.&quot;AbsId&quot;
        ///	, T0.&quot;Name&quot; 
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaMunicipioPN {
            get {
                return ResourceManager.GetString("ConsultaMunicipioPN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;Num&quot;
        ///	, T0.&quot;Descript&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OOIR T0
        ///GROUP BY
        ///	T0.&quot;Num&quot;
        ///	, T0.&quot;Descript&quot;
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaNivelInteresse {
            get {
                return ResourceManager.GetString("ConsultaNivelInteresse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT TOP 20
        ///	T0.&quot;OpprId&quot;
        ///	, T1.&quot;CardName&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OOPR T0  LEFT JOIN 
        ///	&quot;{0}&quot;.OCRD T1 ON T0.&quot;CardCode&quot; = T1.&quot;CardCode&quot;
        ///WHERE 
        ///	    (UPPER(&apos;{1}&apos;) IN (&apos;&apos;, UPPER(T1.&quot;CardCode&quot;)) OR UPPER(T1.&quot;CardCode&quot;) LIKE UPPER(&apos;%{1}%&apos;)) 
        ///	AND (UPPER(&apos;{2}&apos;) IN (&apos;&apos;, UPPER(T1.&quot;CardName&quot;)) OR UPPER(T1.&quot;CardName&quot;) LIKE UPPER(&apos;%{2}%&apos;))
        ///	AND (&apos;{3}&apos; IN (&apos;&apos;, T0.&quot;OpprId&quot;) OR T0.&quot;OpprId&quot; = &apos;{3}&apos;)
        ///ORDER BY 
        ///	T0.&quot;OpprId&quot; DESC
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ConsultaOportunidadee {
            get {
                return ResourceManager.GetString("ConsultaOportunidadee", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;Code&quot;
        ///	, T0.&quot;Name&quot; 
        ///FROM 
        ///	&quot;{0}&quot;.OCRY T0
        ///GROUP BY
        ///	T0.&quot;Code&quot;
        ///	, T0.&quot;Name&quot; 
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaPaisPN {
            get {
                return ResourceManager.GetString("ConsultaPaisPN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT TOP 20
        ///	T0.&quot;DocEntry&quot;
        ///FROM 
        ///	&quot;{0}&quot;.ORDR T0  
        ///WHERE 
        ///	    (UPPER(&apos;{1}&apos;) IN (&apos;&apos;, UPPER(T0.&quot;CardCode&quot;)) OR UPPER(T0.&quot;CardCode&quot;) LIKE UPPER(&apos;%{1}%&apos;)) 
        ///	AND (UPPER(&apos;{2}&apos;) IN (&apos;&apos;, UPPER(T0.&quot;CardName&quot;)) OR UPPER(T0.&quot;CardName&quot;) LIKE UPPER(&apos;%{2}%&apos;))
        ///	AND (&apos;{3}&apos; IN (&apos;&apos;, T0.&quot;DocNum&quot;) OR T0.&quot;DocNum&quot; = &apos;{3}&apos;)
        ///ORDER BY 
        ///	T0.&quot;DocEntry&quot; DESC
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaPedido {
            get {
                return ResourceManager.GetString("ConsultaPedido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT TOP 20
        ///	T0.&quot;CardCode&quot; 
        ///FROM 
        ///	&quot;{0}&quot;.OCRD T0  INNER JOIN 
        ///	&quot;{0}&quot;.CRD7 T1 ON T0.&quot;CardCode&quot; = T1.&quot;CardCode&quot; 
        ///WHERE 
        ///	    (UPPER(&apos;{1}&apos;) IN (&apos;&apos;, UPPER(T0.&quot;CardCode&quot;)) OR UPPER(T0.&quot;CardCode&quot;) LIKE UPPER(&apos;%{1}%&apos;)) 
        ///	AND (UPPER(&apos;{2}&apos;) IN (&apos;&apos;, UPPER(T0.&quot;CardName&quot;)) OR UPPER(T0.&quot;CardName&quot;) LIKE UPPER(&apos;%{2}%&apos;))
        ///	AND (UPPER(&apos;{3}&apos;) IN (&apos;&apos;, UPPER(T1.&quot;TaxId0&quot;)) OR UPPER(T1.&quot;TaxId0&quot;) LIKE UPPER(&apos;%{3}%&apos;))
        ///	AND (UPPER(&apos;{4}&apos;) IN (&apos;&apos;, UPPER(T1.&quot;TaxId4&quot;)) OR UPPER(T1.&quot;TaxId4&quot;) LIKE UPPER(&apos;% [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ConsultaPN {
            get {
                return ResourceManager.GetString("ConsultaPN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;CloPrcnt&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OOST T0
        ///WHERE 
        ///	 T0.&quot;Num&quot; = {1}
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaPorcentagem {
            get {
                return ResourceManager.GetString("ConsultaPorcentagem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///	MIN(T0.&quot;ClgCode&quot;) 
        ///	, T1.&quot;CardName&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OCLG T0  LEFT JOIN 
        ///	&quot;{0}&quot;.OCRD T1 ON T0.&quot;CardCode&quot; = T1.&quot;CardCode&quot;
        ///GROUP BY
        ///	T1.&quot;CardName&quot;.
        /// </summary>
        internal static string ConsultaPrimeiroAtividade {
            get {
                return ResourceManager.GetString("ConsultaPrimeiroAtividade", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///	MIN(T0.&quot;OpprId&quot;) 
        ///	, T1.&quot;CardName&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OOPR T0  LEFT JOIN 
        ///	&quot;{0}&quot;.OCRD T1 ON T0.&quot;CardCode&quot; = T1.&quot;CardCode&quot;
        ///GROUP BY
        ///	T1.&quot;CardName&quot;.
        /// </summary>
        internal static string ConsultaPrimeiroOportunidade {
            get {
                return ResourceManager.GetString("ConsultaPrimeiroOportunidade", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///	MIN(T0.&quot;DocEntry&quot;) 
        ///FROM &quot;{0}&quot;.ORDR T0.
        /// </summary>
        internal static string ConsultaPrimeiroPedido {
            get {
                return ResourceManager.GetString("ConsultaPrimeiroPedido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///	MIN(T0.&quot;CardCode&quot;) 
        ///FROM 
        ///	&quot;{0}&quot;.OCRD T0
        ///WHERE
        ///	T0.&quot;CardType&quot; = &apos;C&apos;.
        /// </summary>
        internal static string ConsultaPrimeiroPN {
            get {
                return ResourceManager.GetString("ConsultaPrimeiroPN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;PrjCode&quot;
        ///	, T0.&quot;PrjName&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OPRJ T0
        ///WHERE 
        ///	T0.&quot;Active&quot; = &apos;Y&apos;
        ///GROUP BY
        ///	T0.&quot;PrjCode&quot;
        ///	, T0.&quot;PrjName&quot;
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaProjetoPN {
            get {
                return ResourceManager.GetString("ConsultaProjetoPN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT TOP 1 
        ///	T0.&quot;ClgCode&quot;
        ///	, T1.&quot;CardName&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OCLG T0  LEFT JOIN 
        ///	&quot;{0}&quot;.OCRD T1 ON T0.&quot;CardCode&quot; = T1.&quot;CardCode&quot;
        ///WHERE 
        ///	T0.&quot;ClgCode&quot; &gt; &apos;{1}&apos; 
        ///ORDER BY 
        ///	T0.&quot;ClgCode&quot;.
        /// </summary>
        internal static string ConsultaProximoAtividade {
            get {
                return ResourceManager.GetString("ConsultaProximoAtividade", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT TOP 1 
        ///	T0.&quot;OpprId&quot;
        ///	, T1.&quot;CardName&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OOPR T0  LEFT JOIN 
        ///	&quot;{0}&quot;.OCRD T1 ON T0.&quot;CardCode&quot; = T1.&quot;CardCode&quot;
        ///WHERE 
        ///	T0.&quot;OpprId&quot; &gt; &apos;{1}&apos; 
        ///ORDER BY 
        ///	T0.&quot;OpprId&quot;.
        /// </summary>
        internal static string ConsultaProximoOportunidade {
            get {
                return ResourceManager.GetString("ConsultaProximoOportunidade", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT TOP 1 
        ///	T0.&quot;DocEntry&quot; 
        ///FROM 
        ///	&quot;{0}&quot;.ORDR T0 
        ///WHERE 
        ///	T0.&quot;DocEntry&quot; &gt; &apos;{1}&apos; 
        ///ORDER BY 
        ///	T0.&quot;DocEntry&quot;.
        /// </summary>
        internal static string ConsultaProximoPedido {
            get {
                return ResourceManager.GetString("ConsultaProximoPedido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT TOP 1 
        ///	T0.&quot;CardCode&quot; 
        ///FROM 
        ///	&quot;{0}&quot;.OCRD T0 
        ///WHERE 
        ///	T0.&quot;CardCode&quot; &gt; &apos;{1}&apos; 
        ///	AND	T0.&quot;CardType&quot; = &apos;C&apos;
        ///ORDER BY 
        ///	T0.&quot;CardCode&quot;.
        /// </summary>
        internal static string ConsultaProximoPN {
            get {
                return ResourceManager.GetString("ConsultaProximoPN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;Series&quot;
        ///	, T0.&quot;SeriesName&quot; 
        ///FROM 
        ///	&quot;{0}&quot;.NNM1 T0 
        ///WHERE 
        ///	T0.&quot;ObjectCode&quot; = &apos;2&apos;
        ///	AND  T0.&quot;DocSubType&quot; = &apos;{1}&apos;
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaSeriePN {
            get {
                return ResourceManager.GetString("ConsultaSeriePN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;Code&quot;
        ///	, T0.&quot;Name&quot; 
        ///FROM 
        ///	&quot;{0}&quot;.OCLT T0
        ///WHERE 
        ///	T0.&quot;Active&quot; = &apos;Y&apos; 
        ///GROUP BY
        ///	T0.&quot;Code&quot;
        ///	, T0.&quot;Name&quot; 
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaTipoAtividade {
            get {
                return ResourceManager.GetString("ConsultaTipoAtividade", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;empID&quot;
        ///	,T0.&quot;lastName&quot; || &apos;, &apos;||  T0.&quot;firstName&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OHEM T0
        ///WHERE 
        ///	T0.&quot;Active&quot; = &apos;Y&apos;
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaTitular {
            get {
                return ResourceManager.GetString("ConsultaTitular", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///	MAX(T0.&quot;ClgCode&quot;) 
        ///	, T1.&quot;CardName&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OCLG T0  LEFT JOIN 
        ///	&quot;{0}&quot;.OCRD T1 ON T0.&quot;CardCode&quot; = T1.&quot;CardCode&quot;
        ///GROUP BY
        ///	T1.&quot;CardName&quot;.
        /// </summary>
        internal static string ConsultaUltimoAtividade {
            get {
                return ResourceManager.GetString("ConsultaUltimoAtividade", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///	MAX(T0.&quot;OpprId&quot;) 
        ///	, T1.&quot;CardName&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OOPR T0  LEFT JOIN 
        ///	&quot;{0}&quot;.OCRD T1 ON T0.&quot;CardCode&quot; = T1.&quot;CardCode&quot;
        ///GROUP BY
        ///	T1.&quot;CardName&quot;.
        /// </summary>
        internal static string ConsultaUltimoOportunidade {
            get {
                return ResourceManager.GetString("ConsultaUltimoOportunidade", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///	MAX(T0.&quot;DocEntry&quot;) 
        ///FROM 
        ///	&quot;{0}&quot;.ORDR T0.
        /// </summary>
        internal static string ConsultaUltimoPedido {
            get {
                return ResourceManager.GetString("ConsultaUltimoPedido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///	MAX(T0.&quot;CardCode&quot;) 
        ///FROM 
        ///	&quot;{0}&quot;.OCRD T0
        ///WHERE
        ///	T0.&quot;CardType&quot; = &apos;C&apos;.
        /// </summary>
        internal static string ConsultaUltimoPN {
            get {
                return ResourceManager.GetString("ConsultaUltimoPN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;ID&quot;
        ///	, T0.&quot;Usage&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OUSG T0
        ///GROUP BY
        ///	T0.&quot;ID&quot;
        ///	, T0.&quot;Usage&quot;
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaUsoPrincipalPN {
            get {
                return ResourceManager.GetString("ConsultaUsoPrincipalPN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;USERID&quot;
        ///	, T0.&quot;U_NAME&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OUSR T0
        ///WHERE 
        ///	T0.&quot;Locked&quot; = &apos;N&apos;
        ///GROUP BY
        ///	T0.&quot;USERID&quot;
        ///	, T0.&quot;U_NAME&quot; 
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaUsuarioAtividade {
            get {
                return ResourceManager.GetString("ConsultaUsuarioAtividade", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;ID&quot;
        ///	, T0.&quot;Usage&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OUSG  T0 
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaUtilizacaoPedido {
            get {
                return ResourceManager.GetString("ConsultaUtilizacaoPedido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH tableTemp as (	
        ///SELECT 
        ///	T0.&quot;SlpCode&quot;
        ///	, T0.&quot;SlpName&quot;
        ///FROM 
        ///	&quot;{0}&quot;.OSLP T0
        ///WHERE 
        ///	T0.&quot;Active&quot; = &apos;Y&apos;
        ///GROUP BY
        ///	T0.&quot;SlpCode&quot;
        ///	, T0.&quot;SlpName&quot;
        ///)
        ///SELECT 
        ///	 *
        ///	,(SELECT COUNT(1) FROM tableTemp T0) AS &quot;COUNT&quot;
        ///FROM 
        ///	tableTemp T0 .
        /// </summary>
        internal static string ConsultaVendedorPN {
            get {
                return ResourceManager.GetString("ConsultaVendedorPN", resourceCulture);
            }
        }
    }
}