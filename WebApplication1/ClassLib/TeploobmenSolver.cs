using System.Data;

namespace ClassLib
{
    public class TeploobmenSolver
    {
        public double d { get; set; } //Диаметр трубы (м)
        public double S1 { get; set; } //Поперечный шаг 
        public double S2 { get; set; }// Продольный шаг 
        public double w { get; set; } //скорость потока (м\с)
        public double v { get; set; } //коэффициент кинематической молекулярной вязкости
        public double t { get; set; } //средняя температура потока
        public double s { get; set; }

        public TeploobmenSolver(Input input)
        {
            d = input.d;
            S1 = input.S1;
            S2 = input.S2;
            w = input.w;
            t = input.t;
        }

        public Output calc()
        {
            v= (0.00000000007 * Math.Pow(t,2))+ 0.00000009 * t + 0.00001;
            double Pr = 0.0000003 * Math.Pow(t,2)- 0.0003*t+0.7729;
            double Re = w*d/v;
            //Шахматное(Re > 1000)
            double Nu_sh = 0.41 * Math.Pow(Re , 0.6) * Math.Pow(Pr, 0.36);
            //Коридорное расположение (Re > 1000)
            double Nu_k = 0.22 * Math.Pow(Re , 0.65) * Math.Pow(Pr, 0.36);
            //Шахматное и коридорное расположение (Re<1000)
            double Nu_sh_k = 0.56 * Math.Pow(Re, 0.5) * Math.Pow(Pr, 0.36);
            //Лучистый теплообмен
            double ps = (S1+S2)/d;
            
            if (ps <= 7)
            {
                s = (1.87 * ps - 4.1) * d;
                
            }
            else if (ps > 7 && ps < 13)
            {
                s = (2.82 * ps - 10.6) * d; 
            }
            
            double k_e = ((0.8 + (1.6 * 0.11)) * (1 - 0.00038 * (t + 273))) / Math.Pow((0.11 + 0.13) * s, 0.5);
            //Коэффициент поглащения газового объема
            int t_k = 100;     
            double k_l = ((0.8 + (1.6 * 0.11)) * (1 - 0.00038 * (t_k + 273))) / Math.Pow((0.11 + 0.13) * d, 0.5);
            //Степень черноты газов εд
            double e_d = 1 - Math.Exp(-k_e * (0.11 + 0.13) * s);
            //Степень черноты газов Адл
            double a_d = 1 - Math.Exp(-k_l * (0.11 + 0.13) * s);
            //Приведённый коэффициент
            double c_pr = 5.67 / ((1 / a_d) + (1 / 0.8) - 1);
            //Коэффициент теплоотдачи излучением адл
            double a_dl =( c_pr * ((e_d / a_d) * Math.Pow((t + 273) / 100, 4) - Math.Pow((t_k + 273) / 100, 4))) / ((t+273) - (t_k +273));
            return new Output
            {
                ps = Math.Round(ps, 4),
                s = Math.Round(s,4),
                k_e = Math.Round(k_e, 4),
                k_l=Math.Round(k_l, 4),
                e_d = Math.Round(e_d, 4),
                a_d=Math.Round(a_d, 4),
                c_pr=Math.Round(c_pr, 4),
                a_dl=Math.Round(a_dl, 4),
                Re=Math.Round(Re, 4),
                Nu_sh = Math.Round(Nu_sh, 4),
                Nu_k = Math.Round(Nu_k, 4),
                Nu_sh_k= Math.Round(Nu_sh_k, 4),
            };

        }
    }
}