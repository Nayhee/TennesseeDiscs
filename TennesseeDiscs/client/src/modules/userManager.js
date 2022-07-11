const baseUrl = '/api/User';

export const getAllUsers = () => {
    return fetch(baseUrl)
      .then((res) => res.json())
  };

  export const getUserById = (userId) => {
    return fetch(`${baseUrl}/${userId}`)
    .then(res => res.json())
}
  
  //ADMIN ONLY
  export const addUser = (user) => {
    return fetch(baseUrl, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(user),
    });
  };

  export const deleteUser = (id) => {
    return fetch(`${baseUrl}/${id}`, {
        method: "DELETE"
    }).then(result => result.json())
}

export const updateUser  = (editedUser) => {
    return fetch(`${baseUrl}/${editedUser.id}`, {
        method: "PATCH",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(editedUser)
    }).then(data => data.json());
}