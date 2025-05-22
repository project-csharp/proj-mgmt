
public class ComboBoxItemProject
{
    public string Text { get; set; }
    public int Value { get; set; }

    public ComboBoxItemProject(string text, int value)
    {
        Text = text;
        Value = value;
    }

    public override string ToString()
    {
        return Text;
    }
}