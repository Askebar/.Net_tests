namespace Classes;

public class BankAccount{

    private static int s_accountNumberSeed = 1234567890;
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance {
        get{
            decimal balance = 0;
            foreach(var item in _allTransactions){
                balance += item.Amount;
            }
            return balance;
        }
    }

    public BankAccount(string name, decimal initialBalance){ //constructer
    Number = s_accountNumberSeed.ToString();
    s_accountNumberSeed++;

    Owner = name;
    MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }

    private List<Transaction> _allTransactions = new List<Transaction>();

    public void MakeDeposit(decimal amount, DateTime date, string note){
        if (amount <= 0){
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount for deposit most be positive");
        }
        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note){
        if (amount <= 0){
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount for withdrawl most be positive");
        }
        if(Balance - amount < 0){
            throw new InvalidOperationException("you dont have the amount for this");//keep an eye on these
        }
        var withdrawl = new Transaction(-amount, date, note);
        _allTransactions.Add(withdrawl);
    }
    public string GetAccountHistory(){
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach(var item in _allTransactions){
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }
        return report.ToString();
    }
}



/*namespace Classes;

public class BankAccount{
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance { get; set; }

    public void BackAccount(string name, decimal intialBalance){
        Owner = name;
        Balance = intialBalance;
    }

    public void MakeDeposit(decimal amount, DateTime date, string note){
        
    }

    public void MakeWithdrawal(decimal amount, DateTime data, string note){

    }
}
*/