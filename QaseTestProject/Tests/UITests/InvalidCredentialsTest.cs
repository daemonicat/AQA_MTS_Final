﻿using Allure.Net.Commons;
using Allure.NUnit.Attributes;

namespace QaseTestProject.Tests.UITests;

public class InvalidCredentialsTest : BaseTest
{
    [Test(Description = "Negative login test")]
    [Category("Regression")]
    [AllureSeverity(SeverityLevel.blocker)]
    public void InvalidLoginTest()
    {
        Assert.That(
            LoginSteps.UnsuccessfulLogin("blah@blah.com", "definitelyWrongPassword")
                .ErrorAlert.Text.Trim(),
            Is.EqualTo("These credentials do not match our records."));
    }
}