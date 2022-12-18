using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchController : MonoBehaviour // контроллер поиска
{
    [SerializeField] private List<string> searchList = new(); // список поиска
    [SerializeField] private TMP_InputField inputField; // поле ввода

    [SerializeField] private GameObject searchResultPrefab;
    [SerializeField] private GameObject content;

    public bool IgnoreCase { get; set; } = true;

    public float elementHeight = 40f;
    public float offset = 10f;

    private void Start() // запуск методов
    {
        inputField.onValueChanged.AddListener(OnValueChanged);
        OnValueChanged("");
    }

    private void OnValueChanged(string value)
    {
        // фильтрация списка на основе входного значения
        var filteredList = searchList.FindAll(x => x.StartsWith(value, IgnoreCase, CultureInfo.CurrentCulture)).ToList();

        // включение просмотра с прокруткой, если есть результаты
        content.transform.parent.parent.gameObject.SetActive(filteredList.Count > 0);

        // очистка содержимого
        foreach (Transform child in content.transform) Destroy(child.gameObject);
        
        // установка размера содержимого
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, filteredList.Count * (elementHeight + offset));

        var currentOffset = offset + elementHeight / 2;
        foreach (var val in filteredList)
        {
            // создание нового результата поиска для содержимого
            var searchResult = Instantiate(searchResultPrefab, content.transform);
            
            // задание текста результата поиска
            searchResult.GetComponentInChildren<TMP_Text>().text = val;

            // установка высоты результата поиска
            var rectTransform = searchResult.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(0, elementHeight);
            
            // установка положения результата поиска со смещением
            rectTransform.anchoredPosition = new Vector2(0, -currentOffset);
            
            // увеличение смещения
            currentOffset += elementHeight;

            var button = searchResult.GetComponentInChildren<Button>();
            button.onClick.AddListener(() => SetText(val));
        }
    }

    private void SetText(string text) => inputField.text = text;
}