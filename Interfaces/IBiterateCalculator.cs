using BitRateCalculator.Models;

namespace BitRateCalculator.Interfaces
{
    public interface IBitrateCalculator
    {
        (double RxBps, double TxBps) Calculate(NetworkInterface previous, NetworkInterface current, double intervalSeconds);
    }
}