using System;
using org.mariuszgromada.math.mxparser;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая__1
{
    public static class Math
    {
        public static string Calculate(string Expression)
        {
            Expression Result = new Expression(Expression);
            return Result.calculate().ToString();
        }
       
    }
}
