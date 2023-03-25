using System;

namespace _2_3
{
    class Calculation
    {
        private string calculationLine;
        public void SetCalculationLine(string line)
        {
            calculationLine = line;
        }
        public void SetLastSymbolCalculationLine(string character)
        {
            this.calculationLine += character;
        }
        public void getCalculationLine()
        {
            Console.WriteLine(calculationLine);
        }
        public char GetLastSymbol()
        {
            return calculationLine[calculationLine.Length - 1];
        }
        public void DeleteLastsymbol()
        {
            calculationLine = calculationLine.Remove(calculationLine.Length - 1);
        }
    }
}
