<?php
// SIMPLE API USING JSON FILE

header("Content-Type: application/json");

// FILE WHERE USERS ARE STORED
$file = "users.json";

// CREATE FILE IF NOT EXISTS
if (!file_exists($file)) {
    file_put_contents($file, json_encode([]));
}

// LOAD USERS
$users = json_decode(file_get_contents($file), true);

// GET ACTION
$action = $_GET['action'] ?? '';

// ================= REGISTER =================
if ($action == "register") {
    $username = $_POST['username'] ?? '';
    $password = $_POST['password'] ?? '';

    if ($username == '' || $password == '') {
        echo "Username or password missing";
        exit;
    }

    // CHECK IF EXISTS
    foreach ($users as $user) {
        if ($user['username'] == $username) {
            echo "User already exists";
            exit;
        }
    }

    // ADD USER
    $users[] = [
        "id" => count($users) + 1,
        "username" => $username,
        "password" => $password
    ];

    file_put_contents($file, json_encode($users, JSON_PRETTY_PRINT));
    echo "Registered successfully";
}

// ================= LOGIN =================
elseif ($action == "login") {
    $username = $_POST['username'] ?? '';
    $password = $_POST['password'] ?? '';

    foreach ($users as $user) {
        if ($user['username'] == $username && $user['password'] == $password) {
            echo "Login successful";
            exit;
        }
    }

    echo "Invalid credentials";
}

// ================= VIEW USERS =================
elseif ($action == "view") {
    echo json_encode($users);
}

// ================= UPDATE PASSWORD =================
elseif ($action == "update") {
    $username = $_POST['username'] ?? '';
    $password = $_POST['password'] ?? '';

    foreach ($users as &$user) {
        if ($user['username'] == $username) {
            $user['password'] = $password;

            file_put_contents($file, json_encode($users, JSON_PRETTY_PRINT));
            echo "Password updated";
            exit;
        }
    }

    echo "User not found";
}

// ================= DELETE USER =================
elseif ($action == "delete") {
    $username = $_POST['username'] ?? '';

    foreach ($users as $key => $user) {
        if ($user['username'] == $username) {
            unset($users[$key]);

            file_put_contents($file, json_encode(array_values($users), JSON_PRETTY_PRINT));
            echo "User deleted";
            exit;
        }
    }

    echo "User not found";
}

// ================= INVALID =================
else {
    echo "Invalid action";
}
?>