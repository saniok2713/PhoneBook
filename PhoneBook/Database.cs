using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook {
    internal class Database {
        private String connectionString = "server=localhost;user=root;password=5623;database=phonebook;";

        public MySqlConnection GetConnection() {
            return new MySqlConnection(connectionString);
        }
    }
}
