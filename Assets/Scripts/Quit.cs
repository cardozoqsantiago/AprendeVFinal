using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {
	//Metodo publico para salir del juego
	public void salirJuego(){
		//Mensaje a consola de unity
		Debug.Log ("Salió del juego");
		//Salir
		Application.Quit();

	}
}
