USE [test]
GO
/****** Object:  StoredProcedure [dbo].[pro_obt_personas]    Script Date: 10/12/2020 12:57:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[pro_obt_resultados]
@docente_id int = NULL,
@pageSize int,
@pageNumber int
WITH EXEC AS CALLER
AS
BEGIN

WITH todo AS(
    SELECT doc.PER_ID as DocenteId,		
		doc.PER_APELLIDO1 as DocentePrimerApellido,
		doc.PER_APELLIDO2 as DocenteSegundoApellido,
		doc.PER_NOMBRE1 as DocentePrimerNombre,
		doc.PER_NOMBRE2 as DocenteSegundoNombre,
		doc.PER_IDENTIFICACION as DocenteIdentificacion,
		est.PER_ID as EstudianteId,		
		est.PER_APELLIDO1 as EstudiantePrimerApellido,
		est.PER_APELLIDO2 as EstudianteSegundoApellido,
		est.PER_NOMBRE1 as EstudiantePrimerNombre,
		est.PER_NOMBRE2 as EstudianteSegundoNombre,
		est.PER_IDENTIFICACION as EstudianteIdentificacion,
		coe.COE_ID as CoeId,
		coe.COE_CODIGO as CoeCodigo,
		coe.COE_NOMBRE as CoeNombre,
		res.RES_DEBERES as Deberes,
		res.RES_EXAMEN as Examen,
		asd.ASD_ID as AsignacionDocenteId, 
		mat.MAT_ID as MatriculaId, 
		res.RES_FECHA as Fecha,
		res.RES_ID as Id
FROM TADM_PERSONA doc
	INNER JOIN TNEG_ASIGNACION_DOCENTE asd 
	ON doc.PER_ID = asd.PER_ID
	INNER JOIN TNEG_COMPONENTE_EDUCATIVO coe
	ON asd.COE_ID = coe.COE_ID
	INNER JOIN TNEG_MATRICULA mat 
	ON mat.COE_ID = coe.COE_ID
	INNER JOIN TADM_PERSONA est 
	ON mat.PER_ID = est.PER_ID
	LEFT JOIN TNEG_RESULTADOS res
	ON mat.MAT_ID = res.MAT_ID
WHERE @docente_id IS NULL OR doc.PER_ID = @docente_id
)

SELECT	p.*,		
		totalRegistros							 
FROM todo p
CROSS APPLY (SELECT Count(*) AS totalRegistros FROM todo) AS t
ORDER BY p.Fecha
    OFFSET (@pageNumber-1)*@pageSize ROWS
    FETCH NEXT @pageSize ROWS ONLY;

END