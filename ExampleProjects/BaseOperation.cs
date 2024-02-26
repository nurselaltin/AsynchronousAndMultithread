using ExampleProjects.Model;
using Newtonsoft.Json;
using System.Reflection;

namespace ExampleProjects
{
  public class BaseOperation
  {
    public static List<ItemModel> ReadItemFromTXT()
    {
      var list = new List<ItemModel>();
      try
      {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var items = File.ReadAllLines($"{assemblyPath}\\Utilities\\Items.txt");

        for (int i = 0; i < items.Count(); i++)
        {
          if (String.IsNullOrEmpty(items[i]))
            continue;

          var elements = items[i].Split(new char[] { ',' });
          list.Add(new ItemModel()
          {
            ID = i,
            Name = elements[0],
            Decription = elements[1],
            Code = ""
          });
        }

      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      return list;
    }

    public static void WriteAllItemsToJson(List<ItemModel> items)
    {
      try
      {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = $"{assemblyPath}\\Utilities\\ConvertedItems.json";

        var json = JsonConvert.SerializeObject(items);
        File.WriteAllText(path, json);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
