using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{

    private CanvasGroup cg;
    [SerializeField] private Button bag;
    [SerializeField] private Button Party;
    [SerializeField] private Button Abilities;
    [SerializeField] private Button Save;
    private bool MenuShowCheck;

    // Start is called before the first frame update
    void Start()
    {
        if (!bag)
        {
            bag = GameObject.Find("Bag_Button").GetComponent<Button>();
        }
        if (!Party)
        {
            bag = GameObject.Find("Party_Button").GetComponent<Button>();
        }
        if (!Abilities)
        {
            bag = GameObject.Find("Abilities_Button").GetComponent<Button>();
        }
        if (!Save)
        {
            bag = GameObject.Find("Save_Button").GetComponent<Button>();
        }

        cg = GetComponent<CanvasGroup>();
        cg.alpha = 0.0f;

        
        cg.blocksRaycasts = false;
        MenuShowCheck = false;


        bag.interactable = false;
        Party.interactable = false;
        Abilities.interactable = false;
        Save.interactable = false;

        bag.onClick.AddListener(BagOpen);
        Party.onClick.AddListener(PartyMenu);
        Abilities.onClick.AddListener(AbilitiesMenu);
        Save.onClick.AddListener(SaveMenu);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.M) && MenuShowCheck == false)
        {
            MenuShow();
           
        }
        else if (Input.GetKeyDown(KeyCode.M) && MenuShowCheck == true)
        {
            MenuDontShow();
        }

    }

    void MenuShow()
    {
        MenuShowCheck = true;
        cg.alpha = 1.0f;
        cg.blocksRaycasts = true;


        bag.interactable = true;
        Party.interactable = true;
        Abilities.interactable = true;
        Save.interactable = true;

    }

    void MenuDontShow()
    {
        MenuShowCheck = false;
        cg.alpha = 0.0f;
        cg.blocksRaycasts = false;

        bag.interactable = false;
        Party.interactable = false;
        Abilities.interactable = false;
        Save.interactable = false;
    }

    void BagOpen()
    {
        Debug.Log("Bag Open");
    }

    void PartyMenu()
    {
        Debug.Log("Party Menu");
    }

    void AbilitiesMenu()
    {
        Debug.Log("Abilities Menu");
    }

    void SaveMenu()
    {
        Debug.Log("Save Menu");
    }

}
