using System;
using System.Collections.Generic;

namespace No3
{
    public delegate double AverageCalculation(List<double> values);

    public class Calculator
    {
        public double CalculateAverage(List<double> values, AverageCalculation method)
        {
            if (values == null)
            {
                throw  new ArgumentNullException("values are null");
            }

            if (method == null)
            {
                throw new ArgumentNullException("delegate doesn't contains method");
            }

            return method(values);
        }
    }
}
