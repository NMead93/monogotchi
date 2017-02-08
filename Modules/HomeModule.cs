using Nancy;
using Tamagotchi.Objects;
using System.Collections.Generic;

namespace Tamagotchi
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };

      Post["/active-pet"] = _ => {
        Pet.ClearDictionary();
        Pet newPet = new Pet(5, 5, 5, Request.Form["name"]);
        return View["stats.cshtml", newPet];
      };

      Post["/feed"] = _ => {
          Pet.GetPet(0).Food += 3;
          Pet.GetPet(0).Sleep -= 1;
          if (Pet.GetPet(0).Food > 10) {
            Pet.GetPet(0).Food = 10;
          }
        if (Pet.GetPet(0).CheckLiving())
        {
          return View["stats.cshtml", Pet.GetPet(0)];
        }
        else
        {
          return View["dead.cshtml"];
        }

      };

      Post["/play"] = _ => {
        Pet.GetPet(0).Attention += 3;
        Pet.GetPet(0).Food -= 1;
        Pet.GetPet(0).Sleep -= 1;
        if (Pet.GetPet(0).Attention > 10) {
          Pet.GetPet(0).Attention = 10;
        }
        if (Pet.GetPet(0).CheckLiving())
        {
          return View["stats.cshtml", Pet.GetPet(0)];
        }
        else
        {
          return View["dead.cshtml"];
        }
      };

      Post["/sleep"] = _ => {
        Pet.GetPet(0).Sleep += 3;
        Pet.GetPet(0).Food -= 1;
        Pet.GetPet(0).Attention -= 1;
        if (Pet.GetPet(0).Sleep > 10) {
          Pet.GetPet(0).Sleep = 10;
        }
        if (Pet.GetPet(0).CheckLiving())
        {
          return View["stats.cshtml", Pet.GetPet(0)];
        }
        else
        {
          return View["dead.cshtml"];
        }
      };
    }
  }
}
