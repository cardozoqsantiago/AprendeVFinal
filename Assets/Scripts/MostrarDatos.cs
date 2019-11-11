using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarDatos : MonoBehaviour {

	
	public Text reporte;
	// Use this for initialization
	public void Start () {
		string nombreEstudiante = PlayerPrefs.GetString ("nombreEstudiante");
		string apellidoEstudiante = PlayerPrefs.GetString ("apellidoEstudiante");
		
		reporte.text = "Reporte de \n" + nombreEstudiante + " " + apellidoEstudiante;
	}

}
