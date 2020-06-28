using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class npcs : Interactable
{
    [SerializeField]
    private Flowchart intro;
    // private Flowchart begin;
    // private Flowchart completeQuest;
    // private Flowchart festival;
    
    void Start()
    {
        intro.SetBooleanVariable("interact", false);
    }

    public override void Interact()
    {
        intro.SetBooleanVariable("interact", true);
        base.Interact();
        
    }


}
