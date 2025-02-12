/****** Object:  StoredProcedure [dbo].[pro_obt_diarios_tematicos]    Script Date: 05/04/2015 16:27:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[pro_obt_instituciones]
@nombres nvarchar(80) = NULL,
@ruc nvarchar(80) = NULL,
@pageSize int,
@pageNumber int
WITH EXEC AS CALLER
AS
BEGIN

WITH todo AS(
    SELECT i.INS_ID,
	  i.PER_ID,
	  p.PER_NOMBRE1,
	  p.PER_NOMBRE2,
	  p.PER_APELLIDO1,
	  p.PER_APELLIDO2,
	  p.PER_IDENTIFICACION,
      i.INS_RAZON_SOCIAL,
      i.INS_RUC,
	  i.ITM_INSCRITO,
	  IncritoEnNombre = (SELECT itm.ITM_NOMBRE FROM TADM_ITEMCATALOGO itm WHERE itm.ITM_ID = i.ITM_INSCRITO),
	  i.INS_LUGAR_INSCRIPCION,
	  i.INS_NUMERO_ACUERDO_REGISTRO  
	FROM	TADM_INSTITUCION as i,
			TADM_PERSONA as p
	WHERE p.PER_ID = i.PER_ID
		AND (@nombres IS NULL OR i.INS_RAZON_SOCIAL like '%'+ @nombres+'%')
		AND (@ruc IS NULL OR i.INS_RUC like '%'+ @ruc+'%')
	UNION ALL
	SELECT i.INS_ID,
	  i.PER_ID,
	  '' as PER_NOMBRE1,
	  '' as PER_NOMBRE2,
	  '' as PER_APELLIDO1,
	  '' as PER_APELLIDO2,
	  '' as PER_IDENTIFICACION,
      i.INS_RAZON_SOCIAL,
      i.INS_RUC,
	  i.ITM_INSCRITO,
	  IncritoEnNombre = (SELECT itm.ITM_NOMBRE FROM TADM_ITEMCATALOGO itm WHERE itm.ITM_ID = i.ITM_INSCRITO),
	  i.INS_LUGAR_INSCRIPCION,
	  i.INS_NUMERO_ACUERDO_REGISTRO  
	FROM	TADM_INSTITUCION as i
	WHERE i.PER_ID IS NULL
		AND (@nombres IS NULL OR i.INS_RAZON_SOCIAL like '%'+ @nombres+'%')
		AND (@ruc IS NULL OR i.INS_RUC like '%'+ @ruc+'%')

)

SELECT	i.INS_ID as Id,
		i.PER_ID as RepresentanteId,
		ISNULL(i.PER_NOMBRE1,'')+' '+ISNULL(i.PER_NOMBRE2,'') as RepresentanteNombres,
		ISNULL(i.PER_APELLIDO1,'')+' '+ISNULL(i.PER_APELLIDO2,'') as RepresentanteApellidos,
		i.PER_IDENTIFICACION as RepresentanteIdentificacion,
		i.INS_RAZON_SOCIAL as RazonSocial,
		i.INS_RUC as Ruc,
		i.ITM_INSCRITO as InscritoId,
		i.IncritoEnNombre,
		i.INS_LUGAR_INSCRIPCION as LugarInscripcion,
		i.INS_NUMERO_ACUERDO_REGISTRO as NumeroAcuerdo,
		totalRegistros
FROM todo i
CROSS APPLY (SELECT Count(*) AS totalRegistros FROM todo) AS t
ORDER BY i.INS_ID
    OFFSET (@pageNumber-1)*@pageSize ROWS
    FETCH NEXT @pageSize ROWS ONLY;

END
