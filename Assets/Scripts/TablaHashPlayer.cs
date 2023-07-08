using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TablaHashPlayer : MonoBehaviour
{
    [Header("Para lista")]
    
    [SerializeField] Button[] imagenButoonList;
    public SimplyLinkList<Unid> listaGO;
    //////////////////////////////////////////
    [Header("Para Hash")]
    Unid objetoHash;
    [SerializeField] Button imagenButoonHash;
    MyTablaHash<Unid> myHash;
    public string[] tropasKeyHash;
    public Unid[] tropasPrefabHash;
    public SimplyLinkList<Unid> saveTropas;
    //Pruebas
    public int cantidadObjets = 5;
    public List<GameObject> listPrueba;
    void Awake(){
        myHash = new MyTablaHash<Unid>();
        listaGO = new SimplyLinkList<Unid>();
        saveTropas = new SimplyLinkList<Unid>();
        myHash.HashFunction();
        for (int i = 0; i < tropasKeyHash.Length; i++)
        {
            listaGO.AddNodeAtEnd(tropasPrefabHash[i]);
            myHash.Insertar(tropasKeyHash[i],tropasPrefabHash[i]);
        }
        for (int i = 0; i < listaGO.Count; i++)
        {
            imagenButoonList[i].image.sprite =listaGO.GetNodeAtPosition(i).imagen;
        }

        imagenButoonHash.enabled=false;
    }
    void Start(){
        myHash.PrintAllDate();
    }
    public void SetInputText(string codeKey){
        objetoHash=myHash.Buscar(codeKey);
        if(objetoHash != null){
            imagenButoonHash.enabled=true;
            imagenButoonHash.image.sprite=objetoHash.imagen;
            imagenButoonHash.image.color= new Color(1,1,1,1);
        }else{
            imagenButoonHash.enabled=false;
            imagenButoonHash.image.color= new Color(0,0,0,0);
        }
    }
    public void InsertarListHash(){
        if(cantidadObjets>saveTropas.Count){
            saveTropas.AddNodeAtEnd(objetoHash);
            listPrueba.Add(objetoHash.prefab);
        }
    }
    public void InsertarListList(int positionlocal){
        if(cantidadObjets>saveTropas.Count){
            saveTropas.AddNodeAtEnd(listaGO.GetNodeAtPosition(positionlocal));
            listPrueba.Add(listaGO.GetNodeAtPosition(positionlocal).prefab);
        }
    }
}
