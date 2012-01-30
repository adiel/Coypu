﻿using System;
using NSpec;
using NUnit.Framework;

namespace Coypu.Drivers.Tests
{
    public class When_forced_to_find_invisible_elements : DriverSpecs
    {
        internal override void Specs()
        {
            it["does find hidden inputs"] = () =>
            {
                try
                {
                    Assert.That(driver.FindField("firstHiddenInputId").Value, Is.EqualTo("first hidden input"));
                }
                finally
                {
                }
                Assert.Throws<MissingHtmlException>(() => driver.FindField("firstHiddenInputId"));
            };

            it["does find invisible elements"] = () =>
            {
                try
                {
                    Assert.That(driver.FindButton("firstInvisibleInputId").Name, Is.EqualTo("firstInvisibleInputName"));
                }
                finally
                {
                }
                Assert.Throws<MissingHtmlException>(() => driver.FindButton("firstInvisibleInputId"));
            };
        }
    }
}