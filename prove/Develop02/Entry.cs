class Entry
{
    public string Text { get; }
    public string Prompt { get; }
    public string Date { get; }

    public Entry(string text, string prompt, string date)
    {
        Text = text;
        Prompt = prompt;
        Date = date;
    }

    public override string ToString()
    {
        return $"{Date}|{Prompt}|{Text}";
    }
}