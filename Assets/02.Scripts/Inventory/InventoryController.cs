using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public RectTransform content;
    public GameObject slot;

    private float spacing = 5f;

    private void Start()
    {

        Destroy(content.GetChild(0).gameObject);
        for (int i = 0;i < 20; i++)
        {
            GameObject slotGO = Instantiate(slot, content);
            slotGO.GetComponent<InventorySlot>().slotData.ID = i;
        }
    }
}
