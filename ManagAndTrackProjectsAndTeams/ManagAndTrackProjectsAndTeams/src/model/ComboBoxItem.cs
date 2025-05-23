﻿namespace ManagAndTrackProjectsAndTeams.src.Models
{
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public ComboBoxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text; // حتى يعرض الاسم داخل الكمبو
        }
    }
}
