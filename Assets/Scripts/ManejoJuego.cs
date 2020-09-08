using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ManejoJuego : MonoBehaviour
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
   
  public void Start(){

    preguntasDB = GameObject.FindObjectOfType<PreguntasDB>();

    preguntasUI = GameObject.FindObjectOfType<PreguntasUI>();

    fuenteAudio = GetComponent<AudioSource>();
    
    siguientePregunta();
    
  }
  
  public void siguientePregunta(){
    preguntasUI.constructor(preguntasDB.GetRandom9Mat() , darRespuesta);
  }
 
  public void darRespuesta(SeleccionarRespuesta seleccionarRespuesta){

    StartCoroutine(darCaracteristicaRespuesta(seleccionarRespuesta));
    
  }

  public IEnumerator darCaracteristicaRespuesta(SeleccionarRespuesta seleccionarRespuesta){

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

    PlayerPrefs.SetInt ("contadorMatematicasCorrectas", contadorCorrectas);
    PlayerPrefs.SetInt ("contadorMatematicasIncorrectas", contadorInorrectas);

    yield return new WaitForSeconds(tiempoEspera);

    siguientePregunta();
  } 
}
