using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
/**

Clase que permite gestionar las preguntas de la base de datos
@autor Santiago Cardozo Q
@autor Santiago Bedoya Ossa

 */
public class PreguntasDB1: MonoBehaviour
{
    //Se crea una lista de preguntas
    [SerializeField] private List<Pregunta> listaPreguntas = null;
    [SerializeField] private List<Pregunta> listaPreguntasCiencias = null;
    [SerializeField] private List<Pregunta> listaPreguntasLenguaje = null;
    [SerializeField] private List<Pregunta> listaPreguntasSociales = null;

    /**
    Metodo que remueve las preguntas que ya salieron
    @param remove
    @return p
     */
    public Pregunta GetRandom11Mat(bool remove = true){
        
        if(listaPreguntas.Count == 46){ 
            SceneManager.LoadScene ("ListaPreguntas 5");
        }
        
        int index = Random.Range(0 , listaPreguntas.Count);  
        //Debug.Log("El index es" + index);
        // Se retornan la pregunta en la posicion index
        if(!remove)
            return listaPreguntas[index];  
        //Se guarda la pregunta actual en p
        Pregunta p = listaPreguntas[index];
        //Una vez aparecio la pregunta, se remueve
        listaPreguntas.RemoveAt(index);
        //Se muestra la pregunta
        return p;
    }

    public Pregunta GetRandom11Cie(bool remove = true){
       
        if(listaPreguntasCiencias.Count == 5){    
        SceneManager.LoadScene ("ListaPreguntas 6");
        }
        
        int index = Random.Range(0 , listaPreguntasCiencias.Count);  
        //Debug.Log("El index es" + index);
        // Se retornan la pregunta en la posicion index
        if(!remove)
            return listaPreguntasCiencias[index];  
        //Se guarda la pregunta actual en p
        Pregunta p = listaPreguntasCiencias[index];
        //Una vez aparecio la pregunta, se remueve
        listaPreguntasCiencias.RemoveAt(index);
        //Se muestra la pregunta
        return p;
    }
    public Pregunta GetRandom11Len(bool remove = true){
       
        if(listaPreguntasLenguaje.Count == 45){    
        SceneManager.LoadScene ("ListaPreguntas 7");
        }
        
        int index = Random.Range(0 , listaPreguntasLenguaje.Count);  
        //Debug.Log("El index es" + index);
        // Se retornan la pregunta en la posicion index
        if(!remove)
            return listaPreguntasLenguaje[index];  
        //Se guarda la pregunta actual en p
        Pregunta p = listaPreguntasLenguaje[index];
        //Una vez aparecio la pregunta, se remueve
        listaPreguntasLenguaje.RemoveAt(index);
        //Se muestra la pregunta
        return p;
    }
    public Pregunta GetRandom11Soc(bool remove = true){
       
        if(listaPreguntasSociales.Count == 5){    
        SceneManager.LoadScene ("ReporteEstudiante 1");
        }
        
        int index = Random.Range(0 , listaPreguntasSociales.Count);  
        //Debug.Log("El index es" + index);
        // Se retornan la pregunta en la posicion index
        if(!remove)
            return listaPreguntasSociales[index];  
        //Se guarda la pregunta actual en p
        Pregunta p = listaPreguntasSociales[index];
        //Una vez aparecio la pregunta, se remueve
        listaPreguntasSociales.RemoveAt(index);
        //Se muestra la pregunta
        return p;
    }




    


    


    

    
}
