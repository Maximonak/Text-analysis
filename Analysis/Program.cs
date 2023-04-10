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
                Analysis textAnalyze = new Analysis(text);
                return textAnalyze.analyzeLength();
            }
            //перегрузка метода
            public string[] getType(string setting){
                Analysis textAnalyze = new Analysis(text)

                switch (setting)
                {
                    case == "wordsCount":
                        return textAnalyze.analyzeWordsCount();
                        break;
                    case == "singleWordsCount":
                        return textAnalyze.analyzeWordsCount(single:true);
                    case == "length":
                        return textAnalyze.analyzeLength();
                        break;
                    default:
                        pass;
                }
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

            public string analyzeWordsCount(){
                int wordsCount = 0;
                int wordLength = 0;
                foreach (char i in text)
                {
                    if(i != " "){
                        wordLength++;
                    } else if (wordLength>0) {
                        wordsCount++;
                        wordLength = 0;
                    }
                }
                if (wordLength>0) { wordsCount++; }
                return $"{wordsCount} слов"
            }
            //перегрузка метода
            public string analyzeWordsCount(bool single){
                if (single){
                    int wordsCount = 0;
                    string word = "";
                    string wordsPit = "";
                    foreach (char i in text)
                    {
                        if(i != " "){
                            word += i;
                        } else if (word!="" && !wordsPit.Contains(word)) {
                            wordsCount++;
                            word = "";
                        } else {
                            word = "";
                        }
                    }
                    if (word != "") { wordsCount++; }
                    return $"{wordsCount} отдельных слов"
                } else {
                    return this.analyzeWordsCount();
                }
            }

        }
    }
}
