/****** Object:  StoredProcedure [dbo].[pro_obt_diarios_tematicos]    Script Date: 05/04/2015 16:27:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[pro_obt_sesiones]
@cuenta nvarchar(80) = NULL,
@estado_id int = NULL,
@fecha_desde datetime = NULL,
@fecha_hasta datetime = NULL,
@pageSize int,
@pageNumber int
WITH EXEC AS CALLER
AS
BEGIN

WITH todo AS(
    SELECT 
		ses.SES_ID,
		ses.ROL_ID,
		ses.SES_CUENTA,
		ses.SES_ESTADOID,
		ses.SES_FIN,
		ses.SES_INICIO,
		ses.SES_IP,
		(SELECT rol.ROL_NOMBRE FROM TSEG_ROL rol WHERE rol.ROL_ID=ses.ROL_ID) as Rol	
	FROM TSEG_SESION as ses
	WHERE (@cuenta IS NULL OR ses.SES_CUENTA like '%'+ @cuenta+'%')
		AND (@estado_id IS NULL OR ses.SES_ESTADOID = @estado_id)		
		AND (@fecha_desde IS NULL OR @fecha_desde <= ses.SES_INICIO)
		AND (@fecha_hasta IS NULL OR @fecha_hasta >= ses.SES_INICIO)
)

SELECT	p.SES_ID as Id,
		p.ROL_ID as RolId,
		p.SES_CUENTA as Cuenta,
		p.SES_ESTADOID as EstadoId,
		p.SES_FIN as Fin,
		p.SES_INICIO as Inicio,
		p.SES_IP as Ip,
		p.Rol,
		totalRegistros									 
FROM todo p
CROSS APPLY (SELECT Count(*) AS totalRegistros FROM todo) AS t
ORDER BY p.SES_INICIO DESC
    OFFSET (@pageNumber-1)*@pageSize ROWS
    FETCH NEXT @pageSize ROWS ONLY;

END