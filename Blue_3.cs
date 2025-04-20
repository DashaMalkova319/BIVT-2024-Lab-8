using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output; //  кортеж из символа и вещественного числа
        public (char, double)[] Output => _output;
        public Blue_3(string input) : base(input)
        {
            _output = null;
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input)) return;
            string[] word = Input.Split(' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/');
            string res = "";
            int count = 0;//для подсчета уникальных значений букв



            if (word.Length == 0) return;
            foreach (string w in word)//собираем первые буквы
            {
                if (!string.IsNullOrEmpty(w))
                {
                    char first = w[0];
                    if (char.IsLetter(first))
                    {
                        res += char.ToLower(first);//все первые буквы в нижнем регистре
                    }
                }
            }
            (char, double)[] letter = new (char, double)[res.Length];
            for (int i = 0; i < letter.Length; i++)//инициализируем массив кортежей
            {
                letter[i] = ('\0', 0);
            }
            foreach (char l in res)
            {
                bool found = false;
                for (int i = 0; i < letter.Count(); i++)
                {
                    if (letter[i].Item1 == l)
                    {
                        letter[i] = (l, letter[i].Item2 + 1);
                        found = true;//буква уже была
                        break;
                    }
                }
                if (!found)//если буква новая, добавляем ее в массив
                {
                    for (int j = 0; j < letter.Length; j++)
                    {
                        if (letter[j].Item1 == '\0')//ищем пустое место, в которое положим новую букву
                        {
                            letter[j] = (l, 1);//ставим счетчик, добавили букву в массив
                            count++;
                            break;
                        }
                    }
                }
            }

            var result = new (char, double)[count];//новый массив кортежей с уникальными значениями
            int all = res.Count();//все первые буквы, которые есть
            int ind = 0;

            foreach (var item in letter)//добавляем каждую букыу и ее проценты
            {
                if (!(item.Item1 == '\0'))
                {
                    double percent = (item.Item2 / all) * 100;
                    result[ind] = (item.Item1, percent);
                    ind++;
                }
            }
            (char, double)[] newResult = result.OrderByDescending(t => t.Item2).ThenBy(t => t.Item1).ToArray();
            //OrderByDescending(t => t.Item2) Сортирует элементы по убыванию (от большего к меньшему) второго элемента кортежа (Item2 - число типа double)
            //ThenBy(t => t.Item1) Если значения Item2 равны, сортирует по возрастанию первого элемента кортежа (Item1 - символ типа char)
            //ToArray() материализует её в массив кортежей
            _output = newResult;
        }

        public override string ToString()
        {
            if (_output == null) return null;
            return string.Join(Environment.NewLine, _output.Select(p => $"{p.Item1} - {p.Item2:F4}"));
        }
    }
}
