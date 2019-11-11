using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IniciarSesion : MonoBehaviour {

	public InputField campoId;
	public InputField campoContrasenia;
	string idProfesor;
	string contrasenia;
	public Text txtError;

	void awake(){
		DontDestroyOnLoad (gameObject);
	}

	public void login(string pnombreescena){
		idProfesor = campoId.text;
		contrasenia = campoContrasenia.text;

		if (idProfesor == "Rectora" && contrasenia == "12345") {

			SceneManager.LoadScene (pnombreescena);
			PlayerPrefs.SetString ("contrasenia", contrasenia);
			PlayerPrefs.SetString ("idProfesor", idProfesor);
		} else {
			if (idProfesor != "Rectora" || contrasenia != "12345") {
				txtError.text = "Usuario o contraseña incorrectos";
			}
			
			if (idProfesor == "" || contrasenia == "") {
				txtError.text = "Rellene todos los campos";

			}


		}
}
}