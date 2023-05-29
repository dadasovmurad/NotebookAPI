using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public static class BusinessRules
    {
        public static IResult Run(params IResult[] results)
        {
            foreach (var logic in results)
            {
                if (!logic.IsSuccess)
                    return logic;
            }
            return null;
        }
    }
}