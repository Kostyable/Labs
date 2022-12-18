using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeBuilder // паттерн проектирования Builder
{
    private readonly Computer _computer;
    
    public ComputeBuilder()
    {
        _computer = new Computer();
    }

    public ComputeBuilder SetDefault(Monitor monitor, CPU cpu, Motherboard motherboard)
    {
        _computer.Monitor = monitor;
        _computer.CPU = cpu;
        _computer.Motherboard = motherboard;
        return this;
    }
    
    public ComputeBuilder SetGPU(GPU gpu)
    {
        _computer.GPU = gpu;
        return this;
    }

    public Computer Build()
    {
        return _computer;
    }
}
