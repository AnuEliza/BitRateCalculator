using BitRateCalculator.Interfaces;
using BitRateCalculator.Models;

namespace BitRateCalculator.Services
{
    public class BitrateCalculator : IBitrateCalculator
    {
        public (double RxBps, double TxBps) Calculate(NetworkInterface previous, NetworkInterface current, double intervalSeconds)
        {
            long rxDiff = current.Rx - previous.Rx;
            long txDiff = current.Tx - previous.Tx;

            double rxBps = (rxDiff * 8.0) / intervalSeconds;
            double txBps = (txDiff * 8.0) / intervalSeconds;

            return (rxBps, txBps);
        }
    }
}