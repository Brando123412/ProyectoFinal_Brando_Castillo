using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance {get; private set;}
    [SerializeField] MyGrafo myGrafo;
    [SerializeField] GameObject panelMenu;
    [SerializeField] SaveTropas saveTropasSO;
    [SerializeField] GameObject[] currentPositionsNodeStart;
    bool drop =true;
    int cantidadTropas;

    [SerializeField] InsertionSort savepuntaje;
    [SerializeField] Button buttonDrop;
    [SerializeField] Button buttonSiguiente;
    [SerializeField] GameObject[] paneles;
    [Header("TodoFase1")]
    [SerializeField] GameObject[] Fase1Objetos;
    [Header("TodoFase2")]
    [SerializeField] GameObject[] Fase2Objetos;
    [Header("TodoFase3")]
    [SerializeField] GameObject[] Fase3Objetos;
    [Header("Line Renderer")]
    [SerializeField] GameObject[] rendererLine;

    private void Awake() {
        if(Instance != this && Instance != null){
            Destroy(this.gameObject);
        }
        Instance = this;
        cantidadTropas=0;
    }

    void Start()
    {
        if(saveTropasSO.faseSelecction ==0){
            Fase1();
        }else if(saveTropasSO.faseSelecction ==1){
            Fase2();
        }else if(saveTropasSO.faseSelecction ==2){
            Fase3();
        }
    }
    public void SumarTropas(){
        cantidadTropas++;
    }
    public void IrAMenu(){
        SceneManagerController.Instance.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    public void Pause(){
        panelMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Regresar(){
        panelMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    void OnLose(){
        SceneManagerController.Instance.CallFadeIn();
        StartCoroutine(Carga(paneles[0],"Menu"));
    }
    void OnWin(){
        SceneManagerController.Instance.CallFadeIn();
        StartCoroutine(Carga(paneles[1],"TroopSelection"));
    }
    private IEnumerator Carga(GameObject panel,string Scena){
        yield return new WaitForSecondsRealtime(1);
        panel.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        SceneManagerController.Instance.LoadScene(Scena);

    }
    public void DropTropa(){
        if(drop == true)
        {
            drop = false;
            StartCoroutine(DropTropCorutine());
        }
        if(saveTropasSO.CountQueue()<= 0){
            buttonDrop.gameObject.SetActive(false);
            StartCoroutine(ReferenciaAlbottonsiguiente());
        }
    }
    IEnumerator DropTropCorutine(){
        GameObject tropa= new GameObject();
        Unid tmpTropa= saveTropasSO.ReturmTropas();
        tropa = tmpTropa.prefab;
        Debug.Log(tmpTropa);
        if(tmpTropa != null){ 
            Instantiate(tropa, currentPositionsNodeStart[saveTropasSO.faseSelecction].transform.position,transform.rotation).GetComponent<PlayerController>().GoToNode(myGrafo,saveTropasSO);
        }
        yield return new WaitForSecondsRealtime(2);
        drop = true;
    }
    public void VictoryCheck(){
        if(cantidadTropas>=5){
            if(saveTropasSO.faseSelecction <3){
                saveTropasSO.faseSelecction++;
            }else{
                saveTropasSO.faseSelecction=0;
            }
            if(saveTropasSO.faseSelecction==2){
                savepuntaje.SavePuntaje(savepuntaje.puntajeAcumulado);
                savepuntaje.puntajeAcumulado =0;
            }
            OnWin();
            savepuntaje.puntajeAcumulado=savepuntaje.puntajeAcumulado = cantidadTropas;
        }else{
            saveTropasSO.faseSelecction=0;
            OnLose();
            savepuntaje.SavePuntaje(savepuntaje.puntajeAcumulado);
            savepuntaje.puntajeAcumulado =0;
        }
    }
    IEnumerator ReferenciaAlbottonsiguiente(){
        yield return new WaitForSecondsRealtime(10);
        buttonSiguiente.gameObject.SetActive(true);
    }

    void Fase1(){
        myGrafo.GraphOne();
        for (int i = 0; i < Fase1Objetos.Length; i++)
        {
            Fase1Objetos[i].SetActive(true);
        }
        rendererLine[0].GetComponent<LineRendererTropaDerecha>().LineDerechaEtapa1();
        rendererLine[1].GetComponent<LineRendererTropaIzquierda>().LineIzquierdaEtapa1();
    }
    void Fase2(){
        myGrafo.GraphTwo();
        for (int i = 0; i < Fase3Objetos.Length; i++)
        {
            Fase2Objetos[i].SetActive(true);
        }
        rendererLine[0].GetComponent<LineRendererTropaDerecha>().LineDerechaEtapa2();
        rendererLine[1].GetComponent<LineRendererTropaIzquierda>().LineIzquierdaEtapa2();
    }
    void Fase3(){
        myGrafo.GraphThree();
        for (int i = 0; i < Fase2Objetos.Length; i++)
        {
            Fase3Objetos[i].SetActive(true);
        }
        rendererLine[0].GetComponent<LineRendererTropaDerecha>().LineDerechaEtapa3();
        rendererLine[1].GetComponent<LineRendererTropaIzquierda>().LineIzquierdaEtapa3();
        rendererLine[2].GetComponent<LineRendererTropaMedio>().LineMedioEtapa3();
    }
    
}
