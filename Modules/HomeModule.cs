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
        Pet.ClearDictionary();
        Pet newPet = new Pet(0,0,0, "null");
        return View["index.cshtml", newPet];
      };

      Get["/stats"] = _ => {
        if (Pet.GetPet(0).CheckLiving())
        {
          return View["stats.cshtml", Pet.GetPet(0)];
        }
        else
        {
          Pet.End();
          return View["dead.cshtml", Pet.GetPet(0)];
        }
      };

      Post["/active-pet"] = _ => {
        Pet.ClearDictionary();
        Pet newPet = new Pet(10, 10, 10, Request.Form["name"]);
        Pet.Start();
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
          Pet.End();
          return View["dead.cshtml", Pet.GetPet(0)];
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
          Pet.End();
          return View["dead.cshtml", Pet.GetPet(0)];
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
          Pet.End();
          return View["dead.cshtml", Pet.GetPet(0)];
        }
      };
    }
  }
}
