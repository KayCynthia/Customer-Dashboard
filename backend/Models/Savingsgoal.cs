namespace FinanceBackend.Models;
public class Savingsgoal 
{
    public int id {set; get;}//pk
    public decimal savingstarget {set; get;}// what the person is saving towards
    public string aim {set; get;}=string.Empty;// what the person is saving for
    public decimal currentsav {get;set;}//what is the current savings
    
}