using System;
using System.Collections.Generic;
using System.Text.Json;
using BitRateCalculator.Interfaces;
using BitRateCalculator.Models;
using BitRateCalculator.Services;

class Program
{
    private const double PollingIntervalSeconds = 0.5; // seconds/hz;1/2Hz   

    static void Main()
    {
        string json = @"{
            ""Device"": ""Arista"",
            ""Model"": ""X-Video"",
            ""NIC"": [{
                ""Description"": ""Linksys ABR"",
                ""MAC"": ""14:91:82:3C:D6:7D"",
                ""Timestamp"": ""2020-03-23T18:25:43.511Z"",
                ""Rx"": 3698574500,
                ""Tx"": 122558800
            }]
        }";

        IBitrateCalculator calculator = new BitrateCalculator();

        //deserialise theh jason
        var device = JsonSerializer.Deserialize<DeviceData>(json);


        foreach (var nic in device.NIC)
        {
            var next = new NetworkInterface
            {
                Description = nic.Description,
                MAC = nic.MAC,
                Timestamp = nic.Timestamp.AddSeconds(PollingIntervalSeconds),
                Rx = nic.Rx + 15000,
                Tx = nic.Tx + 3000
            };

            var (rxBps, txBps) = calculator.Calculate(nic, next, PollingIntervalSeconds);

            Console.WriteLine($"NIC: {nic.Description}");
            Console.WriteLine($"  RX Bitrate: {rxBps:N0} bps");
            Console.WriteLine($"  TX Bitrate: {txBps:N0} bps");
        }
        
    }
}
