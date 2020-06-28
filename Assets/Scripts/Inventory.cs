using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    void Awake()
    {
        if( instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion
    //public List<Item> items = new List<Item>();
    public Dictionary<Item, int> items = new Dictionary<Item, int>();

    public void Add (Item item)
    {
        //For Dictionary
        if(items.ContainsKey(item))
        {
            items[item] = items[item]+1;

        }
        else
        {
            items.Add(item,1);
        }
        Debug.Log(items);

        //For List
        //items.Add(item)

        
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }
}
