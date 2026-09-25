using PhoneBook;


int choice, id = 0;
String name = "", number = "";
PhoneBookService ph = new PhoneBookService();


do {
    Console.WriteLine("1 Add contact");
    Console.WriteLine("2 Delete contact");
    Console.WriteLine("3 Searh contact");
    Console.WriteLine("4 Show all contacts");
    Console.WriteLine("5 Update contact");
    Console.WriteLine("0 Exit");
    Console.Write("Choice: ");
    string input = Console.ReadLine();

    if (!int.TryParse(input, out choice)) {
        Console.WriteLine("Invalid choice!");
        choice = -1;
        continue;
    }

    switch (choice) {
        case 1:
            Console.Write("Add name: ");
            name = Console.ReadLine(); ;
            Console.Write("Add phone number: ");
            number = Console.ReadLine();

            ph.AddContact(name, number);
            Console.WriteLine("Contact added!");
            break;
        case 2:
            Console.Write("Insert contact ID: ");
            id = Convert.ToInt32(Console.ReadLine());

            ph.DeleteContact(id);
            Console.WriteLine("Contact deleted!");
            break;
        case 3:
            Console.Write("Enter name: ");
            name = Console.ReadLine();

            List<Contact> contactsSearch = ph.SearchContactList(name);
            if (contactsSearch.Count() == 0) {
                Console.WriteLine("Contacts not found!");
            } else {
                foreach (var c in contactsSearch) {
                    Console.WriteLine("Name: {0} Phone: {1}", c.Name, c.Phone);
                }
            }


            break;
        case 4:
            List<Contact> contacts = ph.GetContactsList();
            foreach (var c in contacts) {
                Console.WriteLine("ID: {0} Name: {1} Phone: {2}", c.ID, c.Name, c.Phone);
            }
            break;

        case 5:
            Console.Write("Insert contact ID: ");
            id = Convert.ToInt32(Console.ReadLine());
            Contact contact = ph.SearchContactID(id);
            if (contact == null) {
                Console.WriteLine("Contact not found!");
            } else {
                Console.WriteLine($"Name: {contact.Name} Phone {contact.Phone}");
                Console.Write("Insert name: ");
                name = Console.ReadLine();
                Console.Write("Insert number: ");
                number = Console.ReadLine();
                ph.UpdateContact(name, number, id);
            }
            break;
        case 0:
            Console.WriteLine("Exit!");
            break;
        default:
            Console.WriteLine("Not valid!");
            break;
    }

} while (choice != 0);