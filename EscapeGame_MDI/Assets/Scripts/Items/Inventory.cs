using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private List<Inventairable> inventaire = new List<Inventairable>();
    private Vector3 basePos = new Vector3(-863.20f, -489.5f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void addToInventory(Inventairable item)
    {
        inventaire.Add(item);
        GameObject[] icons = new GameObject[0];

        icons = GameObject.FindGameObjectsWithTag("InvKey");

        if (icons.Length > 0)
        {
            foreach (GameObject i in icons)
            {
                if (i.name.Equals(item.objName))
                {
                    i.GetComponent<RectTransform>().anchoredPosition = new Vector3(basePos.x + 68 * (inventaire.Count - 1), basePos.y, basePos.z);
                    i.GetComponent<RawImage>().enabled = true;
                    break;
                }
            }
        }
    }

    public bool isPossesed(string neededName)
    {
        foreach(Inventairable i in inventaire)
        {
            if (i.objName.Equals(neededName))
            {
                return true;
            }
        }
        return false;
    }

    public void removeFromInventory(string theName)
    {
        foreach (Inventairable o in inventaire)
        {
            if (o.objName.Equals(theName))
            {
                GameObject[] icons = GameObject.FindGameObjectsWithTag("InvKey");
                if (icons.Length > 0)
                {
                    foreach (GameObject i in icons)
                    {
                        if (i.name.Equals(theName))
                        {
                            i.GetComponent<RawImage>().enabled = false;
                            break;
                        }
                    }
                }
                inventaire.Remove(o);
                break;
            }
        }

    }
}
