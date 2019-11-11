using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ManejoJuego4 : MonoBehaviour
{
  [SerializeField] private AudioClip sonidoCorrecto = null;

  [SerializeField] private AudioClip sonidoIncorrecto = null;

  [SerializeField] private Color colorCorrecto = Color.black;

  [SerializeField] private Color colorIncorrecto = Color.black;

  [SerializeField] private float tiempoEspera = 0.0f;

  private PreguntasDB1 PreguntasDB1 = null;

  private PreguntasUI preguntasUI = null;

  private AudioSource fuenteAudio = null;

   int contadorCorrectas = 0;
   int contadorInorrectas = 0;
   
  private void Start(){

    PreguntasDB1 = GameObject.FindObjectOfType<PreguntasDB1>();

    preguntasUI = GameObject.FindObjectOfType<PreguntasUI>();

    fuenteAudio = GetComponent<AudioSource>();
    
      siguientePregunta();
    
  }
  
  private void siguientePregunta(){
    preguntasUI.constructor(PreguntasDB1.GetRandom11Mat() , darRespuesta);
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

    PlayerPrefs.SetInt ("contadorMatematicasCorrectas11", contadorCorrectas);
    PlayerPrefs.SetInt ("contadorMatematicasIncorrectas11", contadorInorrectas);

    yield return new WaitForSeconds(tiempoEspera);

    siguientePregunta();
  } 

  
  


}
