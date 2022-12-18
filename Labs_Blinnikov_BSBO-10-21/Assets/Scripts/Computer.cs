using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer // класс компьютера
{
    private Monitor _monitor;
    private CPU _cpu;
    private GPU _gpu;
    private Motherboard _motherboard; // компоненты ПК
    public bool WithGPU; // наличие видеокарты

    public Monitor Monitor
    {
        get
        {
            return _monitor;
        }
        set
        {
            _monitor = value;
        }
    }

    public CPU CPU
    {
        get
        {
            return _cpu;
        }
        set
        {
            _cpu = value;
        }
    }
    
    public GPU GPU
    {
        get
        {
            return _gpu;
        }
        set
        {
            _gpu = value;
            WithGPU = true;
        }
    }

    public Motherboard Motherboard
    {
        get
        {
            return _motherboard;
        }
        set
        {
            _motherboard = value;
        }
    }
}

public enum Monitor
{
    Hz60,
    Hz120,
    Hz144
}

public enum CPU
{
    Intel,
    Amd
}

public enum GPU
{
    Nvidia,
    Amd
}

public enum Motherboard // перечисления компонентов ПК
{
    Z,
    G,
    Q
}
