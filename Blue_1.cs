using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;
        public string[] Output=> _output;
        public Blue_1(string input) : base(input) 
        {
            _output = null;
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }
            string[] word = Input.Split(' '); //разделяю слова в тексте по пробелам
            string[]result= new string[word.Length]; //массив по кол-ву слов
            string time = ""; //временная строка для слов, пока символов меньше 50
            int count = 0;//счётчик заполненных строк в result
            for (int i = 0; i < word.Length; i++)
            {
                string w = word[i];
                if(time.Length + w.Length + 1 <= 50)
                {
                    //добавляем слово к текущей строке
                    if(time.Length > 0)
                    {
                        time += " " + w;
                    }
                    else
                    {
                        time += w;
                    }
                }
                else //начинаем новую строку
                {
                    result[count] = time;
                    count++;
                    time = w;//начинаем новую строку с текущего слова
                }
                
            }
            if(time.Length > 0)
            {
                result[count++] = time; //добавляем последнюю строку, если она не пустая
            }
            _output = new string[count];
            Array.Copy(result, _output, count);
            
        }
        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return null;
            return string.Join(Environment.NewLine, _output); //перенос на новую строку без /n
        }
    }
}
