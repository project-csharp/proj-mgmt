public class ListBoxProjectItem
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ListBoxProjectItem(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return Name; // هذا اللي ينعرض في listBox
    }
}
