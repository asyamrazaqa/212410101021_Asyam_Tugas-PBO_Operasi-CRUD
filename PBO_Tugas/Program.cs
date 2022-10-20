using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web;
using Npgsql;

namespace _212410101021_Asyam_Operasi_CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DBHelperCLI cliApp = new DBHelperCLI();

        }
    }

    public class DBhelper
    {
        private NpgsqlConnection connect;

        public DBhelper()
        {
            connect = new NpgsqlConnection();
            connect.ConnectionString = "Host=localhost; Username=postgres; Password=Asyam123; Database=PBO_Tugas; CommandTimeout=10";
        }

        public void DBInsert(string nama1 = "-")
        {
            try
            {
                connect.Open();
                NpgsqlCommand query = new NpgsqlCommand();
                query.Connection = connect;
                string querySql = "INSERT INTO pegawai VALUES ('"+ nama1 +"')";
                query.CommandText = querySql;
                query.CommandType = CommandType.Text;
                query.ExecuteNonQuery();
                query.Dispose();
                connect.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public DataTable DBReader()
        {
            DataTable dataread = new DataTable();
            try
            {
                connect.Open();
                NpgsqlCommand query = new NpgsqlCommand();
                query.Connection = connect;
                string querySql = "SELECT * FROM pegawai;";
                query.CommandText = querySql;
                query.CommandType = CommandType.Text;
                NpgsqlDataAdapter adapterdata = new NpgsqlDataAdapter(query);

                adapterdata.Fill(dataread);
                query.Dispose();
                connect.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return dataread;
        }

        public void DBDelete(string nama = "0")
        {
            try
            {
                connect.Open();
                NpgsqlCommand query = new NpgsqlCommand();
                query.Connection = connect;
                string querySql = "DELETE FROM pegawai WHERE nama = '" + nama + "';";
                query.CommandText = querySql;
                query.CommandType = CommandType.Text;
                query.ExecuteNonQuery();
                query.Dispose();
                connect.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void DBUpdate(string nama, string nama2)
        {
            try
            {
                connect.Open();
                NpgsqlCommand query = new NpgsqlCommand();
                query.Connection = connect;
                string querySql = "UPDATE pegawai SET nama = '" + nama + "' WHERE nama = '" + nama2 + "';";
                query.CommandText = querySql;
                query.CommandType = CommandType.Text;
                query.ExecuteNonQuery();
                query.Dispose();
                connect.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }

    public class DBHelperCLI
    {

        private DBhelper dbcontrol = new DBhelper();
        public DBHelperCLI()
        {
            while (true)
            {
                Console.WriteLine("1. Tambah Data Tabel");
                Console.WriteLine("2. Lihat Data Tabel");
                Console.WriteLine("3. Ubah Data Tabel");
                Console.WriteLine("4. Hapus Data Tabel");
                Console.WriteLine("99. Keluar Program");
                Console.WriteLine("");
                Console.Write("Masukan Pilihan Berdasarkan Angka : ");
                var input = Console.ReadLine();

                if (input == "1")
                {
                    Console.Write("Masukkan nama pegawai: ");
                    var nama1 = Console.ReadLine();

                    dbcontrol.DBInsert(nama1);

                }

                else if (input == "2")
                {
                    this.DBReaderShow();
                }

                else if (input == "3")
                {
                    Console.Write("Masukan nama pegawai: ");
                    string nama2 = Console.ReadLine();

                    Console.Write("Masukan nama pegawai: ");
                    string nama = Console.ReadLine();

                    dbcontrol.DBUpdate(nama, nama2);

                }

                else if (input == "4")
                {
                    Console.Write("Masukan nama pegawai: ");
                    var nama = Console.ReadLine();
                    if (nama == null)
                    {

                    }

                    else
                    {
                        dbcontrol.DBDelete(nama);
                    }


                }

                else if (input == "99")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Masukan Salah Mohon Ulangi Lagi");
                }
            }

        }
        public void DBReaderShow()
        {
            var data = dbcontrol.DBReader();
            Console.WriteLine("Data : \n");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Console.Write(i + 1 + ". ");
                Console.Write(data.Rows[i]["nama"] + ", ");
                Console.WriteLine("");
            }
            Console.WriteLine("\n");
        }

    }
}