using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1() 
		{
			var sum = 15 + 15;
			Assert.AreEqual(sum, 30);
		}

		[TestMethod]
		public void TestMethod2()
		{
			double longDigit = 0;
			for (int i = 0; i < 100000; i++)
			{
				for(int k = 0; k < 10000; k++)
				{
					longDigit += i * k;
				}
			}
			Assert.AreEqual(1, 1);
		}

		[TestMethod]
		public void TestMethod3()
		{
			double longDigit = 0;
			for (int i = 0; i < 100000; i++)
			{
				for (int k = 0; k < 100000; k++)
				{
					longDigit += i * k;
				}
			}
			Assert.AreEqual(1, 1);
		}

		[TestMethod]
		public void TestMethod4()
		{
			double longDigit = 0;
			for (int i = 0; i < 100; i++)
			{
				for (int k = 0; k < 100; k++)
				{
					longDigit += i * k;
				}
			}
			Assert.AreEqual(1, 1);
		}

		[TestMethod]
		public void TestMethod5()
		{
			double longDigit = 0;
			for (int i = 0; i < 100000; i++)
			{
				for (int k = 0; k < 10000; k++)
				{
					longDigit += i * k;
				}
			}
			Assert.AreEqual(1, 1);
		}

		[TestMethod]
		public void TestMethod6()
		{
			double longDigit = 0;
			for (int i = 0; i < 100000; i++)
			{
				for (int k = 0; k < 10000; k++)
				{
					longDigit += i * k;
				}
			}
			Assert.AreEqual(1, 1);
		}
	}
}
