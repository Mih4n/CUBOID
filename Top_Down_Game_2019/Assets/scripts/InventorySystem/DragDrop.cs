using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public bool isWeapon;

    [HideInInspector] private Canvas _canvas;
    [HideInInspector] private GameObject _closest;
    [HideInInspector] private GameObject _oldClosest;
    [HideInInspector] private Inventory _inventory;
    [HideInInspector] private RectTransform _rectTransform;
    [HideInInspector] private CanvasGroup _canvasGroup;
    [HideInInspector] private bool _isDragged = false;

    private void Awake() 
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start() 
    {
        _canvas = gameObject.transform.parent.gameObject.GetComponent<Slot>().Canvas; 
        _closest = gameObject.transform.parent.gameObject; 
        _oldClosest = gameObject.transform.parent.gameObject; 
        _inventory = _closest.GetComponent<Slot>().Inventory;
    }

    private void Update() 
    {
        if(_isDragged == false)
        {
            if(_inventory.Items[_closest.GetComponent<Slot>().Index] == 0)
            {
                transform.position = _closest.transform.position;
                gameObject.transform.SetParent(_closest.transform);                
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        _canvasGroup.alpha = .6f;
        _canvasGroup.blocksRaycasts = false;
        _isDragged = true;
    }

    public void OnDrag(PointerEventData eventData) {
        //Debug.Log("OnDrag");
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        _isDragged = false;
        transform.position = Vector3.zero;
        _oldClosest = _closest;
        _closest = transform.parent.gameObject;
        _inventory = _closest.GetComponent<Slot>().Inventory;
        transform.position = _closest.transform.position;
        _canvas = _closest.GetComponent<Slot>().Canvas;
        if(_inventory.Items[_closest.GetComponent<Slot>().Index] == 1 || (_closest.GetComponent<Slot>().IsWeaponSlot == true && isWeapon == false))
        {
            gameObject.transform.SetParent(_oldClosest.transform);
            transform.position = _oldClosest.transform.position;
            _closest = _oldClosest;
            _inventory = _closest.GetComponent<Slot>().Inventory;
            _canvas = _closest.GetComponent<Slot>().Canvas;
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
    }

}
