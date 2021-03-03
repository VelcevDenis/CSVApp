using CSVApp.Application.Contexts.Upload.ViewModels;
using CSVApp.Contract.Entity;
using CSVApp.DAL;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVApp.Application.Contexts.Upload.Queries.UploadCSVFile {

    public class UploadCSVFileQuery {
        private readonly ApplicationDbContext _context;

        public UploadCSVFileQuery() {
        }

        public UploadCSVFileQuery(ApplicationDbContext context) {
            _context = context;
        }

        public UploadeResultModel UploadCSVFile(IFormFile file) {
            var csvSalesList = new List<CSVSale>();
            var failed = 0;
            var dublicates = 0;
            var successfullyAdded = 0;

            var csvSales = _context.CSVSales
                .OrderBy(x => x.OrderDate)
                .ToList();

            if (file.FileName.EndsWith(".csv")) {
                using (var sreader = new StreamReader(file.OpenReadStream())) {
                    string[] headers = sreader.ReadLine().Split(',');     //Titles

                    while (!sreader.EndOfStream)                          //get all the content in rows 
                    {
                        string[] rows = sreader.ReadLine().Split(',');

                        try {
                            var csvSale = new CSVSale() {
                                Region = rows[0],
                                Country = rows[1],
                                ItemType = rows[2],
                                SalesChannel = rows[3],
                                OrderPriority = rows[4],
                                OrderDate = DateTime.Parse(rows[5]),
                                OrderID = long.Parse(rows[6]),
                                ShipDate = DateTime.Parse(rows[7]),
                                UnitsSold = int.Parse(rows[8]),
                                UnitPrice = decimal.Parse(rows[9]),
                                UnitCost = decimal.Parse(rows[10]),
                                TotalRevenue = decimal.Parse(rows[11]),
                                TotalCost = decimal.Parse(rows[12]),
                                TotalProfit = decimal.Parse(rows[13])
                            };
                            csvSalesList.Add(csvSale);
                            successfullyAdded++;

                        } catch {
                            failed++;
                        }
                    }
                    _context.BulkInsert(csvSalesList);
                }
            }
            return new UploadeResultModel {
                SuccessfullyAddedRows = successfullyAdded,
                FailedRows = failed,
                DublicatesRows = dublicates
            };
        }
    }
}

