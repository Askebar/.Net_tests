namespace Classes;

public class BankAccount{

    private static int s_accountNumberSeed = 1234567890; //a number that will be increased by one each time we make a new account
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance {    //to get the balance we add all the differnt transactions made on the account
        get{
            decimal balance = 0;
            foreach(var item in _allTransactions){
                balance += item.Amount;
            }
            return balance;
        }
    }

    public BankAccount(string name, decimal initialBalance){ //constructer
    Number = s_accountNumberSeed.ToString(); //saves the current accountNumberSeed to the number of the bank id
    s_accountNumberSeed++; //indentates the seed so next bank account have a new number.

    Owner = name; //assigns the name to owner
    MakeDeposit(initialBalance, DateTime.Now, "Initial balance"); //make a depposit to set up the account
    }

    private List<Transaction> _allTransactions = new List<Transaction>(); //makes _allTransactions a List of Transactions

    public void MakeDeposit(decimal amount, DateTime date, string note){
        if (amount <= 0){ //if the amount is negative or zero we throw a error and exit the method
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount for deposit most be positive");
        }
        var deposit = new Transaction(amount, date, note); //make the transaction
        _allTransactions.Add(deposit);//add the transaction to the list
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note){
        if (amount <= 0){ //if the amount is negative or zero we throw a error and exit the method
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount for withdrawl most be positive");
        }
        if(Balance - amount < 0){ //if there isnt enough on the account we throw and exit the method
            throw new InvalidOperationException("you dont have the amount for this"); 
        }
        var withdrawl = new Transaction(-amount, date, note); //make the transaction
        _allTransactions.Add(withdrawl); //add the transaction to the list
    }
    public string GetAccountHistory(){ //method to display the list of transactions on the account
        var report = new System.Text.StringBuilder(); //makes use of the stringbuilder to format the string

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote"); //makes the line with indentation between each field
        foreach(var item in _allTransactions){  //takes each item and prints the transactions
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}"); //makes the currect indentations
        }
        return report.ToString(); //prints the whole repport
    }
}