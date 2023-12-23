using DAL;
using DomainModel;
using Interfaces.Services;
using BLL.DTO;
using Interfaces.Repository;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces.DTO;

namespace BLL.Services
{
    public class ReportService : IReportService
    {
        private IDbRepos db;

        public ReportService(IDbRepos repos)
        {
            db = repos;
        }

        public List<SPResult> ExecuteSP(string adress, int numeric, string number)
        {

            return db.Reports.ExecuteSP(adress, numeric,number).Select(i => new SPResult { id = i.id, order_status = i.order_status, summ = i.summ, adress = i.adress, dish = i.dish, delivery_price = i.delivery_price, number_cli = i.number_cli }).ToList();
        }

        public List<ReportData> ReportOrdersWithDelivery(int orderId)
        {
            var request = db.Reports.ReportOrdersWithDelivery(orderId)
             .Select(i => new ReportData() { Dish = i.Dish, Summ = i.Summ, adress = i.adress, id_order = i.id_order, number_cli = i.number_cli })
             .ToList();
            return request;
        }
        public int revenueDay()
        {
            int request = db.Reports.revenueDay();
            return request;
        }
        public int revenueMonth()
        {
            int request = db.Reports.revenueMonth();
            return request;
        }
        public int profitMonth()
        {
            int request = db.Reports.profitMonth();
            return request;
        }
        public int profitDay()
        {
            int request = db.Reports.profitDay();
            return request;
        }
    }
}
