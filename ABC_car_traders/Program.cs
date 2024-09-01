using ABC_car_traders.Utils;
using ABC_Car_Traders;
using ABC_Car_Traders.Data;
using System;
using System.Windows.Forms;


namespace ABC_car_traders
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var context = new AppDbContext())
            {
                //// Instantiate ActiveUser class and update user activity status
                ActiveUsers activeUsers = new ActiveUsers(context);
                activeUsers.UpdateUserActivityStatus();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login_form());
        }
    }
}
