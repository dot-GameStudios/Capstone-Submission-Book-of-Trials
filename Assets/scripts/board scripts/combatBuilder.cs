using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class combatBuilder : MonoBehaviour
{
    public Dropdown enemyNumberSelect;
    public GameObject enemyBuilder2;
    public GameObject enemyBuilder3;

    public Dropdown enemy1ID;
    public Dropdown enemy2ID;
    public Dropdown enemy3ID;

    public Slider enemy1x;
    public Slider enemy1y;
    public Slider enemy2x;
    public Slider enemy2y;
    public Slider enemy3x;
    public Slider enemy3y;

    public Toggle exit;
    public Toggle regen;
    public Toggle drainMana;
    public Toggle dorank;
    public Toggle camDefault;

    public Slider time;
    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        enemyBuilder2.SetActive(false);
        enemyBuilder3.SetActive(false);
        combatLogic.dummyRegen = false;
        combatLogic.goToOverworld = false;
        combatLogic.exit = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyNumberSelect.value == 0)
        {
            enemyBuilder2.SetActive(false);
            enemyBuilder3.SetActive(false);
        }
        else if (enemyNumberSelect.value == 1)
        {
            enemyBuilder3.SetActive(false);
            enemyBuilder2.SetActive(true);
        }
        else if (enemyNumberSelect.value == 2)
        {
            enemyBuilder3.SetActive(true);
            enemyBuilder2.SetActive(true);
        }

        combatLogic.enemy1ID = enemy1ID.value;
        combatLogic.enemy2ID = enemy2ID.value;
        combatLogic.enemy3ID = enemy3ID.value;

        combatLogic.enemy1x = (int)enemy1x.value;
        combatLogic.enemy1y = (int)enemy1y.value;
        combatLogic.enemy2x = (int)enemy2x.value;
        combatLogic.enemy2y = (int)enemy2y.value;
        combatLogic.enemy3x = (int)enemy3x.value;
        combatLogic.enemy3y = (int)enemy3y.value;

        combatLogic.numberOfEnemies = enemyNumberSelect.value+1;

        combatLogic.dummyRegen = regen.isOn;
        combatLogic.exit = exit.isOn;
        combatLogic.playerManaLoss = drainMana.isOn;
        combatLogic.DoRank = dorank.isOn;
        combatLogic.maxtime = (int)time.value;
        combatLogic.defaultcam = camDefault.isOn;

        timeText.text = ""+time.value+"sec";

        if (Input.GetKeyDown(KeyCode.E) ||Input.GetKeyDown(KeyCode.Joystick1Button1)) { SceneManager.LoadScene("Combat", LoadSceneMode.Single); }
    }
}
