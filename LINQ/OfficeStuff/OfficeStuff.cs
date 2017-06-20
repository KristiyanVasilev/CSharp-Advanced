namespace OfficeStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OfficeStuff
    {
        public static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            var companies = new List<Company>();

            for (int i = 0; i < num; i++)
            {
                var line = Console.ReadLine()
                .Trim('|')
                .Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                var companyName = line[0];
                var amount = int.Parse(line[1]);
                var product = line[2];

                companies.Add(new Company(companyName, amount, product));
            }
            var groupedCompanies = companies
                .GroupBy(c => c.CompanyName)
                .OrderBy(x => x.Key);

            foreach (var company in groupedCompanies)
            {
                Console.Write(company.Key + ": ");
                var products = company.GroupBy(pr => pr.Product)
                    .Select(gr => new
                    {
                        ProdName = gr.Key,
                        Amount = gr.Sum(x => x.Amount)
                    });
                Console.WriteLine(string.Join(", ", products.Select(x => $"{x.ProdName}-{x.Amount}")));
            }
        }

        public class Company
        {
            public string CompanyName { get; set; }
            public int Amount { get; set; }
            public string Product { get; set; }
            public Company(string companyName, int amount, string product)
            {
                this.CompanyName = companyName;
                this.Amount = amount;
                this.Product = product;
            }
        }
    }
}
