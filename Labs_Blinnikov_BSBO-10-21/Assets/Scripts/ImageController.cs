using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour // контроллер изображения
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Image image;

    public void OnClick() // загрузка файла при нажатии на кнопку
    {
        var path = inputField.text; // путь к файлу
        Debug.Log(path);
        var texture = LoadTexture(path); // текстура
        if (texture != null)
            image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero); // создание спрайта
    }

    private static Texture2D LoadTexture(string path)
    {
        if (File.Exists(path)) // поиск файла по заданному пути
        {
            var fileData = File.ReadAllBytes(path);
            var tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); // автоматическое изменение размеров текстуры
            return tex;
        }

        Debug.LogError($"File not found: {path}");
        return null;
    }
}