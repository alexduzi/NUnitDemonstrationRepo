using NUnit.Framework;
using NUnitSimpleSample.Test.TestAttributes;
using NUnitSimpleSample.Test.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NUnitSimpleSample.Test.Basic
{
  [TestFixture, Description("Basic test class using NUnit")]
  public class BasicClassTest 
  {
    public TestContext Context 
    { 
      get
      {
        return TestContext.CurrentContext;
      }
    }

    [TestFixtureSetUp]
    public void SetUpClass()
    {

    }

    [TestFixtureTearDown]
    public void TearDownClass()
    {

    }

    [SetUp]
    public void SetUp()
    {
      Calculator = new Calculator();
    }

    [TearDown]
    public void TearDown()
    {

    }

    public Calculator Calculator { get; set; }

    [Test]
    [ConsoleAction("Sum test")]
    public void Can_I_Sum_Two_Values()
    {
      double value1 = 5.4;
      double value2 = 6.2;
      double expectedResult = value1 + value2;

      Calculator.Sum(value1, value2);

      Assert.AreEqual(expectedResult, Calculator.Result);
    }

    [Test]
    [ConsoleAction("Subtract test")]
    public void Can_I_Subtract_Two_Values()
    {
      double value1 = 5.4;
      double value2 = 6.2;
      double resultExpected = value1 - value2;

      Calculator.Subtract(value1, value2);

      Assert.AreEqual(resultExpected, Calculator.Result);
    }

    [Test]
    [ConsoleAction("Multiply test")]
    public void Can_I_Multiply_Two_Values()
    {
      double value1 = 5.4;
      double value2 = 6.2;
      double expectedResult = value1 * value2;

      Calculator.Multiply(value1, value2);

      Assert.AreEqual(expectedResult, Calculator.Result);
    }

    [Test]
    [ConsoleAction("Divide test")]
    public void Can_I_Divide_Two_Values()
    {
      double value1 = 5.4;
      double value2 = 6.2;
      double expectedResult = value1 / value2;

      Calculator.Divide(value1, value2);

      Assert.AreEqual(expectedResult, Calculator.Result);
    }

    [Test]
    [ConsoleAction("Divide by zero test")]
    [ExpectedException(typeof(DivideByZeroException))]
    public void Can_I_Divide_By_Zero()
    {
      double value1 = 5.4;
      double value2 = 0.0;
      double resultExpected = value1 / value2;

      Calculator.Divide(value1, value2);
    }

    [Test, Combinatorial]
    [ConsoleAction("Sum with combinatorial values")]
    public void Can_I_Sum_Two_Values_With_Combinatorial_Values( [Values(4.7, 4.8, 4.9, 8.9)] double value1,
                                                                [Values(1.2, 2.2, 3.3, 5.6)] double value2)
    {
      double expectedResult = value1 + value2;

      Calculator.Sum(value1, value2);

      Assert.AreEqual(expectedResult, Calculator.Result);
    }

    [Test]
    [ConsoleAction("Sum with random values")]
    public void Can_I_Sum_Two_Values_With_Random_Values( [Random(1.1, 9.7, 2)] double value1,
                                                         [Random(1.0, 12.2, 3)] double value2)
    {
      double expectedResult = value1 + value2;

      Calculator.Sum(value1, value2);

      Assert.AreEqual(expectedResult, Calculator.Result);
    }


    [Test]
    [ConsoleAction("Collatz Conjecture tests")]
    public void Can_Collatz_Return_Allways_One([Values(500, 999, 448)] int value)
    {
      var collatzList = CollatzConjectureSequence.CollatzConjecture(value);

      Assert.IsTrue(collatzList.Last() == 1);
    }

    [Datapoints]
    public int[] valuesCollatzConjecture = new int[] { 500, 999, 448, 3456 };

    [Theory]
    [ConsoleAction("Collatz Conjecture tests using theory")]
    public void Can_Collatz_Return_Allways_One_Using_Theory(int value)
    {
      Assume.That(value >= 1);

      IEnumerable<int> collatzList = CollatzConjectureSequence.CollatzConjecture(value);

      Assert.That(value >= 1);
      Assert.That(collatzList.Last() == 1);
    }

    [Theory]
    [ConsoleAction("Collatz Conjecture tests using theory")]
    public void Can_Collatz_Return_Allways_One_Using_Theory_2(int value)
    {
      Assume.That(value >= 1);

      IEnumerable<int> collatzList = CollatzConjectureSequence.CollatzConjecture(value);

      Assert.That(value >= 1);
      Assert.That(collatzList.Last() == 1);
    }

  }

  public class Calculator
  {
    public double Result { get; set; }

    public void Sum(double value1, double value2)
    {
      Result = value1 + value2;
    }

    public void Subtract(double value1, double value2)
    {
      Result = value1 - value2;
    }

    public void Multiply(double value1, double value2)
    {
      Result = value1 * value2;

    }

    public void Divide(double value1, double value2)
    {
      if (value2 == 0.0)
      {
        throw new DivideByZeroException();
      }

      Result = value1 / value2;
    }

  }

  public class ParameterSource : IEnumerable
  {

    public IEnumerator GetEnumerator()
    {
      var rand = new Random();

      foreach (var item in Enumerable.Range(0, 10))
        yield return new Value()
        {
          Value1 = string.Format("{0}", rand.Next(100)),
          Value2 = string.Format("{0}", rand.Next(100)),
          Value3 = string.Format("{0}", rand.Next(100))
        };

    }
  }

  public class Value
  {
    public string Value1 { get; set; }
    public string Value2 { get; set; }
    public string Value3 { get; set; }
  }
}
