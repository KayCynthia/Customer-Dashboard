namespace FinanceBackend.Models;
public class Transaction
{
    public int id {get; set;} //int/primary key for the table
    public decimal amount {get; set;} //for the amount spent or recived
    public string type {get; set;}=string.Empty; // was it an expense or an income
    public string category {get; set;}=string.Empty; // what was the moeny spent on rent , groceries , funmoney , transport ,debt
    public string Month {get; set;}=string.Empty; //for the month since we are working strickly with months
    public decimal savings {set; get;}// for savings goal calculation
}