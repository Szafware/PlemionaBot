using PleAutomiX.Translation.Enums;
using System;

namespace PleAutomiX.Game.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
    public class ParameterDescriptionAttribute : Attribute
    {
        public string Language { get; set; }

        public string Text { get; set; }

        public ParameterTypes ParameterType { get; set; } 

        public ParameterDescriptionAttribute(string language, string text, ParameterTypes parameterType)
        {
            Language = language;
            Text = text;
            ParameterType = parameterType;
        }
    }
}