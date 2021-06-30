namespace VendingMachine
{
    public interface IVendingMachineLogger
    {
        void DebugLog(string message);
        void ErrorLog(string message);
    }
}