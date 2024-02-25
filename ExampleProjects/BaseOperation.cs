using ExampleProjects.Model;
using Newtonsoft.Json;
using System.Reflection;
using System.Text.Json.Serialization;

namespace ExampleProjects
{
  public class BaseOperation
  {
    public static List<ItemModel> ReadItemFromTXT()
    {
      var list = new List<ItemModel>();
      var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      var items = File.ReadAllLines($"{assemblyPath}\\Utilities\\Items.txt");

      for (int i= 0; i<items.Count(); i++)
      {
        if (String.IsNullOrEmpty(items[i]))
            continue;

        var elements = items[i].Split(new char[] { ',' });
        list.Add(new ItemModel()
        {
           ID=i,
           Name = elements[0],
           Decription = elements[1],
           Code = ""
        });
      }

      return list;
    }

    public static void WriteAllItemsToTxt(List<ItemModel> items)
    {
      var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      var path = $"{assemblyPath}\\Utilities\\ConvertedItems.json";

      var json = JsonConvert.SerializeObject(items);
      try
      {
        File.WriteAllText(path, json);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
