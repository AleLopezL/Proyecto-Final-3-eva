using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using UnityEngine.UI;

public class MenuInteraction : MonoBehaviour,
    IMixedRealityInputActionHandler,
    IMixedRealityFocusHandler
{
    private bool isFocused = false;
    [Header("--Variables Serializadas--")]
    [SerializeField] GameObject[] _panels;
    private void OnEnable()
    {
        CoreServices.InputSystem.RegisterHandler<IMixedRealityInputActionHandler>(this);
        CoreServices.InputSystem.RegisterHandler<IMixedRealityFocusHandler>(this);
    }
    private void Start()
    {
        PanelsToFalse();
        PanelActive(0);

    }

    private void OnDisable()
    {
        CoreServices.InputSystem.RegisterHandler<IMixedRealityInputActionHandler>(this);
        CoreServices.InputSystem.RegisterHandler<IMixedRealityFocusHandler>(this);
    }

    void IMixedRealityInputActionHandler.OnActionStarted(BaseInputEventData eventData)
    {
        if (!isFocused)
        {
            return;
        }

        else if (eventData.MixedRealityInputAction.Description == "Select")
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
                        break;
                    case "Restas":
                        GameManager.instance.boolController(1);
                        AudioManager.instance.PlaySFX("Play");
                        SCManager.instance.LoadScene("GameScene");
                        break;
                    case "Multiplicar":
                        GameManager.instance.boolController(2);
                        AudioManager.instance.PlaySFX("Play");
                        SCManager.instance.LoadScene("GameScene");
                        break;
                    case "Dividir":
                        GameManager.instance.boolController(3);
                        AudioManager.instance.PlaySFX("Play");
                        SCManager.instance.LoadScene("GameScene");
                        break;
                    case "Ecuaciones":
                        GameManager.instance.boolController(4);
                        AudioManager.instance.PlaySFX("Play");
                        SCManager.instance.LoadScene("GameScene");
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
                        break;
                    case "Multiply":
                        break;
                    case "Divide":
                        break;
                    case "Equations":
                        break;
                    case "Play":
                        break;
                }
            }
            else if (this.gameObject.layer == LayerMask.NameToLayer("Screen3"))
            {
                switch (compareName)
                {
                    case "Back":
                        break;
                    case "On/Off":
                        break;
                    case "Slider":
                        break;
                    case "Save":
                        break;
                }
            }

        }
    }

    void IMixedRealityInputActionHandler.OnActionEnded(BaseInputEventData eventData) { }

    void IMixedRealityFocusHandler.OnFocusEnter(FocusEventData eventData)
    {
        isFocused = eventData.NewFocusedObject.GetHashCode() == gameObject.GetHashCode();
    }

    void IMixedRealityFocusHandler.OnFocusExit(FocusEventData eventData)
    {
        isFocused = false;
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
