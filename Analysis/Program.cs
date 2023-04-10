using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string title;
            title = Console.ReadLine();
            string text;
            text = Console.ReadLine();

            Text firstText = new Text(title, text);
            
            Console.WriteLine($"тип текста:{firstText.getType()}");
        }

        class Text
        {
            protected string title;
            protected string text;


            public Text(string title, string text) { this.title = title; this.text = text; }

            public string Title
            {
                get
                {
                    return title;
                }
                set
                {
                    title = value;
                }
            }

            public string Content
            {
                get
                {
                    return text;
                }
                set
                {
                    text = value;
                }
            }

            public string getType(){
                Analysis textAnalyze = new Analysis(text)
                return textAnalyze.analyzeLength()
            }
        }

        class Analysis
        {
            private string text;
            
            public Analysis(string text) { this.text = text; }
            
            public string analyzeLength()
            {
                string type;
                int length = text.Length;
                if (length < 10) { type = "Короткий"; } else { type = "Длинный"; }
                return type;
            }
        }
    }
}
