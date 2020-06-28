using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStats
{
    //private static Dictionary<Item, int> items;

    //private static GameObject inventory;
    public enum DialogueStatus
    {
        INTRO,
        QUESTBEGIN,
        QUESTCOMPLETE,
        CELEBRATION
    }
    private static Vector3 townPosition;
    //private static Vector3 forestPosition;

    private static DialogueStatus playerDialogueStatus;

    public static Vector3 TownPosition
    {
        get
        {
            return townPosition;
        }

        set
        {
            townPosition = value;
        }

    }

    public static DialogueStatus PDS
    {
        get
        {
            return playerDialogueStatus;
        }

        set
        {
            playerDialogueStatus = value;
        }
    }



}
