namespace Shared.Models
{
    public class packet
    {
        public string Type { get; set; }
        public string Text { get; set; }
        public string[] ProdNames { get; set; }
        public List<product> Products { get; set; }
        public string Sender { get; set; }

        public packet() { }
        public packet(string Type, string Text, string Sender, List<product> Products)
        {
            this.Type = Type;
            this.Text = Text;
            this.Sender = Sender;
            this.Products = Products;
        }
        public packet(string Type, string Text, string Sender, String[] ProdNames)
        {
            this.Type = Type;
            this.Text = Text;
            this.Sender = Sender;
            this.ProdNames = ProdNames;
        }
        public packet(string Type, string Text, string Sender)
        {
            this.Type = Type;
            this.Text = Text;
            this.Sender = Sender;
        }
    }
}
