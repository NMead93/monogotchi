using System.Collections.Generic;
using System.Timers;
using System;

namespace Tamagotchi.Objects
{
  public class Pet
  {
    public static Timer _timer;
    public int Food {get; set;}
    public int Attention {get; set;}
    public int Sleep {get; set;}
    public string Name {get; set;}
    private static Dictionary<int, Pet> _instances = new Dictionary<int, Pet>() {};
    public static int Counter = 0;
    public bool Alive {get; set;}

    public Pet (int food, int attention, int sleep, string name)
    {
      Food = food;
      Attention = attention;
      Sleep = sleep;
      Name = name;
      Alive = true;
      _instances.Add(Counter, this);
      Counter++;
    }

    public static void Start()
    {
      _timer = new Timer(10000); // Set up the timer for 3 seconds
      _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
      _timer.Enabled = true; // Enable it
    }

    public static void End()
    {
      _timer.Enabled = false;
    }

    public static void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        GetPet(0).Food -= 1;
        GetPet(0).Attention -= 1;
        GetPet(0).Sleep -= 1;
    }

    public static Pet GetPet(int index)
    {
      return _instances[index];
    }

    public static void ClearDictionary()
    {
      Counter = 0;
      _instances.Clear();
    }

    public bool CheckLiving()
    {
      if (Food < 1 || Attention < 1 || Sleep < 1)
      {
        Alive = false;
      }
      return Alive;
    }

    public bool Hungry()
    {
      if (Food < 3)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public bool Tired()
    {
      if (Sleep < 3)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public bool Sad()
    {
      if (Attention < 3)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
  }
}
