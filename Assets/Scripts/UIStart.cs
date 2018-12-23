using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIStart : MonoBehaviour {

    private Button btn_Audio;
    private Button btn_Start;
    private AudioSource audio_BG;
    
    //used to store Btn_Audio Images
    public Sprite[] btn_Audio_Sprites;
    private Image img_Btn_Audio;

    // Use this for initialization
    void Start () {

        loadComponents();

    }
	

    void OnDestroy()
    {
        btn_Start.onClick.RemoveListener(loadLevel);
        btn_Audio.onClick.RemoveListener(changeAudio);
    }
    // load all UI components
    void loadComponents()
    {
        btn_Start = transform.Find("btn_Start").GetComponent<Button>();
        btn_Audio = transform.Find("btn_Audio").GetComponent<Button>();

        audio_BG = transform.Find("btn_Audio").GetComponent<AudioSource>();
        img_Btn_Audio = transform.Find("btn_Audio").GetComponent<Image>();

        //attach click events to buttons
        btn_Start.onClick.AddListener(loadLevel);
        btn_Audio.onClick.AddListener(changeAudio);

    }

    void loadLevel()
    {
        SceneManager.LoadScene(1);
    }
    void changeAudio()
    {
  
        if (audio_BG.isPlaying)
        {
            audio_BG.Pause();
            img_Btn_Audio.sprite = btn_Audio_Sprites[1];
        }
        else
        {
            audio_BG.Play();
            img_Btn_Audio.sprite = btn_Audio_Sprites[0];
        }
    }
}
