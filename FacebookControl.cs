using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace toolFbNew
{
    class FacebookControl
    {
       

        public ChromeDriver driver;

        int WaitLoadTime = 120;

        int WaitStepTime = 3000;

        string ProfileFolderPath = "Profile";

        public void OpenonlyFB(string userFB, string passFB, string browser)
        {

            try
            {
                ChromeOptions options = new ChromeOptions();

                if (!Directory.Exists(ProfileFolderPath))
                {
                    Directory.CreateDirectory(ProfileFolderPath);
                }

                if (Directory.Exists(ProfileFolderPath))
                {
                    //int nameCount = 0;

                    options.AddArguments("user-data-dir=" + ProfileFolderPath + "\\" + userFB);
                }


                //driver = new ChromeDriver(options);

                //code hide cmd.exe
                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;

                driver = new ChromeDriver(service, options);

                if (browser == "1")
                {
                    driver.Manage().Window.Position = new Point(0, 0);
                    driver.Manage().Window.Size = new Size(640, 1080);
                }
                else
                {
                    if (browser == "2")
                    {
                        driver.Manage().Window.Position = new Point(640, 0);
                        driver.Manage().Window.Size = new Size(640, 1080);
                    }
                    else
                    {
                        if (browser == "3")
                        {
                            driver.Manage().Window.Position = new Point(1280, 0);
                            driver.Manage().Window.Size = new Size(640, 1080);
                        }
                    }
                }


                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WaitLoadTime);
                driver.Url = "http://fb.com/";


                driver.Navigate();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WaitLoadTime);

                //CheckTurnofFormControledAndRestore(browser);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WaitLoadTime);
                Thread.Sleep(WaitStepTime);
                driver.Navigate().Refresh();
                Thread.Sleep(WaitStepTime);



                
                LoginFacebook(userFB, passFB);
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cann't open!!!");
            }
        }

        public void LoginFacebook(string user, string pass)
        {
            try
            {
                InputUserFaceBook(user);
                Thread.Sleep(WaitStepTime);
                InputPassFaceBook(pass);
                Thread.Sleep(WaitStepTime);
                ClickButtonLoginFB();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cann't Login FB!!!", "Infor", MessageBoxButtons.OK);
            }
        }

        private void InputUserFaceBook(string user)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WaitLoadTime);
            var textUser = driver.FindElementByXPath("//*[@id=\"email\"]");
            textUser.SendKeys(user);
        }

        private void InputPassFaceBook(string pass)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WaitLoadTime);
            var textPass = driver.FindElementByXPath("//*[@id=\"pass\"]");
            textPass.SendKeys(pass);
        }

        private void ClickButtonLoginFB()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WaitLoadTime);
            var buttonLogin = driver.FindElementByName("login");
            buttonLogin.Click();

        }

        public void testing()
        {
            ChromeDriver chromeDriver = new ChromeDriver();

            chromeDriver.Url = "http://www.howkteam.com/";
            chromeDriver.Navigate();
        }

    }
}
