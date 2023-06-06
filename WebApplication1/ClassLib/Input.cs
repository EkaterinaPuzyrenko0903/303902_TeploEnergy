using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Input
    {
        public double d { get; set; } //диамтер трубы
        public double S1 { get; set; }  //Поперечный шаг
        public double S2 { get; set; } // Продольный шаг
        public double w { get; set; }   //Скорость потока
        public double t { get; set; }   //Средняя температура потока
        public string Name { get; set; }

    }
}
