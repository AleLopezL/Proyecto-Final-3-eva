using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MenuInteraction : MonoBehaviour,
    IMixedRealityInputActionHandler,
    IMixedRealityFocusHandler
{
    private bool isFocused = false;
    [Header("--Variables Serializadas--")]
    [SerializeField] GameObject[] _panels;

    private void Start()
    {
        PanelsToFalse();
        PanelActive(0);
        float savedVolume = PlayerPrefs.GetFloat("MainMusic",0.5f);
        int savedMute = PlayerPrefs.GetInt("MainMusicMute", 0);

        if (this.gameObject.layer == LayerMask.NameToLayer("Screen3")&& this.gameObject.name  == "On/Off")
        {
            this.gameObject.GetComponent<Toggle>().isOn = (savedMute == 1);
            AudioManager.instance.musicSource.GetComponent<AudioSource>().mute = !(savedMute == 1);
        }

        if (this.gameObject.layer == LayerMask.NameToLayer("Screen3") && this.gameObject.name == "Slider")
        {
            this.gameObject.GetComponent<Slider>().value  = savedVolume;
            AudioManager.instance.musicSource.GetComponent<AudioSource>().volume = savedVolume;
        }

    }

    void IMixedRealityInputActionHandler.OnActionStarted(BaseInputEventData eventData)
    {
        if (eventData.MixedRealityInputAction.Description == "Select")
        {
           string compareName= this.gameObject.name;
               if(this.gameObject.layer == LayerMask.NameToLayer("Screen1")){

                switch (compareName)
                {
                    case "Play": 
                        PanelActive(1);
                        AudioManager.instance.PlaySFX("Button");
                        break;
                    case "Multiplayer":
                        AudioManager.instance.PlaySFX("Play"); 
                        SCManager.instance.LoadScene("MultiplayerScene");
                        
                        break;
                    case "Settings":
                        PanelActive(3);
                        AudioManager.instance.PlaySFX("Button");
                        break;
                    case "Exit":
                        AudioManager.instance.PlaySFX("Exit");
                        Application.Quit();
                        break;

                }

            }
               else if  (this.gameObject.layer == LayerMask.NameToLayer("Screen1.1"))
            {
                switch (compareName)
                {
                    case "Back":
                        PanelActive(0);
                        AudioManager.instance.PlaySFX("Play");
                        break;
                    case "Sumas": GameManager.instance.boolController(0);
                        AudioManager.instance.PlaySFX("Play");
                        SCManager.instance.LoadScene("GameScene");
                        GameManager.instance.electQuestion();
                        break;
                    case "Restas":
                        GameManager.instance.boolController(1);
                        AudioManager.instance.PlaySFX("Play");
                        SCManager.instance.LoadScene("GameScene");
                        GameManager.instance.electQuestion();
                        break;
                    case "Multiplicar":
                        GameManager.instance.boolController(2);
                        AudioManager.instance.PlaySFX("Play");
                        SCManager.instance.LoadScene("GameScene");
                        GameManager.instance.electQuestion();
                        break;
                    case "Dividir":
                        GameManager.instance.boolController(3);
                        AudioManager.instance.PlaySFX("Play");
                        SCManager.instance.LoadScene("GameScene");
                        GameManager.instance.electQuestion();
                        break;
                    case "Ecuaciones":
                        GameManager.instance.boolController(4);
                        
                        AudioManager.instance.PlaySFX("Play");
                        SCManager.instance.LoadScene("GameScene");
                        GameManager.instance.electQuestion();
                        break;
                    case "Mixtos":
                        PanelActive(2);
                        AudioManager.instance.PlaySFX("Button");
                        break;

                }
            }
            else if (this.gameObject.layer == LayerMask.NameToLayer("Screen1.1.1"))
            {
                switch (compareName)
                {
                    case "Back":
                        PanelActive(1);
                        AudioManager.instance.PlaySFX("Button");
                        break;
                    case "Add":  
                        if (this.gameObject.GetComponent<Toggle>().isOn)
                        {
                            this.gameObject.GetComponent<Toggle>().isOn = false;
                            GameManager.instance._BoolPool[0] = false;
                        }
                        else
                        {
                            AudioManager.instance.PlaySFX("Toogle");
                            GameManager.instance._BoolPool[0] = true;
                        }
                        
                        break;
                    case "Substract":
                        if (this.gameObject.GetComponent<Toggle>().isOn)
                        {
                            AudioManager.instance.PlaySFX("Toogle");
                            this.gameObject.GetComponent<Toggle>().isOn = false;
                            GameManager.instance._BoolPool[1] = false;
                        }
                        else
                        {
                            this.gameObject.GetComponent<Toggle>().isOn = true;
                            AudioManager.instance.PlaySFX("Toogle");
                            GameManager.instance._BoolPool[1] = true;
                        }
                        break;
                    case "Multiply":
                        if (this.gameObject.GetComponent<Toggle>().isOn)
                        {
                            this.gameObject.GetComponent<Toggle>().isOn = false;
                            GameManager.instance._BoolPool[2] = false;
                        }
                        else
                        {
                            this.gameObject.GetComponent<Toggle>().isOn = true;
                            AudioManager.instance.PlaySFX("Toogle");
                            GameManager.instance._BoolPool[2] = true;
                        }
                        break;
                    case "Divide":
                        if (this.gameObject.GetComponent<Toggle>().isOn)
                        {
                            AudioManager.instance.PlaySFX("Toogle");
                            this.gameObject.GetComponent<Toggle>().isOn = false;
                            GameManager.instance._BoolPool[3] = false;
                        }
                        else
                        {
                            this.gameObject.GetComponent<Toggle>().isOn = true;
                            AudioManager.instance.PlaySFX("Toogle");
                            GameManager.instance._BoolPool[3] = true;
                        }
                        break;
                    case "Equations":
                        if (this.gameObject.GetComponent<Toggle>().isOn)
                        {
                            AudioManager.instance.PlaySFX("Toogle");
                            this.gameObject.GetComponent<Toggle>().isOn = false;
                            GameManager.instance._BoolPool[4] = false;
                        }
                        else
                        {
                            this.gameObject.GetComponent<Toggle>().isOn = true;
                            AudioManager.instance.PlaySFX("Toogle");
                            GameManager.instance._BoolPool[4] = true;
                        }
                        break;
                    case "Play":
                        AudioManager.instance.PlaySFX("Play");
                        GameManager.instance._IsMixed = true;
                        SCManager.instance.LoadScene("MainGame");
                        GameManager.instance.electQuestion();
                        break;
                }
            }
            else if (this.gameObject.layer == LayerMask.NameToLayer("Screen3"))
            {
                switch (compareName)
                {
                    case "Back":
                        PanelActive(1);
                        AudioManager.instance.PlaySFX("Button");
                        break;
                    case "On/Off":
                        if (this.gameObject.GetComponent<Toggle>().isOn)
                        {
                            AudioManager.instance.PlaySFX("Toogle");
                            AudioManager.instance.musicSource.GetComponent<AudioSource>().mute = false;
                            this.gameObject.GetComponent<Toggle>().isOn = false;
                            PlayerPrefs.SetInt("BackgroundMusicMute", 0);
                        }
                        else
                        {
                            AudioManager.instance.PlaySFX("Toogle");
                            this.gameObject.GetComponent<Toggle>().isOn = true; 
                            AudioManager.instance.musicSource.GetComponent<AudioSource>().mute = true;
                            PlayerPrefs.SetInt("BackgroundMusicMute", 1);
                        }
                        
                        break;
                    case "Slider":
                        AudioManager.instance.musicSource.GetComponent<AudioSource>().volume = this.gameObject.GetComponent<Slider>().value;
                        PlayerPrefs.SetFloat("MainMusic",AudioManager.instance.musicSource.GetComponent<AudioSource>().volume);
                        break;
                    case "Save":
                        PlayerPrefs.Save();
                        break;
                }
            }

        }
    }

    void IMixedRealityInputActionHandler.OnActionEnded(BaseInputEventData eventData) { }

    void IMixedRealityFocusHandler.OnFocusEnter(FocusEventData eventData)
    {
       // isFocused = eventData.NewFocusedObject.GetHashCode() == gameObject.GetHashCode();
    }

    void IMixedRealityFocusHandler.OnFocusExit(FocusEventData eventData)
    {
      //  isFocused = false;
    }


    public void PanelActive(int number)
    {

        PanelsToFalse();
        _panels[number].SetActive(true);

    }

    public void PanelsToFalse()
    {
        foreach (GameObject panel in _panels)
        {
            panel.SetActive(false);
        }
    }
}
