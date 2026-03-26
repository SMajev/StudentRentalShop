namespace StudentRentalShop.service;

public class LoanService
{
    private static LoanService _instance;
    
    // Singleton private constructor
    private LoanService()
    {
        
    }

    public static LoanService getInstance()
    {
        if (_instance == null)
        {
            _instance = new LoanService();
        }
        return _instance;
    }
    
}