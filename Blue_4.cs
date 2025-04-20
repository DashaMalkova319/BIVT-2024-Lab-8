using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _output;
        public int Output => _output;
        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input)) return;
            int now = 0;//собираем число
            bool digit = false; //флаг, указывающий, что предыдущий символ - цифра
            foreach(char d in Input)
            {
                if (Char.IsDigit(d))
                {
                    if (!digit)//если не цифра, начинаем новое число
                    {
                        now = (int)d - '0'; 
                        digit = true;
                    }
                    else//если была цифра предыдущей
                    {
                        now = now * 10 + (int)d - '0';//'0' = 48, *10 добавление нового разряда
                    }
                }
                else if (!Char.IsDigit(d) && digit)//если идет не цифра, но до этого было число
                {
                    digit = false;
                    _output += now;
                    now = 0;
                }
            }
            if (digit)//если строка заканчивается цифрой
            {
                _output += now;
            }
        }
        public override string ToString()
        {
            return $"{_output}";
        }
    }
}
