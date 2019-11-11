using System;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]

/**

Clase que perime dibujar e implementar los botones correspondientes a seleccion de respuestas
@autor Santiago Cardozo Q
@autor Santiago Bedoya Ossa

 */
public class SeleccionarRespuesta : MonoBehaviour
{
  //Texto donde se guardara la opcion
  private Text texto = null;
  //Botones de las respuestas
  private Button boton = null;
  //Imagen de las respuestas
  private Image imagen = null;
  //Color original
  private Color colorOriginal = Color.black;

  //Se traen los datos de la clase opcion
  public Opcion Opcion {get;set;}

  /**
  Metodo que optiene los componentes de cada atributo
   */
   private void Awake(){
      
      boton = GetComponent<Button>();
      imagen = GetComponent<Image>();
      texto = transform.GetChild(0).GetComponent<Text>();
      //Se guarda el color otiginal
      colorOriginal = imagen.color;

  }
  /**
  Metodo que construye las respuestas
   */
  public void constructor(Opcion opcion ,Action<SeleccionarRespuesta> callback ){
      //se trae el texto de la opcion de respuesta
      texto.text = opcion.respuesta;
      //se habilita el boton
      boton.onClick.RemoveAllListeners();
      boton.enabled = true;
      //Se asigna el color original a la imagen
      imagen.color = colorOriginal;
      //se guarda lo que entre por pantalla en opcion
      Opcion = opcion;

      //Se crea el evento de cada opcion de respuesta
      boton.onClick.AddListener(delegate
    {
        callback(this);

      });

  }
  //Se obtiene el color del boton
  public void setColor(Color c){
      //se desactiva el boton
      boton.enabled = false;
      //se le asigna un color al boton desde la pantalla
      imagen.color = c;

  }
}
