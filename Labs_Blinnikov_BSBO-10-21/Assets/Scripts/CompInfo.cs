using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CompInfo : MonoBehaviour
{
    private Text _info;
    private Computer _computer; // экземпляр класса компьютера
    [SerializeField] private Monitor monitor;
    [SerializeField] private CPU cpu;
    [SerializeField] private GPU gpu;
    [SerializeField] private Motherboard motherboard; // компоненты ПК
    void Awake() // инициализация полей
    {
        _computer = new ComputeBuilder().SetDefault(monitor, cpu, motherboard).SetGPU(gpu).Build(); // инициализация с помощью Builder
        _info = GetComponent<Text>();
        SetText();
    }

    void SetText() // вывод информации о компьютере
    {
        _info.text = "Monitor: " + _computer.Monitor + "\n";
        _info.text += "CPU: " + _computer.CPU + "\n";
        if (_computer.WithGPU)
        {
            _info.text += "GPU: " + _computer.GPU + "\n";
        }
        _info.text += "Motherboard: " + _computer.Motherboard + "\n";
    }
}
