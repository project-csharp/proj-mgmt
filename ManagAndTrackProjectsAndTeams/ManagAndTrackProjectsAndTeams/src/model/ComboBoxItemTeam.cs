public class ComboBoxItemTeam
{//خاص بالفرق
    public string Text { get; set; }
    public int Value { get; set; }

    public ComboBoxItemTeam(string text, int value)
    {
        Text = text;
        Value = value;
    }

    public override string ToString()
    {
        return Text; // يظهر الاسم داخل الكمبوبوكس
    }
}

