using System;

class Television
{
    private int channel = 0;
    private int volume = 0;
    private bool isOn = false;

    public bool On
    {
        get
        {
            return isOn;
        }
        set
        {
            isOn = value;
            if (isOn)
            {
                Console.WriteLine("TV is On. Enjoy!");
            }
            else
            {
                Console.WriteLine("TV is OFF. Goodbye!");
            }
        }
    }

    public int Volume
    {
        get
        {
            return volume;
        }
        set
        {
            if (value >= 0 && value <= 100)
            {
                volume = value;
                Console.WriteLine("Volume: {0}", volume);
            }
        }
    }

    public int Channel
    {
        get
        {
            return channel;
        }
        set
        {
            if (value > 0 && value < 50)
            {
                channel = value;
                Console.WriteLine("New Channel {0}. Keep zapping!", channel);
            }
        }
    }
}
