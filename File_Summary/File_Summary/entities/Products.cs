namespace entities
{
    class Products
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public bool Tentativa { get; set; }

        public Products()
        {
            Tentativa = false;
        }
        public Products(string name, double price, int amount)
        {

            this.Name = name;
            this.Price = price;
            this.Amount = amount;
        }

        public double Total()
        {
            return Price * Amount;
        }

    }
}
