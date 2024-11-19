using System.Data;

namespace Classes;

public class Transaction{ //simple object to hold the amount, date and a note
    public decimal Amount{ get; }
    public DateTime Date { get; }
    public string Notes { get; }

    public Transaction(decimal amount, DateTime date, string note){ //constructor
    Amount = amount;
    Date = date;
    Notes = note;
    }
}