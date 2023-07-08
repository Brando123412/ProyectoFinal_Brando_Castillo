using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuPrincipal : MonoBehaviour {
    [SerializeField] Soundscriptableobjects sound;
    public GameObject Settings;
    public GameObject Score;

    [Header("SOtart")]
    [SerializeField] Button[] muteButton;
    [SerializeField] Slider[] sliderButton;
    [SerializeField] ChannelManager[] SOChanelManager;
    [SerializeField] TMP_Text[] textoVolumen; 
    public bool startbool;
    void Awake(){
        startbool=true;
    }
    void Start(){
        SOManager();
    }
    public void Exit()
    {
        sound.CreateSound();
        Application.Quit();
    }
    
    public void LoadTroopSelection() { 
        sound.CreateSound();
        SceneManagerController.Instance.LoadScene("TroopSelection");
    }

    public void SettingsButoon()
    {
        sound.CreateSound();
        Settings.SetActive(true);
    }

    public void Atras()
    {
        sound.CreateSound();
        Settings.SetActive(false);
    }
    public void ScoreButoon()
    {
        sound.CreateSound();
        Score.SetActive(true);
    }

    public void ScoreAtras()
    {
        sound.CreateSound();
        Score.SetActive(false);
    }
    public void SOManager(){

        //Parte button
        for (int i = 0; i < muteButton.Length; i++)
        {
            print(SOChanelManager[i].isMuted);
            if(SOChanelManager[i].isMuted ==true){
                muteButton[i].image.sprite = SOChanelManager[i].buttonMute[0];
                
            }else{
                muteButton[i].image.sprite = SOChanelManager[i].buttonMute[1];
            }
        }
        //Parte Texto
        SOChanelManager[0].Inicio(startbool);
        textoVolumen[0].text= SOChanelManager[0].valueVolume.ToString();
        SOChanelManager[1].Inicio(startbool);
        textoVolumen[1].text= SOChanelManager[1].valueVolume.ToString();
        SOChanelManager[2].Inicio(startbool);
        textoVolumen[2].text= SOChanelManager[2].valueVolume.ToString();

        
        sliderButton[0].value=SOChanelManager[0].currentVolume;
        sliderButton[1].value=SOChanelManager[1].currentVolume;
        sliderButton[2].value=SOChanelManager[2].currentVolume;
    }
}
