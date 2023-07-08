using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChancetoImage : MonoBehaviour
{
    public Sprite[] imagenes; 
    float tiempoEntreImagenes = 5f; 
    float tiempoTransicion = 2f; 
    public Image imagen;
    private int indiceActual = 0;

    private void Start()
    {
        imagen.sprite = imagenes[indiceActual]; 
        StartCoroutine(CambiarImagenCoroutine());
    }

    private IEnumerator CambiarImagenCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoEntreImagenes);

            StartCoroutine(TransicionOpacidad(0f)); 

            yield return new WaitForSeconds(tiempoTransicion);

            CambiarImagen(); 

            StartCoroutine(TransicionOpacidad(1f)); 
        }
    }

    private void CambiarImagen()
    {
        indiceActual = (indiceActual + 1) % imagenes.Length; 
        imagen.sprite = imagenes[indiceActual]; 
    }

    private IEnumerator TransicionOpacidad(float objetivo)
    {
        Color colorInicial = imagen.color;
        Color colorObjetivo = new Color(colorInicial.r, colorInicial.g, colorInicial.b, objetivo);

        float tiempoPasado = 0f;

        while (tiempoPasado < tiempoTransicion)
        {
            float t = tiempoPasado / tiempoTransicion;
            imagen.color = Color.Lerp(colorInicial, colorObjetivo, t);

            tiempoPasado += Time.deltaTime;
            yield return null;
        }

        imagen.color = colorObjetivo;
    }
}
