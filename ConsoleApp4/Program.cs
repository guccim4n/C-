using System;

public class Thermometer
{
    public event Action<int> OnChange;

    public int Temp { get; set; } = 20;


    public void ChangeTemp(int newTemp)
    {
        Temp = newTemp;
        OnChange?.Invoke(newTemp);
    }
}


public class AirConditioner
{
    public void React(int temp)
    {
        if (temp > 25)
            Console.WriteLine($"Включился кондиционер ({temp}°C)");
    }
}


public class WarningSystem
{
    public void Alert(int temp)
    {
        if (temp > 30)
            Console.WriteLine($"ВНИМАНИЕ! ГОРИМ {temp}°C!");
    }
}

class Program
{
    static void Main()
    {
        var termo = new Thermometer();
        var ac = new AirConditioner();
        var warn = new WarningSystem();


        termo.OnChange += ac.React;
        termo.OnChange += warn.Alert;


        termo.ChangeTemp(22);
        termo.ChangeTemp(26);
        termo.ChangeTemp(32);
    }
}
