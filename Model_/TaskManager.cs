using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Model_;

public class TaskManager
{
    private readonly JsonSerializerOptions jsonOptions = new()
    {
        WriteIndented = true,
        IncludeFields = true
    };
    public void Write(List<TaskModel> tasks, string filePath)
    {
        File.WriteAllText(filePath, String.Empty);
        var tasksToFile = JsonSerializer.Serialize(tasks, jsonOptions);
        File.AppendAllText(filePath, tasksToFile);

    }
    public List<TaskModel> Read(string filePath)
    {
        string tasksFromFile = File.ReadAllText(filePath);
        var listTasks = JsonSerializer.Deserialize<List<TaskModel>>(tasksFromFile, jsonOptions);
        return listTasks;
    }
}
