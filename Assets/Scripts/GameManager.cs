using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Time Manager")]
    [SerializeField] GameObject timeManager;
    [SerializeField] public bool _IsStarted;
    [Header("Score")]
    [SerializeField]public  int scoreCount;

    [Header("ElectionControll")]
    [SerializeField] public bool[] _BoolPool;

    [TextArea]
    [SerializeField] string BoolPoolReferences;
    [SerializeField] public bool _IsElected;
    [SerializeField] public bool _IsMixed;

    [Header("--Variables Serializadas--")]
    [SerializeField] GameObject[] _panels;
    private void Awake()
    {
        // ----------------------------------------------------------------
        // AQUÍ ES DONDE SE DEFINE EL COMPORTAMIENTO DE LA CLASE SINGLETON
        // Garantizamos que solo exista una instancia del AudioManager
        // Si no hay instancias previas se asigna la actual
        // Si hay instancias se destruye la nueva
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void win()
    {

    }

    public void startGame()
    {
        if (!_IsStarted)
        {
            timeManager = GameObject.FindWithTag("TimeManager");
            _IsStarted = true;
            timeManager.GetComponent<TimeManager>().StartCoroutine("UpdateTotalTimer");
            timeManager.GetComponent<TimeManager>().StartCoroutine("UpdateQuestionTimer");
        }
    }

    public void failQuestion()
    {
        timeManager.GetComponent<TimeManager>()._IsAnswered = true;
        scoreCount -= 20;

        timeManager.GetComponent<TimeManager>().restartQuestion();
    }
    public void accertQuestion()
    {
       
        timeManager.GetComponent<TimeManager>()._IsAnswered = true;
        scoreCount += 10;
        timeManager.GetComponent<TimeManager>().restartQuestion();
    }

    public void endOfGame()
    {
        Time.timeScale = 0f;
    }

    
    public void electQuestion()
    {
        if (_IsMixed)
        {
            while (!_IsElected)
            {
                switch (Random.Range(0, 5))
                {
                    case 0:
                        if (_BoolPool[0]) DictionaryManager.instance.PlaySums(); _IsElected = true;
                        break;
                    case 1:
                        if (_BoolPool[1]) DictionaryManager.instance.PlaySubsttacts(); _IsElected = true;
                        break;
                    case 2:
                        if (_BoolPool[2]) DictionaryManager.instance.PlayMultiplies(); _IsElected = true;
                        break;
                    case 3:
                        if (_BoolPool[3]) DictionaryManager.instance.PlayDivides(); _IsElected = true;
                        break;
                    case 4:
                        if (_BoolPool[4]) DictionaryManager.instance.PlayEcuations(); _IsElected = true;
                        break;
                }
            }
        }
        else {
            for (int i = 0; i < _BoolPool.Length; i++)
            {
                if(_BoolPool[i] == true)
                {
                    DictionaryManager.instance.electSectionSimple(i);
                    break;
                };

            }
            }
    }


    public void boolController(int selected)
    {
        for(int i= 0;i<_BoolPool.Length;i++)
        {
            if(selected == i)
            {
                _BoolPool[i] = true;
            }
            else
            {
                _BoolPool[i] = false;
            }

        }

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
