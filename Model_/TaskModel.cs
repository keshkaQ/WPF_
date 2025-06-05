namespace Model_;

public class TaskModel
{
    public string Name { get; set; }
    public bool IsCompleted { get; set; }
    public override string ToString()
    {
        return $"Название: {Name}, Статус: {GetStatus(IsCompleted)}\n";
    }
    public string GetStatus(bool IsComplete)
    {
        if (IsComplete)
        {
            return "Выполнено";
        }
        else
        {
            return "Не выполнено";
        }
    }
}
