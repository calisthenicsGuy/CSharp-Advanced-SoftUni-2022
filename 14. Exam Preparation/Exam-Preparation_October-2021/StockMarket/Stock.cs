using System;
using System.Text;

namespace StockMarket
{
    public class Stock
    {
        private string companyName;
        private string director;
        private decimal pricePerShare;
        private int totalNumberOfShares;


        public Stock(string companyName, string director, decimal pricePerShare, int totalNumbersOfShare)
        {
            this.CompanyName = companyName;
            this.Director = director;
            this.PricePerShare = pricePerShare;
            this.TotalNumberOfShares = totalNumbersOfShare;
        }


        public string CompanyName 
        { 
            get => this.companyName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Company name cannot be null or white space");
                }
                this.companyName = value;
            }
        }
        public string Director
        {
            get => this.director;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Director name cannot be null or white space");
                }
                this.director = value;
            }
        }
        public decimal PricePerShare
        {
            get => this.pricePerShare;
            set
            {
                if (pricePerShare < 0)
                {
                    throw new ArgumentException("Price Per Share cannot be smaller than zero.");
                }
                this.pricePerShare = value;
            }
        }
        public int TotalNumberOfShares
        {
            get => this.totalNumberOfShares;
            set
            {
                this.totalNumberOfShares = value;
            }
        }
        public decimal MarketCapitalization
        {
            get
            { 
                return this.pricePerShare * (decimal)this.totalNumberOfShares;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Company: {this.CompanyName}");
            sb.AppendLine($"Director: {this.Director}");
            sb.AppendLine($"Price per share: ${this.PricePerShare}");
            sb.AppendLine($"Market Capitalization: ${this.MarketCapitalization}");

            return sb.ToString();
        }
    }
}
