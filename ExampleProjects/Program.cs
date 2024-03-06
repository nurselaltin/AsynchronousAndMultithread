using ExampleProjects;
using ExampleProjects.Model;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;


#region Lock Objesiyle

Object _lock = new Object();
try
{
  var convertItems = new List<ItemModel>();
  var items = BaseOperation.ReadItemFromTXT();
  var threadDs = new List<int>();
  var regex = new Regex("[0-9]{1,4}", RegexOptions.None);

  Parallel.ForEach(items, (item) =>
  {
    if (regex.IsMatch(item.Decription))
    {
      item.Code = regex.Match(item.Decription).Value;
      item.ThreadId = Task.CurrentId;
      Console.WriteLine($"Thread Id : {Task.CurrentId} , ID : {item.ID}, Description: {item.Decription}, Code : {item.Code}");
    }
    AddItemToCovertedList(item, convertItems);
  });

  //Write All Items to json
  BaseOperation.WriteAllItemsToJson(convertItems);
}
catch (Exception ex)
{
  Console.WriteLine($"Hata: " + ex.Message);
}

void AddItemToCovertedList(ItemModel item, List<ItemModel> convertItems)
{
  lock (_lock)
  {
    convertItems.Add(item);
  }
}

#endregion


#region ConcurrentDictionary

try
{
  var items = BaseOperation.ReadItemFromTXT();
  var threadDs = new List<int>();
  var regex = new Regex("[0-9]{1,4}", RegexOptions.None);
  ConcurrentDictionary<int, ItemModel> convertItems = new ConcurrentDictionary<int, ItemModel>();

  Parallel.ForEach(items, (item) =>
  {
    if (regex.IsMatch(item.Decription))
    {
      item.Code = regex.Match(item.Decription).Value;
      item.ThreadId = Task.CurrentId;
      Console.WriteLine($"Thread Id : {Task.CurrentId} , ID : {item.ID}, Description: {item.Decription}, Code : {item.Code}");
    }
  });

  //Write All Items to json
  BaseOperation.WriteAllItemsToJson(convertItems);
}
catch (Exception ex)
{
  Console.WriteLine($"Hata: " + ex.Message);
}

#endregion

Console.ReadLine();