using IndianStateCensusAnlyzer;
using IndianStateCensusAnlyzer.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnlyzer.CensusAnalyser;

namespace CensualAnalyserTest
{
    public class Tests
    {

        //CensusAnalyser.CensusAnalyser censusAnalyser;

        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusFilePath = @"C:\Users\Shubham\source\IndianStateCensusAnlyser\CensualAnalyserTest\CsvFiles\IndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\Shubham\source\IndianStateCensusAnlyser\CensualAnalyserTest\CsvFiles\WrongIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\Shubham\source\IndianStateCensusAnlyser\CensualAnalyserTest\CsvFiles\IndianStateCensusData.txt";
        static string wrongDelimiterIndianCensusFilePath = @"C:\Users\Shubham\source\IndianStateCensusAnlyser\CensualAnalyserTest\CsvFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongHeader = "Name,Email,City,Phone,Zip";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCodeFilePath = @"C:\Users\Shubham\source\IndianStateCensusAnlyser\CensualAnalyserTest\CsvFiles\IndiaStateCode.csv";
        static string wrongDelimiterIndianStateCodeFilePath = @"C:\Users\Shubham\source\IndianStateCensusAnlyser\CensualAnalyserTest\CsvFiles\DelimiterIndiaStateCode.csv";
        static string wrongIndianStateCodeFilePath = @"C:\Users\Shubham\source\IndianStateCensusAnlyser\CensualAnalyserTest\CsvFiles\WrongIndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\Shubham\source\IndianStateCensusAnlyser\CensualAnalyserTest\CsvFiles\IndianStateCode.txt";


        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        [Test]
        public void GivenWrongIndianCensusDataFilePath_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        [Test]
        public void GivenWrongIndianCensusDataWrongDelimiter_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongDelimiterIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        [Test]
        public void GivenWrongIndianCensusDataWrongHeader_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, wrongHeader));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }

        [Test]
        public void GivenIndianStateCodeFilePath_WhenRead_ShouldReturnCensusData()
        {
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenWrongIndianStateCodeFilePath_WhenRead_ShouldReturnCustomException_FILE_NOT_FOUND()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenRead_ShouldReturnCustomException_INVALIDFILETYPE()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCodeFileType, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }
        [Test]
        public void GivenWrongIndianStateDelimiterFile_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongDelimiterIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }
        [Test]
        public void GivenWrongIndianStateFileHeader_WhenRead_ShouldReturnCusotmException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, wrongHeader));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}