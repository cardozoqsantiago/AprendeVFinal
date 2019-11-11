using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegistroEstudiante : MonoBehaviour {

	public InputField campoNombre;
	public InputField campoApellido;
	string nombreEStudiante;
	string apellidoEstudiante;
	public Text txtError;

	public void awake(){
		DontDestroyOnLoad (gameObject);
	}

	public void guardar(string pnombreescena){
		nombreEStudiante = campoNombre.text;
		apellidoEstudiante = campoApellido.text;

		if (nombreEStudiante != "" && apellidoEstudiante != "") {
			SceneManager.LoadScene (pnombreescena);
			PlayerPrefs.SetString ("nombreEstudiante", nombreEStudiante);
			PlayerPrefs.SetString ("apellidoEstudiante", apellidoEstudiante);

		} else {
			txtError.text = "Rellene todos los campos";
		}

	}

		
}
