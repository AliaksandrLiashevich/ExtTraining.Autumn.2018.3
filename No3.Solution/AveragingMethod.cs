using System.Collections.Generic;
using System.Linq;

namespace No3
{
    public static class AveragingMethod
    {
        public static double SimpleAverage(List<double> values)
        {
            return values.Sum() / values.Count;
        }

        public static double SortedAverage(List<double> values)
        {
            var sortedValues = values.OrderBy(x => x).ToList();

            int n = sortedValues.Count;

            if (n % 2 == 1)
            {
                return sortedValues[(n - 1) / 2];
            }

            return (sortedValues[sortedValues.Count / 2 - 1] + sortedValues[n / 2]) / 2;
        }

        public static double SubAverage(List<double> values)
        {
            return SubAverageRecursion(values, 0, values.Count - 1);
        }

        private static double SubAverageRecursion(List<double> values, int left, int right)
        {
            if (right - left == 1)
            {
                return (values[right] + values[left]) / 2;
            }

            int middle = (right - left) / 2;

            double arg1 = SubAverageRecursion(values, left, middle);
            double arg2 = SubAverageRecursion(values, right, middle + 1);

            return (arg1 + arg2) / 2;
        }

    }
}