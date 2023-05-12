using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ПУПУПУУУУУ
{
    internal class Polz
    {
        private string name;
        public string Name
        {
            get
            {
                name = "[" + name + "]";
                return name;
            }
            set
            {
                Regex pattern = new Regex(@"^\w+$");
                if (!pattern.IsMatch(value))
                {
                    throw new ArgumentException("В 'Имя' можно вбивать только буквы, цифры и '_'");
                }

                name = value;
            }
        }

        private string ip;
        public string IP
        {
            get { return ip; }
            set
            {
                Regex pattern = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
                if (!pattern.IsMatch(value))
                {
                    throw new ArgumentException("Нарушен формат IP-адреса");
                }

                ip = value;
            }
        }
    }
}
