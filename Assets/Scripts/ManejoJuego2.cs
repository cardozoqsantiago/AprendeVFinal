using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ManejoJuego2 : MonoBehaviour
{
  [SerializeField] private AudioClip sonidoCorrecto = null;

  [SerializeField] private AudioClip sonidoIncorrecto = null;

  [SerializeField] private Color colorCorrecto = Color.black;

  [SerializeField] private Color colorIncorrecto = Color.black;

  [SerializeField] private float tiempoEspera = 0.0f;

  private PreguntasDB preguntasDB = null;

  private PreguntasUI preguntasUI = null;

  private AudioSource fuenteAudio = null;

  int contadorCorrectas = 0;
  int contadorInorrectas = 0;

  private void Start(){

    preguntasDB = GameObject.FindObjectOfType<PreguntasDB>();

    preguntasUI = GameObject.FindObjectOfType<PreguntasUI>();

    fuenteAudio = GetComponent<AudioSource>();
    
      siguientePregunta3();
    
  }
  
  private void siguientePregunta3(){
    preguntasUI.constructor(preguntasDB.GetRandom9Len() , darRespuesta);
  }
 

  private void darRespuesta(SeleccionarRespuesta seleccionarRespuesta){

    StartCoroutine(darCaracteristicaRespuesta(seleccionarRespuesta));
    
  }

  private IEnumerator darCaracteristicaRespuesta(SeleccionarRespuesta seleccionarRespuesta){

    if(fuenteAudio.isPlaying)
      fuenteAudio.Stop();
    

    fuenteAudio.clip = seleccionarRespuesta.Opcion.correcta ? sonidoCorrecto : sonidoIncorrecto;
    seleccionarRespuesta.setColor(seleccionarRespuesta.Opcion.correcta ? colorCorrecto : colorIncorrecto);
    
    fuenteAudio.Play();
    if(seleccionarRespuesta.Opcion.correcta){
          contadorCorrectas++;

      }
    if(!seleccionarRespuesta.Opcion.correcta){
          contadorInorrectas++;
    }

    PlayerPrefs.SetInt ("contadorLenguajeCorrectas", contadorCorrectas);
    PlayerPrefs.SetInt ("contadorLenguajeIncorrectas", contadorInorrectas);

    yield return new WaitForSeconds(tiempoEspera);

    siguientePregunta3();
  } 

  
  


}
