using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {

    public bool IsWeaponSlot;
    public bool IsDropSlot;
    public Canvas Canvas;
    public Inventory Inventory;
    public int Index;

    private void Start()
    {    
        
    }

    private void Update()
    {
        if(IsDropSlot == true)
        {
            if (transform.childCount > 0)
            {
                Cross();               
            } 
        }
        if (transform.childCount <= 0) {
            Inventory.Items[Index] = 0;
        }
        if (transform.childCount > 0) {
            Inventory.Items[Index] = 1;
        }            
    }

    public void Cross() {

        foreach (Transform child in transform) {
            child.GetComponent<Spawn>().SpawnItem();
            GameObject.Destroy(child.gameObject);
        }
    }

    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null && eventData.pointerDrag.transform.gameObject.tag != "MotionController" &&  eventData.pointerDrag.transform.gameObject.tag != "WeaponController") {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.transform.SetParent(transform);
        }
    }
}
