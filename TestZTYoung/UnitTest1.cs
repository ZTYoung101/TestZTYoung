using SF2022User01Lib;

namespace TestZTYoung
{
    public class Tests
    {
        Calculations calculations;
        [SetUp]
        public void Setup()
        {
            calculations = new Calculations();
        }



        [Test]
        public void TestTimeWithMinus()
        {
            TimeSpan[] start_Times = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };

            int consultation_Time = -30;

            TimeSpan begin_Working_Time = new TimeSpan(8, 0, 0);
            TimeSpan end_Working_Time = new TimeSpan(18, 0, 0);
            Assert.Throws<ArgumentException>(() => calculations.AvailablePeriods(start_Times, durations, begin_Working_Time, end_Working_Time, consultation_Time));
        }

        [Test]
        public void TestBigConsultationTime()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };

            int consultationTime = 543;
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            Assert.Throws<ArgumentException>(() => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }

        [Test]
        public void TestTrueExample()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };

            int consultationTime = 30;
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            Assert.DoesNotThrow(() => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }



        //Пу-пу-пу-пу-пу-пу-пу-пу заварю-ка кофейку





        [Test]
        public void TestNotCorrectingTestingPeriods()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 60, 10, 40 };

            int consultationTime = 30;

            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            string[] result = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            string[] strings = new string[] {"08:00 - 08:30","08:30 - 09:00","09:00 - 09:30","09:30 - 10:00","10:00 - 10:30","10:30 - 11:00",
                                             "11:30 - 12:00","12:00 - 12:30","12:30 - 13:00","13:00 - 13:30","13:30 - 14:00","14:00 - 14:30",
                                             "14:30 - 15:00","15:40 - 16:10","16:10 - 16:40","17:30 - 18:00",};

            Assert.That(strings, Is.Not.EqualTo(result));
        }

        [Test]
        public void TestNotUntilEndSchedule()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 60, 10, 40 };

            int consultationTime = 30;
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            string[] result = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            string[] strings = new string[] {"08:00 - 08:30","08:30 - 09:00","09:00 - 09:30","09:30 - 10:00","10:00 - 10:30","10:30 - 11:00",
                                             "11:30 - 12:00","12:00 - 12:30","12:30 - 13:00","13:00 - 13:30","13:30 - 14:00","14:00 - 14:30","14:30 - 15:00"};

            Assert.That(strings, Is.Not.EqualTo(result));
        }

        [Test]
        public void TestNotDurations()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 0, 0, 0, 0, 0 };

            int consultationTime = 30;

            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);

            string[] strings = new string[] {"08:00 - 08:30","08:30 - 09:00","09:00 - 09:30","09:30 - 10:00","10:00 - 10:30","10:30 - 11:00",
                                             "11:00 - 12:00","12:00 - 12:30","12:30 - 13:00","13:00 - 13:30","13:30 - 14:00","14:00 - 14:30",
                                             "14:30 - 15:00","15:00 - 15:30","15:30 - 16:00","16:00 - 16:30","16:30 - 17:00","17:00 - 17:30",
                                             "17:30 - 18:00"};
            Assert.Catch(typeof(ArgumentException), () => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }

        [Test]
        public void CheckingConsultationTimeParameter()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };

            int[] durations = new int[] { 60, 30, 10, 10, 40 };

            int consultationTime = 40;

            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            string[] result = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            string[] strings = new string[] {"08:00 - 08:40","08:40 - 09:20","09:20 - 10:00","11:30 - 12:10","12:10 - 12:50",
                                             "12:50 - 13:30","13:30 - 14:10","14:10 - 14:50","15:40 - 16:20",};
            Assert.AreEqual(result, strings);
        }

    }
}