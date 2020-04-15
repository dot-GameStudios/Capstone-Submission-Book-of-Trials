using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class combatLogic
{
    //annoying amount of static variables i know but it saves on confusion as many of theses vars need to be used between scenes and between multiple gameobjects and logic centres

    // Start is called before the first frame update
    public static int combatOrientation = 1;
    public static bool targeting = false;
    public static int camNum;
    public static int enemyNumber;

    //this is the current turn that all turnbased entities are on
    public static int turnCount;
    public static int turnwait;
    //decided when entities spawned that this is the max amount of turns that can occur
   // public static int maxturn;
    public static int AttackID;
    public static int target;
    public static int CurrentDamage;
    public static int CurrentElement;

    //communicates between all the scripts that needs to be paused
    public static bool paused;

    //communicates the mana amount between the loss per card and the ui element
    public static float mana;
    //stops the player moving when attacking. communicates between attackstream, and playerstats
    public static bool playerLock;
    //allows for movement but not attacking
    public static bool attacklock = false;

    //experiementing with detecting when entities are killed in combat
    public static bool E1Live = false;
    public static bool E2Live = false;
    public static bool E3Live = false;

    public static bool playerLive = true;

    //which entities use turns
    public static bool E1Turn = false;
    public static bool E2Turn = false;
    public static bool E3Turn = false;

    public static bool counter = false;
    public static bool advantage = false;
    public static int countertime = 0;
    public static int advantagetime = 0;

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //combat builder logic

    public static int enemy1ID = 0;
    public static int enemy2ID = 0;
    public static int enemy3ID = 0;

    public static int enemy1x = 0;
    public static int enemy1y = 0;
    public static int enemy2x = 0;
    public static int enemy2y = 0;
    public static int enemy3x = 0;
    public static int enemy3y = 0;

    public static int numberOfEnemies;

    /////////////////////////////////////////////////////////////////////////////////////////////////////
    //dummy settings/debug settings

    public static bool exit;
    public static bool dummyRegen = false;
    public static bool playerManaLoss;

    public static bool defaultcam;
    public static bool goToOverworld;

    public static bool ps4InUse = false;
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    //rank values
    public static int timeCheck;
    public static int counterCheck;
    public static int advantgeCheck;
    public static int damageCheck;
    public static int attackCheck;
    public static int firedCheck;

    public static bool DoRank;
    public static int maxtime;

    public static Vector3 playerPos = new Vector3 (0, 2, 0);
    //////////////////////
}
