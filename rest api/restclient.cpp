#include <iostream>
#include <cstdlib>
using namespace std;

int main() {
    int c;

    while (true) {
        cout << "\n===== MENU =====\n";
        cout << "1. Register\n2. Login\n3. List\n4. Update\n5. Delete\n6. Exit\n";
        cout << "Choice: ";
        cin >> c;

        if (c == 1) {
            string u, p;
            cout << "Enter Username: ";
            cin >> u;
            cout << "Enter Password: ";
            cin >> p;

            string cmd = "curl \"http://localhost/student-api/api.php?action=register&username="
                        + u + "&password=" + p + "\"";

            system(cmd.c_str());
        }

        else if (c == 2) {
            string u, p;
            cout << "Enter Username: ";
            cin >> u;
            cout << "Enter Password: ";
            cin >> p;

            string cmd = "curl \"http://localhost/student-api/api.php?action=login&username="
                        + u + "&password=" + p + "\"";

            system(cmd.c_str());
        }

        else if (c == 3) {
            system("curl \"http://localhost/student-api/api.php?action=list\"");
        }

        else if (c == 4) {
            string id, p;
            cout << "Enter User ID: ";
            cin >> id;
            cout << "Enter New Password: ";
            cin >> p;

            string cmd = "curl \"http://localhost/student-api/api.php?action=update&id="
                        + id + "&password=" + p + "\"";

            system(cmd.c_str());
        }

        else if (c == 5) {
            string id;
            cout << "Enter User ID to delete: ";
            cin >> id;

            string cmd = "curl \"http://localhost/student-api/api.php?action=delete&id="
                        + id + "\"";

            system(cmd.c_str());
        }

        else if (c == 6) {
            break;
        }

        else {
            cout << "Invalid choice\n";
        }
    }

    return 0;
}
