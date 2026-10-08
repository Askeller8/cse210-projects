using System;

public class Spinner
{
    private readonly string[] _frames = { "|", "/", "-", "\\" };
    private int _index = 0;

    public void Spin(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
            Console.Write(_frames[_index]);
            _index = (_index + 1) % _frames.Length;
            Thread.Sleep(1000);
        }

        Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
    }
}