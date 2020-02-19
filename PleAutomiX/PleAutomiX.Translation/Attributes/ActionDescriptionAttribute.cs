using System;

namespace PleAutomiX.Translation.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ActionDescriptionAttribute : Attribute
    {
        public string Language { get; set; }

        public string Text { get; set; }

        public ActionDescriptionAttribute(string language, string text)
        {
            Language = language;
            Text = text;
        }
    }
}