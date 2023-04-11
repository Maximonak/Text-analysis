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

            Console.WriteLine($"Размер текста:{firstText.getType()}");
            Console.WriteLine($"Анализ слов:{firstText.getType(setting: "wordsCount")}");
            Console.WriteLine($"Строгий анализ слов:{firstText.getType(setting: "singleWordsCount")}");
            Console.WriteLine("Количество отдельных слов в тексте:");
            foreach (var i in firstText.getType(setting: "SemanticWordCount")) {
                Console.WriteLine($"{i.Key} - {i.Value}");
            }

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

            public string getType() {
                Analysis textAnalyze = new Analysis(text);
                return textAnalyze.analyzeLength();
            }
            //перегрузка метода
            public dynamic getType(string setting) {
                var textAnalyze = new Analysis.SemanticCore(text);


                switch (setting)
                {
                    case "wordsCount":
                        return textAnalyze.analyzeWordsCount();
                    case "singleWordsCount":
                        return textAnalyze.analyzeWordsCount(single: true);
                    case "length":
                        return textAnalyze.analyzeLength();
                    case "SemanticWordCount":
                        return textAnalyze.SemanticWordCount();
                    default:
                        return "Неизвестный тип анализа";

                }
            }
        }

        class Analysis
        {
            protected string text;

            public Analysis(string text) { this.text = text; }

            public string analyzeLength()
            {
                int length = text.Length;
                return $"{length} символов";
            }

            public string analyzeWordsCount()
            {
                int wordsCount = 0;
                int wordLength = 0;
                foreach (char i in text)
                {
                    if (i != ' ')
                    {
                        wordLength++;
                    }
                    else if (wordLength > 0)
                    {
                        wordsCount++;
                        wordLength = 0;
                    }
                }
                if (wordLength > 0) { wordsCount++; }
                return $"{wordsCount} слов";
            }
            //перегрузка метода
            public string analyzeWordsCount(bool single)
            {
                if (single)
                {
                    int wordsCount = 0;
                    string word = "";
                    string wordsPit = "";
                    foreach (char i in text)
                    {
                        if (i != ' ')
                        {
                            word += i;
                        }
                        else if (word != "" && !wordsPit.Contains(word))
                        {
                            wordsCount++;
                            word = "";
                        }
                        else
                        {
                            word = "";
                        }
                    }
                    if (word != "") { wordsCount++; }
                    return $"{wordsCount} отдельных слов";
                }
                else
                {
                    return this.analyzeWordsCount();
                }
            }



            public class SemanticCore : Analysis
            {
                public SemanticCore(string text) : base(text) { }

                public Dictionary<string, int> SemanticWordCount()
                {
                    Dictionary<string, int> output = new Dictionary<string, int>();

                    string word = "";
                    foreach (char i in text)
                    {
                        if (i != ' ')
                        {
                            word += i;
                        }
                        else if (word != "" && !output.Keys.Contains(word))
                        {
                            output.Add(word, 1);
                            word = "";
                        }
                        else
                        {
                            output[word]++;
                            word = "";
                        }
                    }
                    return output;
                }
            }
        } 
    }
}
