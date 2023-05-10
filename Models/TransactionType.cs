namespace financeAPI.Models
{
    public class TransactionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }

    }
}
