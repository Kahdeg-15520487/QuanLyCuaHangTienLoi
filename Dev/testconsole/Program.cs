using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using QRCoder;

using QuanLyCuaHangTienLoi.Data;
using QuanLyCuaHangTienLoi.Data.Implementation;
using QuanLyCuaHangTienLoi.Data.Models;

using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace testconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CuaHangTienLoiDbContext context = new CuaHangTienLoiDbContext();

            Repository<SanPham> spRepo = new Repository<SanPham>(context);

            var sps = spRepo.GetAll();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            foreach (var sp in sps)
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(sp.Id.ToString(), QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(4);
                qrCodeImage.Save(sp.TenSanPham + ".png");
            }

            Console.ReadLine();
        }
    }
}
