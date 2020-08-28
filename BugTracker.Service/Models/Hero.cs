using System.Collections.Generic;

namespace BugTracker.Service.Models
{
  public class Hero
  {
    public int id { get; set; }
    public string name { get; set; }
    public List<Hero> Heroes { get; set; }

    public Hero()
    {
      Heroes = new List<Hero>(){ };
    }
    public void initialize()
    {
      Heroes.Add(new Hero(){id = 1, name = "carlos"});
      Heroes.Add(new Hero(){id = 2, name = "perla"});
      Heroes.Add(new Hero(){id = 2, name = "perla"});
      Heroes.Add(new Hero(){id = 2, name = "perla"});
      Heroes.Add(new Hero(){id = 2, name = "perla"});
      Heroes.Add(new Hero(){id = 2, name = "perla"});
      Heroes.Add(new Hero(){id = 2, name = "perla"});
      Heroes.Add(new Hero(){id = 2, name = "perla"});
      Heroes.Add(new Hero(){id = 2, name = "perla"});
      Heroes.Add(new Hero(){id = 2, name = "perla"});

    }
  }
}