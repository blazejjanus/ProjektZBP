using System.Diagnostics;
using System.Text;
using ZBP.Data;

namespace ZBP.Tests {
    [TestClass]
    public class DataHelperTests {
        const int RECORDS_NUMBER = 100000;
        const string TEST_FILE = @"..\..\..\.tests\DataHelperTests.txt";

        [TestMethod]
        public void CombineTest() {
            var list1 = Mocker.GetTestRecords("CpiPln");
            var list2 = Mocker.GetTestRecords("CpiUsd");
            var list3 = Mocker.GetTestRecords("CpiEur");
            var list4 = Mocker.GetTestRecords("CpiChf");
            var result1 = DataHandler.Combine(list1, list2);
            Assert.IsNotNull(result1);
            var result2 = DataHandler.Combine(list3, list4);
            Assert.IsNotNull(result2);
            var result = DataHandler.Combine(result1, result2);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == list1.Count);
            WriteResult(result);
        }

        [TestMethod]
        public void CombineBenchmark() {
            var list1 = Mocker.GetTestRecords("CpiPln", RECORDS_NUMBER);
            var list2 = Mocker.GetTestRecords("CpiUsd", RECORDS_NUMBER);
            var start = DateTime.Now;
            var result = DataHandler.Combine(list1, list2);
            var end = DateTime.Now;
            var seconds = (end - start).TotalSeconds;
            Debug.WriteLine("Took " + seconds + "s to merge " + RECORDS_NUMBER + " records.");
            WriteResult(result);
        }

        [TestMethod]
        public void TestIsDaily() {
            var records = new List<Record>();
            records.Add(new Record(new DateOnly(2020, 01, 01)));
            records.Add(new Record(new DateOnly(2020, 01, 02)));
            Assert.IsTrue(DataHandler.IsDaily(records));
            records.Add(new Record(new DateOnly(2020, 01, 04)));
            Assert.IsTrue(DataHandler.IsDaily(records, 2));
            records.Add(new Record(new DateOnly(2020, 02, 01)));
            Assert.IsFalse(DataHandler.IsDaily(records));
        }

        [TestMethod]
        public void TestDateNormalization() {
            var records = new List<Record>();
            records.Add(new Record(new DateOnly(2020, 01, 01)));
            records.Add(new Record(new DateOnly(2020, 02, 01)));
            records.Add(new Record(new DateOnly(2020, 03, 01)));
            var records2 = DataHandler.NormalizeDates(records);
            Assert.IsTrue(DataHandler.IsDaily(records2));
            records.Add(new Record(new DateOnly(2019, 01, 01)));
            var records3 = DataHandler.NormalizeDates(records);
            Assert.IsTrue(DataHandler.IsDaily(records3));
        }

        private void WriteResult(List<Record> records) {
            var sb = new StringBuilder();
            foreach (var record in records) {
                sb.AppendLine(record.ToString(true));
            }
            string directoryPath = Path.GetDirectoryName(TEST_FILE) ?? "";
            if(!Directory.Exists(directoryPath)) {
                Directory.CreateDirectory(directoryPath);
            }
            File.AppendAllText(TEST_FILE, sb.ToString());
        }
    }
}
