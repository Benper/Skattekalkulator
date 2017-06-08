using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skattekalkulator.Buisness
{
    public class Calculator
    {
        private decimal MinimumLimit = 54650m;
        private decimal standardptsrate = 8.2m;
        private decimal minimumptsrate = 5.1m;
        
        public Calculator()
        {

        }
        
        public Decimal GetTax(int Age, decimal Salery)
        {
            if (Age > 17 && Age <= 69)
                return Calculate(standardptsrate, Salery);
            else
                return Calculate(minimumptsrate, Salery);
        }
        
        private decimal Calculate(decimal Pts, decimal Salery)
        {
            //Kalkulerer avgift basert på lønn og prosentsats avhengig av alder.
            Decimal calcsal = (Salery * Pts) / 100;

            //Kalkulerer en grenseverdi siden skatten ikke kan være høyere en 25% av differansen mellom lønn og
            //nedre grense i personinntekten/grunnlaget for å beregne trygdeavgift
            Decimal threshhold = ((Salery - MinimumLimit) * 25) / 100;


            //Setter grenseverdi hvis den er lavere en utregnet avgift. 
            if (calcsal < threshhold)
                return calcsal;
            else
            {
                if (threshhold < 0)
                    return 0m;
                else
                    return threshhold;
            } 
        }
    }
}
