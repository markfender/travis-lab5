using Lab5;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        /// <summary>
        /// Тест метода процентного соотношения
        /// </summary>
        [Test]
        public void TestP()
        {
            float[][] StartArray = new float[3][];

            StartArray[0] = new float[] { 0, 0, 4, 8, 4, 0, 0, 0, 0, 0 };
            StartArray[1] = new float[] { 0, 0, 0, 0, 0, 10, 0, 0, 0, 0 };
            StartArray[2] = new float[] { 0, 0, 0, 0, 3, 6, 0, 0, 0, 0 };

            float[][] FinishArray = new float[3][];

            FinishArray[0] = new float[] { 0, 0, 0.25f, 0.5f, 0.25f, 0, 0, 0, 0, 0 };
            FinishArray[1] = new float[] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 };
            FinishArray[2] = new float[] { 0, 0, 0, 0, 0.333333343f, 0.6666667f, 0, 0, 0, 0 };

            for (int i = 0;i < 3;i++)
            {
                float[] Finish = Methods.P(StartArray[i]);
                for(int j = 0;j<10;j++)
                  Assert.AreEqual(FinishArray[i][j],Finish[j]);
            }
        }

        /// <summary>
        /// Тест метода процентна от максимума
        /// </summary>
        [Test]
        public void TestK()
        {
            float[][] StartArray = new float[3][];

            StartArray[0] = new float[] { 0, 0, 4, 8, 4, 0, 0, 0, 0, 0 };
            StartArray[1] = new float[] { 0, 0, 0, 0, 0, 10, 0, 0, 0, 0 };
            StartArray[2] = new float[] { 0, 0, 0, 0, 3, 6, 0, 0, 0, 0 };

            float[][] FinishArray = new float[3][];

            FinishArray[0] = new float[] { 0, 0, 0.5f, 1, 0.5f, 0, 0, 0, 0, 0 };
            FinishArray[1] = new float[] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 };
            FinishArray[2] = new float[] { 0, 0, 0, 0, 0.5f, 1, 0, 0, 0, 0 };

            for (int i = 0; i < 3; i++)
            {
                float[] rezult = Methods.K(StartArray[i]);
                for (int j = 0; j < 10; j++)
                    Assert.AreEqual(FinishArray[i][j], rezult[j]);
            }
        }

        /// <summary>
        /// Тест метода градусов
        /// </summary>
        [Test]
        public void TestCircle()
        {
            float[][] StartArray = new float[3][];

            StartArray[0] = new float[] { 0, 0, 50, 0, 100, 200, 0, 50, 0, 100 };
            StartArray[1] = new float[] { 0, 0, 0, 0, 0, 15, 0, 0, 0, 0 };
            StartArray[2] = new float[] { 0, 0, 5, 0, 5, 5, 0, 0, 0, 5};

            float[][] FinishArray = new float[3][];

            FinishArray[0] = new float[] { 0, 0, 36, 0, 72, 144, 0, 36, 0, 72 };
            FinishArray[1] = new float[] { 0, 0, 0, 0, 0, 360, 0, 0, 0, 0 };
            FinishArray[2] = new float[] { 0, 0, 90, 0, 90, 90, 0, 0, 0, 90 };

            for (int i = 0; i < 3; i++)
            {
                float[] rezult = Methods.K_Circle(StartArray[i]);
                for (int j = 0; j < 10; j++)
                    Assert.AreEqual(FinishArray[i][j], rezult[j]);
            }
        }
    }
}
