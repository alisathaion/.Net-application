using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A00912599Assign05
{
    class DateValidator
    {
        public static bool Validate(string Year, string Month, string Day)
        {
            bool result = false;
            
            if (int.TryParse(Year,out int intYear)&&int.TryParse(Month,out int intMonth)&&int.TryParse(Day,out int intDay))
            {
                if (Year.Length != 4 || intMonth < 1 || intMonth > 12 || intDay < 1 || intDay > 31 )
                {
                    result = false;
                }
                else
                {
                    if (intMonth == 4 || intMonth == 6 || intMonth == 9 || intMonth == 11)
                    {
                        if (intDay > 30)
                        {
                            result = false;
                        }
                        else
                        {
                            result = true;
                        }
                    }
                    else if (intMonth == 2)
                    {
                        if (intDay > 29)
                        {
                            result = false;
                        }
                        else
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        result = true;
                    }
                    
                }

            }
            else
            {
                result = false;
            }
            return result;
  
        }
    }
}
