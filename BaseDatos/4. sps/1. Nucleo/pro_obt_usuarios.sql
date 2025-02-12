/****** Object:  StoredProcedure [dbo].[pro_obt_diarios_tematicos]    Script Date: 05/04/2015 16:27:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[pro_obt_usuarios]
@identificacion nvarchar(20) = NULL,
@cuenta nvarchar(80) = NULL,
@en_rol_id int = NULL,
@pageSize int,
@pageNumber int
WITH EXEC AS CALLER
AS
BEGIN

WITH todo AS(
    SELECT usu.USR_ID as Id,
	  usu.USR_CUENTA as Cuenta,
      usu.USR_CLAVE as Clave,
      per.PER_IDENTIFICACION as Identificacion,
      per.PER_NOMBRE1 + ' ' + per.PER_NOMBRE2 as Nombres,
      per.PER_APELLIDO1 + ' ' + per.PER_APELLIDO2 as Apellidos,
      per.PER_CORREO as Correo,
	  usu.USR_ESTADO as Estado,
	  usu.PER_ID as PersonaId,
	  RolIds = STUFF((
          SELECT ',' + CAST(uro.ROL_ID AS NVARCHAR)
          FROM TSEG_USUARIO_ROL uro
          WHERE uro.USR_ID = usu.USR_ID
          FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, ''),
	  RolNombres = STUFF((
          SELECT ',' + rol.ROL_NOMBRE
          FROM TSEG_USUARIO_ROL uro,
				TSEG_ROL rol
          WHERE uro.USR_ID = usu.USR_ID
				AND uro.ROL_ID = rol.ROL_ID
          FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '')
	FROM TSEG_USUARIO as usu left join 
	TADM_PERSONA as per
	ON usu.PER_ID = per.PER_ID
	WHERE 
		(@identificacion IS NULL OR per.PER_IDENTIFICACION like '%'+ @identificacion+'%')
		AND (@cuenta IS NULL OR usu.USR_CUENTA like '%'+ @cuenta+'%')
		AND (@en_rol_id IS NULL OR EXISTS(SELECT *
											  FROM TSEG_USUARIO_ROL uro
											  WHERE uro.USR_ID = usu.USR_ID
													AND uro.ROL_ID = @en_rol_id))
)

SELECT	p.Id,
		p.Cuenta,
		p.Clave,
		p.Identificacion,
		p.Nombres,
		p.Apellidos,
		p.Correo,
		p.Estado,
		p.PersonaId,
		p.RolIds,
		p.RolNombres,
		totalRegistros							 
FROM todo p
CROSS APPLY (SELECT Count(*) AS totalRegistros FROM todo) AS t
ORDER BY p.Id
    OFFSET (@pageNumber-1)*@pageSize ROWS
    FETCH NEXT @pageSize ROWS ONLY;

END