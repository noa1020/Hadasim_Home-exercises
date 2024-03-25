const userUri = '/User';
let users = [];

// Fetches users from the server
async function GetUsers() {
    fetch(userUri, {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
    }).then(async response => {
        if (!response.ok) {
            const errorMessage = await response.text();
            const errorMessageFirstLine = errorMessage.split(' at ')[0];
            throw new Error( errorMessageFirstLine);
        }
        return response.json();
    })
        .then(data => { users = data; DisplayItems(); })
        .catch(error => console.error('Error geting users.', error));
}
// Initial call to fetch items
(async () => {
    try {
        await GetUsers();
    } catch (error) {
        alert(error.message);
    }
})();


// Deletes a user by userId
function DeleteUser(userId) {
    fetch(`${userUri}/${userId}`, {
        method: 'DELETE',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
    }).then(async response => {
        if (!response.ok) {
            const errorMessage = await response.text();
            const errorMessageFirstLine = errorMessage.split(' at ')[0];
            throw new Error(errorMessageFirstLine);
        }
        location.reload();
    }).catch(error => alert('Error deleting user: ' + error));
}

// Updates user information
async function UpdateUser(user) {
    try {
        const response = await fetch(userUri, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(user)
        });

        if (!response.ok) {
            const errorMessage = await response.text();
            const errorMessageFirstLine = errorMessage.split(' at ')[0];
            throw new Error( errorMessageFirstLine);
        }
     } catch (error) {
        alert('Error updating user: '+ error);
    }
    location.reload();
}
// Add new user 
async function AddUser(user) {
    try {
        const response = await fetch(userUri, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(user)
        });

        if (!response.ok) {
            const errorMessage = await response.text();
            const errorMessageFirstLine = errorMessage.split(' at ')[0];
            throw new Error( errorMessageFirstLine);
        }
        location.reload();

     } catch (error) {
        alert('Error adding user: '+ error);
    }
}