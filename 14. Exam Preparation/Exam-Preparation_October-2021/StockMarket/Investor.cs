using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {

        public Investor(string fullName, string emailAdress, decimal moneyToInvest, string brokerName)
        {
            this.FullName = fullName;
            this.EmailAdress = emailAdress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
            this.Stocks = new List<Stock>();
        }

        public List<Stock> Stocks { get; set; }
        public string FullName { get; set; }
        public string EmailAdress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public int Count()
        {
            return this.Stocks.Count;
        }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000m && this.MoneyToInvest >= stock.PricePerShare)
            {
                this.Stocks.Add(stock);
                this.MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock targetStock = this.Stocks.FirstOrDefault(x => x.CompanyName == companyName);

            if (targetStock == null)
            {
                return $"{companyName} does not exist.";
            }

            if (sellPrice < targetStock.PricePerShare)
            {
                return $"Cannot sell {companyName}";
            }

            this.MoneyToInvest += sellPrice;
            this.Stocks.Remove(targetStock);
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            Stock targetStock = this.Stocks.FirstOrDefault(x => x.CompanyName == companyName);

            if (targetStock == null)
            {
                return null;
            }

            return targetStock;
        }

        public Stock FindBiggestCompany()
        {
            Stock biggestCompany = this.Stocks
                .OrderByDescending(x => x.MarketCapitalization)
                .Take(1)
                .FirstOrDefault();

            if (biggestCompany == null)
            {
                return null;
            }

            return biggestCompany;
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            foreach (Stock stock in this.Stocks)
            {
                sb.AppendLine(stock.ToString());
            }

            return sb.ToString();
        }
    }
}
