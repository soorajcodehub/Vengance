using System;
using System.Collections;
using System.Collections.Generic;

namespace CrackThat
{
    public class NumberConverter
    {
        static Dictionary<int, string> teens = new Dictionary<int, string>() {
                {0, ""},
				{1, " one" },
				{2, " two" },
				{3, " three"},
				{4, " four"},
				{5 ," five"},
				{6, " six"},
				{7, " seven"},
				{8, " eight"},
				{9, " nine"},
				{10, " ten"},
				{11, " eleven"},
				{12, " twelve"},
				{13, " thirteen"},
				{14, " fourteen"},
				{15, " fifteen"},
				{16, " sixteen"},
				{17, " seventeen"},
				{18, " eighteen"},
				{19, " ninteen"}
			};

		static Dictionary<int, string> tens = new Dictionary<int, string>() {
				{
					2, "twenty"
				},
				{
					3, "thirty"
				},
				{
					4, "forty"
				},
				{
					5, "fifty"
				},
				{
					6, "sixty"
				},
				{
					7, "seventy"
				},
				{
					8, "eighty"
				},
				{
					9, "ninty"
				}
			};

        static Dictionary<int, string> places = new Dictionary<int, string>()
            {
                {0, ""},
				{1, " thousand "},
				{2, " million "},
				{3, " billion "}
			};

		public static string ConvertNumber(int number)
        {
			if (number == 0)
				return " zero";
            
            string numberRepresentation = "";
            string hundredRepresentation = "";
            int i = 0;
            while (number > 0 )
            {
                if (number / 1000 > 0)
                {
                    hundredRepresentation = getStringRep(number % 1000);

                    if (!String.IsNullOrEmpty(hundredRepresentation))
                    {
                        numberRepresentation = hundredRepresentation + places[i] + numberRepresentation;
                    }

                    i++;
                }
                else
                {
                    if (number / 100 > 0)
                    {
                        return getStringRep(number) + places[i] + numberRepresentation;
                    }
                    else
                    {
                        numberRepresentation = teens[number] + places[i] +  numberRepresentation;
                        return numberRepresentation;
                    }
                }
                number = number / 1000;
            }

            return numberRepresentation;
        }

        private static string getStringRep(int num, string numberRepresentation = "")
        {
            if (num >= 100)
            {
                numberRepresentation += teens[num / 100];
                numberRepresentation += " hundred ";
                return getStringRep(num % 100, numberRepresentation);
            }
            else if (num <100 && num >= 20)
            {
                numberRepresentation += tens[num / 10];
                return getStringRep(num % 10, numberRepresentation);
            }
            else 
            {
                numberRepresentation += teens[num];
                return numberRepresentation;
            }
        }
    }
}
