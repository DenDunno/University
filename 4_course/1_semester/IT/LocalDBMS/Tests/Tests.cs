using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void StringValidation()
        {
            AcceptValidation(new StringValidation(), "");
            AcceptValidation(new StringValidation(), "123");
            AcceptValidation(new StringValidation(), "dsiuhlknj1235");
        }
        
        [Test]
        public void IntValidation()
        {
            AcceptValidation(new IntValidation(), 1);
            AcceptValidation(new IntValidation(), 23453456);
            
            CatchException<FormatException>(new IntValidation(), "0.123");
            CatchException<FormatException>(new IntValidation(), "sdfg");
            CatchException<FormatException>(new IntValidation(), "");
        }

        [Test]
        public void CharValidation()
        {
            AcceptValidation(new CharValidation(), 1);
            AcceptValidation(new CharValidation(), " ");
            AcceptValidation(new CharValidation(), "9");
            
            CatchException<Exception>(new CharValidation(), "asd");
            CatchException<Exception>(new CharValidation(), "");
        }

        [Test]
        public void RealValidation()
        {
            AcceptValidation(new RealValidation(), "0,111");
            AcceptValidation(new RealValidation(), "123,66");
            
            CatchException<FormatException>(new RealValidation(), "sdfg");
            CatchException<FormatException>(new RealValidation(), "");
        }

        [Test]
        public void DateValidation()
        {
            AcceptValidation(new DateValidation(), "02.02.2020");
            AcceptValidation(new DateValidation(), "05.07.2045");
            
            CatchException<FormatException>(new DateValidation(), "23.23.2020");
            CatchException<FormatException>(new DateValidation(), " ");
        }
        
        [Test]
        public void ColorValidation()
        {
            AcceptValidation(new ColorValidation(), "#AAAAAA");
            AcceptValidation(new ColorValidation(), "#123456");
            AcceptValidation(new ColorValidation(), "#abcdef");
            
            CatchException<Exception>(new ColorValidation(), "#12345");
            CatchException<Exception>(new ColorValidation(), "#j23456");
            CatchException<Exception>(new ColorValidation(), "xdfg");
        }

        private void CatchException<T>(IValidation validation, object invalidValue) where T : Exception
        {
            Assert.Throws<T>(()=> validation.Apply(invalidValue));
        }
        
        private void AcceptValidation(IValidation validation, object validValue)
        {
            Assert.DoesNotThrow(()=> validation.Apply(validValue));
        }
    }
}