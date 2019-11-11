using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**

Clase que permite permite dibujar las preguntas en la UI
@autor Santiago Cardozo Q
@autor Santiago Bedoya Ossa

 */
public class PreguntasUI : MonoBehaviour
{
   [SerializeField] private Text textoPregunta = null;
   [SerializeField] private List<SeleccionarRespuesta> listaRespuestas = null;

   public void constructor(Pregunta p , Action<SeleccionarRespuesta> callback){
       
       textoPregunta.text = p.pregunta;
       
        for(int i= 0 ; i < listaRespuestas.Count ; i++){
            listaRespuestas[i].constructor(p.opciones[i] , callback);

        }
   }
}
