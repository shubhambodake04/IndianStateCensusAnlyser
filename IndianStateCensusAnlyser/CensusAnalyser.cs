using IndianStateCensusAnlyzer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnlyzer
{
    public class CensusAnalyser
    {
        public static int a = 10;
        public enum Country
        {
            INDIA, US, BRAZIL
        }
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, Country country, string dataHeaders)
        {
            //CensusAnalyser obj = new CensusAnalyser();
            //Console.WriteLine(obj.a);
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }

        public void LoadCensusData(object wrongIndianStateCensusFileType, Country iNDIA, string indianStateCensusFilePath)
        {
            throw new NotImplementedException();
        }
    }
}
