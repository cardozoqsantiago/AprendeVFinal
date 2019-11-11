using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ReporteTexto1 : MonoBehaviour {

	public Text txtReporte;
	
	int totalPreguntasPorArea;
	int totalPreguntas;

	double porcentajeM;
	double porcentajeC;
	double porcentajeL;
	double porcentajeS;

	double porcentajeTotal;
	
	public void Start(){

		int correctasM = PlayerPrefs.GetInt ("contadorMatematicasCorrectas11");
		int incorrectasM = PlayerPrefs.GetInt ("contadorMatematicasIncorrectas11");
		int correctasC = PlayerPrefs.GetInt ("contadorCienciasCorrectas11");
		int incorrectasC = PlayerPrefs.GetInt ("contadorCienciasIncorrectas11");
		int correctasL = PlayerPrefs.GetInt ("contadorLenguajeCorrectas11");
		int incorrectasL = PlayerPrefs.GetInt ("contadorLenguajeIncorrectas11");
		int correctasS = PlayerPrefs.GetInt ("contadorSocialesCorrectas11");
		int incorrectasS = PlayerPrefs.GetInt ("contadorSocialesIncorrectas11");

		int totalPreguntasCorrectas= correctasM + correctasC + correctasL + correctasS;
		int totalPreguntasIncorrectas = incorrectasC + incorrectasM + incorrectasL + incorrectasS;

		totalPreguntas = 60;
		totalPreguntasPorArea = 15;
	
		porcentajeTotal = (totalPreguntasCorrectas * 100)/totalPreguntas;
		porcentajeM = (correctasM * 100)/totalPreguntasPorArea;
		porcentajeC = (correctasC * 100)/totalPreguntasPorArea;
		porcentajeL = (correctasL * 100)/totalPreguntasPorArea;
		porcentajeS = (correctasS* 100)/totalPreguntasPorArea;

	
		string nombreEstudiante = PlayerPrefs.GetString ("nombreEstudiante");
		string apellidoEstudiante = PlayerPrefs.GetString ("apellidoEstudiante");

		txtReporte.text = nombreEstudiante + "\n" + "\n" + "El desempeño en la prueba 11° fue de: " + porcentajeTotal + "%" + "\n" +
									"Obteniendo un total de " + totalPreguntasCorrectas + " preguntas contestadas correctamente" + "\n" +
									"y un total de " + totalPreguntasIncorrectas + " preguntas contestadas incorrectamente.";


		string reporteTxt =nombreEstudiante + " " + apellidoEstudiante + "\n" + "\n" + "El desempeño en la prueba 11° fue de: " + porcentajeTotal + "%" + "\n" +
									"Obteniendo un total de " + totalPreguntasCorrectas + " preguntas contestadas correctamente" + "\n" +
									"y un total de " + totalPreguntasIncorrectas + " preguntas contestadas incorrectamente." + "\n" + "\n" +

									"En el área de Matemáticas el desempeño fue de: " + porcentajeM + "%" + "\n" +
									"Obteniendo un total de " + correctasM + " preguntas contestadas correctamente" + "\n" +
									"y un total de " + incorrectasM + " preguntas contestadas incorrectamente." + "\n" + "\n" +

									"En el área de Ciencias el desempeño fue de: " + porcentajeC + "%" + "\n" +
									"Obteniendo un total de " + correctasC + " preguntas contestadas correctamente" + "\n" +
									"y un total de " + incorrectasC + " preguntas contestadas incorrectamente." + "\n" + "\n" +

									"En el área de Lenguaje el desempeño fue de: " + porcentajeL + "%" + "\n" +
									"Obteniendo un total de " + correctasL + " preguntas contestadas correctamente" + "\n" +
									"y un total de " + incorrectasL + " preguntas contestadas incorrectamente." + "\n" + "\n" +

									"En el área de Sociales el desempeño fue de: " + porcentajeS + "%" + "\n" +
									"Obteniendo un total de " + correctasS + " preguntas contestadas correctamente" + "\n" +
									"y un total de " + incorrectasS + " preguntas contestadas incorrectamente." + "\n" + "\n";

		string ruta = "mnt/sdcard/Reportes Pruebas 11/Reporte" + " " + nombreEstudiante + " " + apellidoEstudiante;
		//Direccion de la ruta para crear el archivo dentro de la carpeta
		string reporte = "mnt/sdcard/Reportes Pruebas 11/Reporte" + " " + nombreEstudiante + " " + apellidoEstudiante + "/reportePrueba11°.txt";

		//Se verifica si la ruta existe
		if (!Directory.Exists (ruta)) {
			//De no existir, se crea el directorio
			Directory.CreateDirectory (ruta);
			//se verifica si exite el archivo
			if(!File.Exists(reporte)){
				//De no existir, se crea el archivo
				File.WriteAllText(reporte ,reporteTxt);
			}else{
				//De existir el archivo, se agrega nuevas lineas al archivo
				File.AppendAllText(reporte ,"Hola soy reporte 2 \n");
			}
		}else{
			//se verifica si exite el archivo
			if(!File.Exists(reporte)){
			//De no existir, se crea el archivo
			File.WriteAllText(reporte ,reporteTxt);
			}else{
				//De existir el archivo, se agrega nuevas lineas al archivo

				File.AppendAllText(reporte ,"\n" + "------------------------" + "\n" + "\n" + "Nuevo Reporte \n" + "\n" + reporteTxt);
			}
		}	
		
	}
}