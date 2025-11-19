using System;
using System.Windows.Forms;
using TradeDocsV3.Forms;

namespace TradeDocsV3;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new LoginForm());
    }
}