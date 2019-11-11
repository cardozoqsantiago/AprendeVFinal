using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarDatos1 : MonoBehaviour {

	public Text txtBienvenida;
	
	// Use this for initialization
	public void Start () {
		string nombreEstudiante = PlayerPrefs.GetString ("nombreEstudiante");
		string apellidoEstudiante = PlayerPrefs.GetString ("apellidoEstudiante");
		txtBienvenida.text = "Bienvenido(@) \n" + nombreEstudiante;
		
	}

}
