using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollRectNoDrag : ScrollRect {

	public GameObject parent;
	public void SetParent(GameObject receiveParent) {
		parent = receiveParent;
	}
	public override void OnBeginDrag(PointerEventData eventData) {
		parent.GetComponent<UIDraggable2D>().OnBeginDrag(eventData);
	 }
	public override void OnDrag(PointerEventData eventData) { 
		parent.GetComponent<UIDraggable2D>().OnDrag(eventData);
	}
	public override void OnEndDrag(PointerEventData eventData) {
		parent.GetComponent<UIDraggable2D>().OnEndDrag(eventData);
	}
}
