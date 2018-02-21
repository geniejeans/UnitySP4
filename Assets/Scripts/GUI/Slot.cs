using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {

	public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    #region IDropHandler implementation

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            if (transform.tag == "EnhancementSlots" || transform.tag == DragHandeler.itemBeingDragged.transform.tag)
            {
                DragHandeler.itemBeingDragged.transform.SetParent(transform);
                if (transform.tag == "EnhancementSlots")
                {
                    Debug.Log("this is it");
                }
            }
        }
    }

    #endregion

    public GameObject GetItem()
    {
        return item;
    }
}
