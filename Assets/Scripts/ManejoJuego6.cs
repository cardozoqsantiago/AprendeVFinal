using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ManejoJuego6 : MonoBehaviour
{
  [SerializeField] private AudioClip sonidoCorrecto = null;

  [SerializeField] private AudioClip sonidoIncorrecto = null;

  [SerializeField] private Color colorCorrecto = Color.black;

  [SerializeField] private Color colorIncorrecto = Color.black;

  [SerializeField] private float tiempoEspera = 0.0f;

  private PreguntasDB1 preguntasDB1 = null;

  private PreguntasUI preguntasUI = null;

  private AudioSource fuenteAudio = null;

   int contadorCorrectas = 0;
   int contadorInorrectas = 0;
   
  public void Start(){

    preguntasDB1 = GameObject.FindObjectOfType<PreguntasDB1>();

    preguntasUI = GameObject.FindObjectOfType<PreguntasUI>();

    fuenteAudio = GetComponent<AudioSource>();
    
      siguientePregunta3();
    
  }
  
  public void siguientePregunta3(){
    preguntasUI.constructor(preguntasDB1.GetRandom11Len() , darRespuesta);
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

    PlayerPrefs.SetInt ("contadorLenguajeCorrectas11", contadorCorrectas);
    PlayerPrefs.SetInt ("contadorLenguajeIncorrectas11", contadorInorrectas);

    yield return new WaitForSeconds(tiempoEspera);

    siguientePregunta3();
  } 

  
  


}
