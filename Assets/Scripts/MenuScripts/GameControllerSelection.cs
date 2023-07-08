using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerSelection : MonoBehaviour
{
    [SerializeField] Soundscriptableobjects sound;
    [SerializeField] SaveTropas SOTropas;
    [SerializeField] TablaHashPlayer tablaGet;
    [SerializeField] Image[] imageReferences;
    int current;
    //public Queue<GameObject> prueba= new Queue<GameObject>();

    void Awake(){
        current=0;
        //SOTropas.InicializacionCola();
        //prueba.Enqueue(new GameObject());
    }
    public void Juego()
    {
        sound.CreateSound();
        SOTropas.SaveTropasQueque(tablaGet.saveTropas);
        SceneManagerController.Instance.LoadScene("ScenarioJuego");
    }
    public void Menu()
    {
        sound.CreateSound();
        SceneManagerController.Instance.LoadScene("Menu");
    }
    public void ReferencesImage(){
        if(current<24){
            imageReferences[current].color = new Color(1,1,1,1);
            imageReferences[current].sprite = tablaGet.saveTropas.GetNodeAtEnd().imagen;
        current++;
        }
    }
    public void DeleteReferencesImage(){
        if(current>0){
            current--;
            imageReferences[current].sprite = null;
            imageReferences[current].color = new Color(0,0,0,0);
            tablaGet.saveTropas.RemoveAtEnd();
            tablaGet.listPrueba.RemoveAt(current);
        }
    }
}
