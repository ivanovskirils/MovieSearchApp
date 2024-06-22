using Ganss.Xss;

public class HtmlSanitizerWrapper : IHtmlSanitizer
{
    private readonly HtmlSanitizer _htmlSanitizer;

    public HtmlSanitizerWrapper()
    {
        _htmlSanitizer = new HtmlSanitizer();
    }

    public string Sanitize(string input)
    {
        return _htmlSanitizer.Sanitize(input);
    }
}
