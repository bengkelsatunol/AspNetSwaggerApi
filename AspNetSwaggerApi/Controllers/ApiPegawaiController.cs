using System.Collections;
using AspNetSwaggerApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSwaggerApi.Controllers
{

    public class ApiPegawaiController : ControllerBase
    {
        // Create an instance of List<ApiPegawaiModel>
        List<ApiPegawaiModel> pegawaiList = new List<ApiPegawaiModel>
        {
            new ApiPegawaiModel { Id = 1, Nama = "Alice", Jabatan = "Developer", Gaji = 5000f },
            new ApiPegawaiModel { Id = 2, Nama = "Bob", Jabatan = "Manager", Gaji = 7000f },
            new ApiPegawaiModel { Id = 3, Nama = "Charlie", Jabatan = "Analyst", Gaji = 4500f }
        };

        [HttpGet("/pegawai")]
        public IActionResult Index()
        {

            // Add instances of ApiPegawaiModel to the ArrayList
            pegawaiList.Add(new ApiPegawaiModel { Id = 4, Nama = "Alice", Jabatan = "Developer", Gaji = 5000f });
            pegawaiList.Add(new ApiPegawaiModel { Id = 5, Nama = "Bob", Jabatan = "Manager", Gaji = 7000f });
            pegawaiList.Add(new ApiPegawaiModel { Id = 6, Nama = "Charlie", Jabatan = "Analyst", Gaji = 4500f });

            var response = new
            {
                Code = 200,
                Message = "data ditampilkan",
                Data = pegawaiList.ToList()
            };
            return new JsonResult(response);
        }

        [HttpPost("/pegawai")]
        // frombody akan membuat data yang dipassing dalam bentuk json
        // tanpa frombody akan membuat data yang dipassing dalam bentu query string
        public IActionResult Create([FromBody] ApiPegawaiModel apiPegawaiModel)
        {
            if(apiPegawaiModel == null) {
                return BadRequest("Invalid Data");
            }

            pegawaiList.Add(apiPegawaiModel);
            return new JsonResult(new {
                Code = 200,
                Message = "data ditambahkan",
                Data = pegawaiList.ToList()
            });
        }
    }
}