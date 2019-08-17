let getAllBtn = document.getElementById("btn1");
let getByIdBtn = document.getElementById("btn2");
let getByIdInput1 = document.getElementById("input2");

let addUserBtn = document.getElementById("btn3");
let addUserInput1 = document.getElementById("input31");
let addUserInput2 = document.getElementById("input32");
let addUserInput3 = document.getElementById("input33");

let checkAdultBtn = document.getElementById("btn4");
let checkAdultInput1 = document.getElementById("input4");

let port = "52191"
let getAllUsers = async () => {
    let url = "http://localhost:" + port + "/api/users";

    let response = await fetch(url);
    let data = await response.json();
    console.log(data);
};

let getUserById = async () => {
    let url = "http://localhost:" + port + "/api/users/" + getByIdInput1.value;

    let response = await fetch(url);
    let data = await response.text();    
    console.log(data);
};

let addUser = async () => {
    let url = "http://localhost:" + port + "/api/users";
    let user = { firstName: addUserInput1.value, lastName: addUserInput2.value, age: addUserInput3.value }
    await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    });
}

let checkAdult = async () => {
    let url = "http://localhost:" + port + "/api/users/" + checkAdultInput1.value;

    let response = await fetch(url);
    let data = await response.text();
    console.log(data);    
};

getAllBtn.addEventListener("click", getAllUsers);
getByIdBtn.addEventListener("click", getUserById);
addUserBtn.addEventListener("click", addUser);
checkAdultBtn.addEventListener("click", checkAdult);