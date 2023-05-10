namespace financeAPI.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Agency { get; set; }
        public int AccountNumber { get; set; }
        public int BankNumber { get; set; }
        public string BankName { get; set; }
        public string Observation { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Agency} {AccountNumber})";
        }

    }

}
