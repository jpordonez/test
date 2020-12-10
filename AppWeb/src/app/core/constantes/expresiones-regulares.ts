//Caracter de escape "\\"
export class ExpresionesRegulares {
	public static ENTEROPOSITIVO='^[1-9][0-9]*$';
	public static DECIMALPOSITIVO='^[1-9][0-9]*\.?[0-9]*$';
	public static DECIMAL='^-?[1-9][0-9]*\.?[0-9]*$';
	public static APELLIDO='^[a-zA-ZñÑáéíóúÁÉÍÓÚ]{1,80}$';
	public static NOMBRE='^[a-zA-ZñÑáéíóúÁÉÍÓÚ\ ]{1,80}$';
	public static CODIGO='^[0-9a-zA-Z_\-]{1,15}$';
	public static DESCRIPCION='^[0-9a-zA-ZñÑáéíóúÁÉÍÓÚ\/\(\)\-\.\,\ ]{1,255}$';
	public static PREGUNTA='^[0-9a-zA-ZñÑáéíóúÁÉÍÓÚ\/\(\)\-\.\,\ \¿\?]{1,255}$';
	public static OPCION='^[0-9a-zA-ZñÑáéíóúÁÉÍÓÚ!\/\(\)\-\.\,\ ]{1,255}$';
	public static TODO='^*$';
	public static IDENTIFICACION = '^[0-9]{10,20}$';
	public static CORREO = '^$|^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9]+\\.[a-zA-Z0-9-.]+$';
	public static TELEFONO='^$|^[0-9\/\(\)\-\.\,\ ]{6,10}$';
	public static CELULAR='^[0-9]{10}$';
	public static RUC = '^[0-9]{13}$';
	public static RAZONSOCIAL='^[0-9a-zA-ZñÑáéíóúÁÉÍÓÚº\/\(\)\-\.\,\ ]{1,150}$';
	public static NOMBREESPECIAL = '^[0-9a-zA-ZñÑáéíóúÁÉÍÓÚº\/\(\)\-\.\,\ ]{1,80}$';
	public static CUENTA = '^[a-zA-Z0-9]{1,15}$';
	public static CLAVE='^(?=.*?[A-Z]*)(?=.*?[a-z]*)(?=.*?[0-9]*)(?=.*?[#?!@$%^&*-]*).{8,}$';
}
