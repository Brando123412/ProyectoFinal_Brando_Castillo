using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance {get; private set;}
    [SerializeField] MyGrafo myGrafo;
    [SerializeField] GameObject panelMenu;
    [SerializeField] SaveTropas saveTropasSO;
    [SerializeField] GameObject[] currentPositionsNodeStart;
    bool drop =true;
    private void Awake() {
        if(Instance != this && Instance != null){
            Destroy(this.gameObject);
        }
        Instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        //if(saveTropasSO);
        myGrafo.GraphOne();
        //myGrafo.GraphTwo();
        //myGrafo.GraphThree();*/
    }

    void Update()
    {
        
    }
    public void IrAMenu(){
        SceneManagerController.Instance.LoadScene("Menu");
    }
    public void Pause(){
        panelMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Regresar(){
        panelMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void OnLose(GameObject panel){
        SceneManagerController.Instance.CallFadeIn();
        StartCoroutine(Carga(panel));
    }
    public void OnWin(GameObject panel){
        SceneManagerController.Instance.CallFadeIn();
        StartCoroutine(Carga(panel));
    }
    private IEnumerator Carga(GameObject panel){
        yield return new WaitForSeconds(1);
        panel.SetActive(true);
    }
    public void DropTropa(){
        if(drop == true)
        {
            drop = false;
            StartCoroutine(DropTropCorutine());
        }
    }
    IEnumerator DropTropCorutine(){
        Unid tmpTropa= saveTropasSO.ReturmTropas();
        Debug.Log(tmpTropa);
        if(tmpTropa != null){ 
            Instantiate(tmpTropa.prefab, currentPositionsNodeStart[0].transform.position,transform.rotation).GetComponent<PlayerController>().GoToNode(myGrafo);
        }
        yield return new WaitForSecondsRealtime(2);
        drop = true;
    }
}
