namespace AspNetSwaggerApi.Models
{
    public class ApiPegawaiModel
    {
        public int Id { get; set; }

        public required string Nama { get; set; }

        public required string Jabatan { get; set; }

        public float Gaji { get; set; }
    }
}