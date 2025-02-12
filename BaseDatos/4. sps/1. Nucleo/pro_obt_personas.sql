/****** Object:  StoredProcedure [dbo].[pro_obt_personas]    Script Date: 15/05/2017 20:07:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[pro_obt_personas]
@nombre nvarchar(80) = NULL,
@apellido nvarchar(80) = NULL,
@identificacion nvarchar(20) = NULL,
@pageSize int,
@pageNumber int
WITH EXEC AS CALLER
AS
BEGIN

WITH todo AS(
    SELECT p.PER_ID,
      p.PER_APELLIDO1,
	  p.PER_APELLIDO2,
      p.PER_NOMBRE1,
	  p.PER_NOMBRE2,
      p.ITM_TIPO_DOCUMENTO,
	  TipoDocumentoNombre = (SELECT i.ITM_NOMBRE FROM TADM_ITEMCATALOGO i WHERE i.ITM_ID = p.ITM_TIPO_DOCUMENTO),
      p.PER_IDENTIFICACION,
      p.PER_TELEFONO,
      p.PER_MOVIL,
      p.PER_CORREO,
      p.ITM_ESTADO_CIVIL,
	  EstadoCivilNombre = (SELECT i.ITM_NOMBRE FROM TADM_ITEMCATALOGO i WHERE i.ITM_ID = p.ITM_ESTADO_CIVIL)	  
	FROM TADM_PERSONA as p
	WHERE (@nombre IS NULL OR p.PER_NOMBRE1 like '%'+ @nombre+'%' OR p.PER_NOMBRE2 like '%'+ @nombre+'%')
		AND (@apellido IS NULL OR p.PER_APELLIDO1 like '%'+ @apellido+'%' OR p.PER_APELLIDO2 like '%'+ @apellido+'%')
		AND (@identificacion IS NULL OR p.PER_IDENTIFICACION like '%'+ @identificacion+'%')
)

SELECT	p.PER_ID as Id,		
		p.PER_APELLIDO1 as PrimerApellido,
		p.PER_APELLIDO2 as SegundoApellido,
		p.PER_NOMBRE1 as PrimerNombre,
		p.PER_NOMBRE2 as SegundoNombre,
		p.PER_IDENTIFICACION as Identificacion,
		p.PER_MOVIL as Movil,
		p.PER_TELEFONO as Telefono,
		p.PER_CORREO as Correo,
		p.ITM_TIPO_DOCUMENTO as TipoDocumento,
		p.ITM_ESTADO_CIVIL as EstadoCivil,
		TipoDocumentoNombre,
		totalRegistros							 
FROM todo p
CROSS APPLY (SELECT Count(*) AS totalRegistros FROM todo) AS t
ORDER BY p.PER_ID
    OFFSET (@pageNumber-1)*@pageSize ROWS
    FETCH NEXT @pageSize ROWS ONLY;

END