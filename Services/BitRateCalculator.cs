using BitRateCalculator.Interfaces;
using BitRateCalculator.Models;

namespace BitRateCalculator.Services
{
    public class BitrateCalculator : IBitrateCalculator
    {
        public (double RxBps, double TxBps) Calculate(NetworkInterface previous, NetworkInterface current, double intervalSeconds)
        {
            //to get rate, take two samples 
            long rxDiff = current.Rx - previous.Rx;
            long txDiff = current.Tx - previous.Tx;

            //bits=byte*8
            //get bit per sec
            double rxBps = (rxDiff * 8.0) / intervalSeconds;
            double txBps = (txDiff * 8.0) / intervalSeconds;

            return (rxBps, txBps);
        }
    }
}