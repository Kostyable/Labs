using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDraggableCorners : MonoBehaviour, IDragHandler // перетаскиваемые объекты
{
    [SerializeField] private RectTransform parentRectTransform; // компонент Rect Transform изображения
    [SerializeField] private Corner corner; // угол
    [SerializeField, Range(1f, 50f)] private float cornerSize = 20f; // размер объекта

    private void Start()
    {
        var rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(cornerSize, cornerSize);
        rt.anchoredPosition = corner switch // изменение положения на половину размера угла
        {
            Corner.TopLeft => new Vector2(cornerSize / 2f, -cornerSize / 2f),
            Corner.TopRight => new Vector2(-cornerSize / 2f, -cornerSize / 2f),
            Corner.BottomLeft => new Vector2(cornerSize / 2f, cornerSize / 2f),
            Corner.BottomRight => new Vector2(-cornerSize / 2f, cornerSize / 2f),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        switch (corner) // изменение размера изображения по типу угла
        {
            case Corner.BottomLeft:
                parentRectTransform.offsetMin += new Vector2(eventData.delta.x, eventData.delta.y);
                break;
            case Corner.BottomRight:
                parentRectTransform.offsetMin += new Vector2(0, eventData.delta.y);
                parentRectTransform.offsetMax += new Vector2(eventData.delta.x, 0);
                break;
            case Corner.TopLeft:
                parentRectTransform.offsetMin += new Vector2(eventData.delta.x, 0);
                parentRectTransform.offsetMax += new Vector2(0, eventData.delta.y);
                break;
            case Corner.TopRight:
                parentRectTransform.offsetMax += new Vector2(eventData.delta.x, eventData.delta.y);
                break;
        }
    }
}

public enum Corner // тип угла (левый верхний, правый верхний, левый нижний, правый нижний)
{
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight
}