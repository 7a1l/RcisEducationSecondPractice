using System;

namespace _2_6
{
    public class log  : info
    {
        public log(string d, string kA, string eC, string p, string f, string Fib)
        {
            Date = d;
            KnownAs = kA;
            ENERC_KCAL = float.Parse(eC);
            PROCNT = float.Parse(p);
            FAT = float.Parse(f);
            FIBTG = float.Parse(Fib);
        }
        public string Date { get; set; }
        public string KnownAs { get; set; }
    }
}