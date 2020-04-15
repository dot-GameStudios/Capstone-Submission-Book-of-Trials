using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackStream_UI : MonoBehaviour
{
    public List<Attack_Card> Attacks;
    public List<Attack_Card> Queued;
    //public bool drainMana;

    [Header ("Queue")]
    [SerializeField] private GameObject QueueImage1;
    [SerializeField] private GameObject QueueImage2;
    [SerializeField] private GameObject QueueImage3;
    [SerializeField] private Attack_Card TopQueue;
    private Attack_Card tmp;
    [SerializeField] public Text QueueName;
    [SerializeField] public Text movetext;
    [SerializeField] public Text QueueData;
    [SerializeField] public Text QueuedCount;

    [Header("Stream")]
    [SerializeField] private Text streamName;
    [SerializeField] private Text streamData;
    [SerializeField] private Text streamData2;
    [SerializeField] private Text BotstreamName;
    [SerializeField] private Attack_Card TopStream;
    [SerializeField] private Attack_Card BottomStream;

    private int CurrentAttackTick;
    private string elementType;
    private bool displayingAttack;
    private bool attacklock;

    [Header("Camera")]
    [SerializeField] private CameraController camControl;
    public Text advantage;
    public Text counter;


    [Header("Images")]
    public RawImage topImage;
    public RawImage bottomImage;
    public RawImage queue1;
    public RawImage queue2;
    public RawImage queue3;




    // Start is called before the first frame update
    void Start()
    {
        TopStream = Attacks[Random.Range(0, Attacks.Count)];
        BottomStream = Attacks[Random.Range(0, Attacks.Count)];

        QueueImage1.SetActive(false);
        QueueImage2.SetActive(false);
        QueueImage3.SetActive(false);
        displayingAttack = false;
        //attacklock = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (pausemenu.paused == false)
        {
            //handling the actual queue/stream logic
            if (attacklock == false && combatLogic.attacklock == false)
            {
                if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button5)) && Queued.Count <= 9)
                { //queue
                    if (combatLogic.mana >= TopStream.ManaCost)
                    {
                        AddtoQueue();
                    }
                }
                //if (Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.Joystick1Button0))
                //{ //swap
                //    SwapStream();
                //}
                if (Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.Joystick1Button3))
                { //remove from stream
                    RemoveStream();
                }
                if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button1)) && Queued.Count > 0)
                { //remove from queue
                    RemoveQueue();
                }
            }
            //for when attacks are triggered, reseting information
            //timer counts upto when information should be reset

            if (displayingAttack) { CurrentAttackTick++; }
            if (CurrentAttackTick >= 40)
            {
                displayingAttack = false;
                movetext.text = "";
                camControl.SetStart();
                attacklock = false;
                combatLogic.playerLock = false;
            }
            //the display of the queued images
            if (Queued.Count >= 1) { QueueImage1.SetActive(true); queue1.texture = Queued[0].attackImage; }
            else { QueueImage1.SetActive(false); }
            if (Queued.Count >= 2) { QueueImage2.SetActive(true); queue2.texture = Queued[1].attackImage; }
            else { QueueImage2.SetActive(false); }
            if (Queued.Count >= 3) { QueueImage3.SetActive(true); queue3.texture = Queued[2].attackImage; }
            else { QueueImage3.SetActive(false); }

            //stream visual
            BotstreamName.text = BottomStream.AttackName;
            streamName.text = TopStream.AttackName;
            streamData.text = elementCheck(TopStream.AttackElement);
            streamData2.text = "Dmg: " + TopStream.BaseDmg + " Cst: " + TopStream.ManaCost;

            //queue visual
            if (Queued.Count >= 1)
            {
                QueueName.text = TopQueue.AttackName;
                QueueData.text = elementCheck(TopQueue.AttackElement) + " Dmg: " + TopQueue.BaseDmg;
                QueuedCount.text = Queued.Count + "/10";
            }
            else
            {
                QueuedCount.text = "";
                QueueName.text = "";
                QueueData.text = "";
            }

            if (combatLogic.advantage == true)
            {
                advantage.text = "ADVANTAGE!";
                combatLogic.advantagetime++;
                if (combatLogic.advantagetime >= 40) { combatLogic.advantage = false; advantage.text = ""; }
            }

            if (combatLogic.counter == true)
            {
                counter.text = "COUNTER!";
                combatLogic.countertime++;
                if (combatLogic.countertime >= 200) { combatLogic.counter = false; counter.text = ""; }
                if (combatLogic.countertime<=1) { bonusAdd(); }
            }

            topImage.texture = TopStream.attackImage;
            bottomImage.texture = BottomStream.attackImage;




        }
    }
    void AddtoQueue()
    {
        if (combatLogic.playerManaLoss) { combatLogic.mana -= TopStream.ManaCost; }
        Queued.Add(TopStream);
        TopStream = BottomStream;
        BottomStream = Attacks[Random.Range(0, Attacks.Count)];
        TopQueue = Queued[0];
    }

    void bonusAdd()
    {
        Queued.Add(Attacks[Random.Range(0, Attacks.Count)]);
        TopQueue = Queued[0];
    }

    void SwapStream()
    {
        tmp = TopStream;
        TopStream = BottomStream;
        BottomStream = tmp;
    }

    void RemoveStream()
    {
        TopStream = BottomStream;
        BottomStream = Attacks[Random.Range(0, Attacks.Count)];
        combatLogic.mana -= 20;
    }

    void RemoveQueue()
    {
        movetext.text = Queued[0].AttackName;
        combatLogic.AttackID = Queued[0].AttackID;
        if (Queued.Count >= 2)
        {
            if (Queued[1].AttackID == 6)
            {
                Queued[0].BaseDmg += 10; Queued.RemoveAt(1);
            }
        }
        //
        combatLogic.CurrentDamage = Queued[0].BaseDmg;
        combatLogic.CurrentElement = Queued[0].AttackElement;
        if (combatLogic.targeting)
        {
            camControl.SwitchCamera(Queued[0].cameraNum);
        }

        displayingAttack = true;
        CurrentAttackTick = 0;
        attacklock = true;
        combatLogic.attackCheck -= 1;
        combatLogic.playerLock = true;

        Queued.RemoveAt(0);
        TopQueue = Queued[0];

    }

    string elementCheck(int value)
    {
        switch (value)
        {
            case 0:
                elementType = "None";
                break;
            case 1:
                elementType = "Fre";
                break;
            case 2:
                elementType = "Wtr";
                break;
            case 3:
                elementType = "Erth";
                break;
            case 4:
                elementType = "Wnd";
                break;
            case 5:
                elementType = "Ice";
                break;
            case 6:
                elementType = "Lghtng";
                break;
        }
        return elementType;
    }
}
