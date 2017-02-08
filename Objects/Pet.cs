using System.Collections.Generic;

namespace Tamagotchi.Objects
{
  public class Pet
  {
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
  }
}
