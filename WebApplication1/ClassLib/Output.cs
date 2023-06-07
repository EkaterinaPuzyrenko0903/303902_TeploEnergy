using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Output
    {
        public double Re { get; set; }   //Число Рейнольдса
        public double Nu_sh { get; set; } //Критерий Нусселта
        public double Nu_k { get; set; }
        public double Nu_sh_k { get; set; }
        public double ps { get; set; } //параметр
        public double s { get; set; } //эффективная толщина излучающего слоя
        public double k_e { get; set; } //Коэффициент поглощения газового объема
        public double k_l { get; set; }
        public double e_d { get; set; } //Степень черноты газов
        public double a_d { get; set;}
        public double c_pr { get; set; } //Приведенный коэффициент излучения
        public double a_dl { get; set;} //Коэффициент теплоотдачи излучением

    }
}
