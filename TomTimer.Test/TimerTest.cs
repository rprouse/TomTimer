// **********************************************************************************
// The MIT License (MIT)
// 
// Copyright (c) 2014 Rob Prouse
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 
// **********************************************************************************

#region Using Directives

using System.Threading.Tasks;
using Alteridem.TomTimer.Common;
using NUnit.Framework;

#endregion

namespace Alteridem.TomTimer.Test
{
    [TestFixture]
    public class TimerTest
    {
        [Test]
        public async Task TestTimerDueTime()
        {
            var counter = new CallCounter();
            using(new Timer(TimerCallback, counter, 100, 10000))
            {
                await Task.Delay( 300 );
            }
            Assert.That( counter.Count, Is.EqualTo( 1 ) );
        }

        [Test]
        public async Task TestTimerPeriod()
        {
            var counter = new CallCounter();
            using(new Timer(TimerCallback, counter, 100, 100))
            {
                await Task.Delay(350);
            }
            Assert.That(counter.Count, Is.EqualTo(3));
        }

        [Test]
        public async Task TestCancelTimer()
        {
            var counter = new CallCounter();
            using(var timer = new Timer(TimerCallback, counter, 100, 100))
            {
                timer.Cancel();
                await Task.Delay(200);
            }
            Assert.That(counter.Count, Is.EqualTo(0));
        }

        private void TimerCallback(object state)
        {
            var counter = state as CallCounter;
            if(counter != null) counter.Increment();
        }

        private class CallCounter
        {
            public CallCounter()
            {
                Count = 0;
            }

            public int Count { get; private set; }

            public void Increment()
            {
                Count++;
            }
        }
    }
}