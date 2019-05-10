using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightTour
{
    class Result
    {
         static void Main(string[] args)
        {
           
            Choices c = new Choices();
            int j = 0;
            int i = 0;
            while (i < 10) {
                //  c.intelligent(5, 5); get full score
                c.intelligent(5, 5);
                i++;
            }
            Console.WriteLine("------------------------------------");
            while (j < 10)
            {
                //  c.intelligent(5, 5); get full score
                c.nonIntelligent(5,5);
                j++;
            }
            Console.ReadKey();
            
           
        }
    }
}
