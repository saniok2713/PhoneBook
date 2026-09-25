using MySql.Data.MySqlClient;

namespace PhoneBook {
    internal class PhoneBookService {

        private Database db = new Database();
        String query = "";
        public void AddContact(String name, String phone) {

            using (MySqlConnection connection = db.GetConnection()) {
                Console.WriteLine("Connecting to MySQL...");
                connection.Open();
                query = "INSERT INTO contacts (user_name, phone_number) VALUES (@name, @number)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@number", phone);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteContact(int id) {
            using (MySqlConnection connection = db.GetConnection()) {
                Console.WriteLine("Connecting to MySQL...");
                connection.Open();
                query = "DELETE FROM contacts WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void SearchContat(String name) {
            using (MySqlConnection connection = db.GetConnection()) {
                Console.WriteLine("Connecting to MySQL...");
                connection.Open();
                query = "SELECT * FROM contacts WHERE user_name LIKE @name";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", name + "%");
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    Console.WriteLine("Name: " + reader["user_name"] + " - " + "Number: " + reader["phone_number"]);
                }
            }
        }

        public void GetAllContacts() { //better load the names from database to LinkedList as done below
            using (MySqlConnection connection = db.GetConnection()) {
                Console.WriteLine("Connecting to MySQL...");
                connection.Open();
                query = "SELECT * FROM contacts";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    Console.WriteLine("ID:" + reader["id"] + " Name: " + reader["user_name"] + " Number: " + reader["phone_number"]);
                }
                reader.Close();
            }

        }

        public List<Contact> GetContactsList() {
            List<Contact> contacts = new List<Contact>();
            using (MySqlConnection connection = db.GetConnection()) {
                Console.WriteLine("Connecting to MySQL...");
                connection.Open();
                query = "SELECT * FROM contacts ORDER BY user_name";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    Contact contact = new Contact();
                    contact.ID = Convert.ToInt32(reader["id"]);
                    contact.Name = reader["user_name"].ToString();
                    contact.Phone = reader["phone_number"].ToString();
                    contacts.Add(contact);
                }
                reader.Close();
            }
            return contacts;
        }

        public List<Contact> SearchContactList(String name) {
            List<Contact> contacts = new List<Contact>();

            using (MySqlConnection connection = db.GetConnection()) {
                Console.WriteLine("Connecting to MySQL...");
                connection.Open();
                query = "SELECT * FROM contacts WHERE user_name LIKE @name";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", "%" + name + "%");
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    Contact contact = new Contact();
                    contact.Name = reader["user_name"].ToString();
                    contact.Phone = reader["phone_number"].ToString();
                    contacts.Add(contact);
                }
                reader.Close();

            }
            return contacts;
        }

        public void UpdateContact(String name, String phone, int id) {
            using (MySqlConnection connection = db.GetConnection()) {
                connection.Open();
                query = "UPDATE contacts SET user_name = @name, phone_number= @number WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@number", phone);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Contact SearchContactID(int id) {
            Contact contact = null;
            using (MySqlConnection connection = db.GetConnection()) {
                connection.Open();
                query = "SELECT * FROM contacts WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    contact = new Contact();
                    contact.Name = reader["user_name"].ToString();
                    contact.Phone = reader["phone_number"].ToString();
                }
                reader.Close();
            }
            return contact;
        }
    }
}
