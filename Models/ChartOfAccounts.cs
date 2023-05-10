namespace financeAPI.Models
{
    public class ChartOfAccounts
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public bool ShowIncomeStatement { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
