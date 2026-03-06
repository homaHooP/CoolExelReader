namespace Shared.Models
{
    public class packet
    {
        public string Type { get; set; }
        public string Text { get; set; }
        public string Sender { get; set; }

        public packet(string Type, string Text, string Sender)
        {
            this.Type = Type;
            this.Text = Text;
            this.Sender = Sender;
        }
    }
}
