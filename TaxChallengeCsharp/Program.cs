using System.Globalization;

namespace TaxChallengeCsharp
{
    class Program
    {
        static void Main(string[] args) 
        {
            double monthlySalary, salaryTax;
            double serviceTax;
            double capitalTax;
            double totalTax, totalExpense, rebateTax, maxRebate, taxToPay;

            Console.Write("Renda anual com salário: ");
            double annualIncomePerSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Renda anual com prestação de serviço: ");
            double annualIncomePerService = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Renda anual com ganho de capital: ");
            double annualIncomePerCapital = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Gastos médicos: ");
            double medicalExpenses = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Gastos educacionais: ");
            double educationalExpenses = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //business rules
            //salary
            monthlySalary = annualIncomePerSalary / 12;
            if (monthlySalary < 3000.0)
            {
                salaryTax = 0;
            }
            else if (monthlySalary < 5000.0)
            {
                salaryTax = annualIncomePerSalary * 0.10;
            }
            else
            {
                salaryTax = annualIncomePerSalary * 0.20;
            }

            //service
            if (annualIncomePerService > 0.0)
            {
                serviceTax = annualIncomePerService * 0.15;
            }
            else
            {
                serviceTax = 0.0;
            }

            //capital
            if (annualIncomePerCapital > 0.0)
            {
                capitalTax = annualIncomePerCapital * 0.20;
            } 
            else
            {
                capitalTax = 0.0;
            }

            //rebate
            totalTax = salaryTax + serviceTax + capitalTax;
            totalExpense = medicalExpenses + educationalExpenses;

            maxRebate = totalTax * 0.30;

            if (totalExpense >= maxRebate) 
            {
                rebateTax = maxRebate;
            }
            else
            {
                rebateTax = totalExpense;
            }

            taxToPay = totalTax - rebateTax;

            //report
            Console.WriteLine();
            Console.WriteLine("RELATÓRIO DE IMPOSTO DE RENDA");
            Console.WriteLine();

            Console.WriteLine("CONSOLIDADO DE RENDA:");
            if (salaryTax > 0)
            {
                Console.WriteLine("Imposto sobre o salário: " + salaryTax.ToString("F2", CultureInfo.InvariantCulture));
            }
            else
            {
                Console.WriteLine("Imposto sobre o salário: ISENTO");
            }
            
            Console.WriteLine("Imposto sobre o serviços: " + serviceTax.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Imposto sobre o ganho de capital: " + capitalTax.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine();

            Console.WriteLine("DEDUÇÕES:");
            Console.WriteLine("Máximo dedutível: " + maxRebate.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Gastos dedutíveis: " + totalExpense.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine();

            Console.WriteLine("RESUMO:");
            Console.WriteLine("Imposto bruto total: " + totalTax.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Abatimento: " + rebateTax.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Imposto devido: " + taxToPay.ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
