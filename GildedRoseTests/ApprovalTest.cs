﻿using Xunit;
using System;
using System.IO;
using System.Text;
using ApprovalTests.Reporters;
using GildedRose;

namespace GildedRoseTests
{
    [UseReporter(typeof(DiffReporter))]
    public class ApprovalTest
    {
        [Fact]
        public void ThirtyDays()
        {
            var fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            var output = fakeoutput.ToString();

            var result = File.ReadAllText("expectedResult.txt");
            
            Assert.Equal(result, output);
        }
    }
}
