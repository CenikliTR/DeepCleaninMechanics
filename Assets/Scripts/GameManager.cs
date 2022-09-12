using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{

    [SerializeField] GameObject heldVacuum, waterVacuum;
    [SerializeField] GameObject cheeseChilds;
    public GameObject playObject;
    public bool ýsPlay;
    [SerializeField] GameObject text;
    [SerializeField] GameObject particle;
    public enum Mode
    {
        Heldvacum,
        WaterVacum,
        Completed
    }

    public Mode mode;
    void Awake()
    {
        mode = Mode.Heldvacum;

    }
    void Start()
    {
        cheeseChilds = GetComponent<GameObject>();
        ýsPlay = true;
        
    }

    void Update()
    {
        PlayMode();
        ModeCheck();

    }

    void ModeCheck()
    {
        if (cheeseChilds == null)
        {
            cheeseChilds = GameObject.Find("Cheese");
        }

        if (cheeseChilds.transform.childCount==0)
        {
            mode = Mode.WaterVacum;
        }
        if (Dirt_Cleaning.Instance.clean == true)
        {
            mode = Mode.Completed;
        }
   
    }



    void PlayMode()
    {
        switch (mode)
        {
            case Mode.Heldvacum:
                if (playObject == null)
                    playObject = heldVacuum;
                waterVacuum.SetActive(false);
                ControllSystem.Instance.ofset =0.4f;
                break;
            case Mode.WaterVacum:
                if (playObject != null)
                    playObject = waterVacuum;
                heldVacuum.SetActive(false);
                waterVacuum.SetActive(true);
                Dirt_Cleaning.Instance.CleanDirt();

                break;
            case Mode.Completed:
                text.SetActive(true);
                particle.SetActive(true);
                ýsPlay = false;
                break;

        }

    }
}
